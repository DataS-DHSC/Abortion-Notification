using Statiq.Common;
using Statiq.Core;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace DHSC.ANS.API.Consumer.Docs.Modules
{
	public class CompileSassWithDart : Module
	{
		protected override async Task<IEnumerable<IDocument>> ExecuteInputAsync(IDocument input, IExecutionContext context)
		{
			// Absolute path to the .scss file
			var inputFilePath = input.Source.FullPath;

			context.LogInformation($"Processing file: {input.Source}");

			if (string.IsNullOrWhiteSpace(inputFilePath))
			{
				context.LogError("Invalid input file path.");
				return Array.Empty<IDocument>();
			}

			// Build a temp output file name based on the input file (e.g., "main.scss" => "main.css")
			var tempOutputFile = Path.Combine(
				context.FileSystem.GetTempDirectory().Path.ToString(),
				$"{Path.GetFileNameWithoutExtension(inputFilePath)}.css"
			);

			var sassPath = Path.Combine(
				context.FileSystem.RootPath.FullPath,
				"node_modules",
				"sass",
				"sass.js"
			);

			if (!File.Exists(sassPath))
			{
				context.LogError($"Cannot find sass.js at {sassPath}. Make sure you have installed sass via npm.");
				return Array.Empty<IDocument>();
			}

			context.LogInformation($"Executing Dart Sass for {inputFilePath} -> {tempOutputFile}");
			context.LogInformation($"Command: node \"{sassPath}\" \"{inputFilePath}\" \"{tempOutputFile}\" --no-source-map");

			// Pass both input and output paths to sass.js
			var processInfo = new ProcessStartInfo
			{
				FileName = "node",
				Arguments = $"\"{sassPath}\" \"{inputFilePath}\" \"{tempOutputFile}\" --no-source-map",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true,
				WorkingDirectory = context.FileSystem.RootPath.FullPath
			};

			using var process = Process.Start(processInfo);

			if (process == null)
			{
				context.LogError("Failed to start the Sass compilation process.");
				return Array.Empty<IDocument>();
			}

			Task<string> stdOutTask = process.StandardOutput.ReadToEndAsync();
			Task<string> stdErrTask = process.StandardError.ReadToEndAsync();

			await Task.WhenAll(stdOutTask, stdErrTask);

			string stdOut = stdOutTask.Result;
			string stdErr = stdErrTask.Result;

			process.WaitForExit();

			context.LogInformation($"CompileSassWithDart: Execution of Dart Sass complete {inputFilePath} -> {tempOutputFile}");

			if (process.ExitCode != 0)
			{
				context.LogError($"Sass compilation failed for {inputFilePath}\n{stdErr}");
				return Array.Empty<IDocument>();
			}

			context.LogInformation("Sass compilation succeeded.");

			// Read the compiled CSS from the temp file
			string cssOutput;
			try
			{
				cssOutput = await File.ReadAllTextAsync(tempOutputFile);
			}
			catch (IOException ioEx)
			{
				context.LogError($"Unable to read compiled CSS from {tempOutputFile}: {ioEx.Message}");
				return Array.Empty<IDocument>();
			}

			// Return the compiled CSS content as a new document in the pipeline
			var outputDocument = input.Clone(context.GetContentProvider(cssOutput));
			return outputDocument.Yield();
		}
	}
}

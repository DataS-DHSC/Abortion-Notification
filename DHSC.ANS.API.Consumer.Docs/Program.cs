using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading.Tasks;
using DHSC.ANS.API.Consumer.Docs.Modules;
using Lunr;
using Markdig;
using Markdig.Extensions.Tables;
using Microsoft.Extensions.DependencyInjection;
using Statiq.App;
using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Razor;
using Statiq.Sass;

namespace DHSC.ANS.API.Consumer.Docs
{
	public class Program
	{
		public static async Task<int> Main(string[] args)
		{
			// Convert Swagger Docs to Markdown
			RunWiddershins();

			return await Bootstrapper
				.Factory
				.CreateWeb(args)
				.AddSetting(MarkdownKeys.MarkdownExtensions, "bootstrap")
				.ModifyPipeline(
					nameof(Statiq.Web.Pipelines.Content),
					x => x.ProcessModules
						.GetFirst<CacheDocuments>()
						.Children
						.ReplaceLast<ExecuteIf>(
							new ExecuteIf(Config.FromDocument(doc => doc.MediaTypeEquals(MediaTypes.Html)))
							{
								new GenerateExcerpt(),
								new GatherHeadings(Config.FromDocument(WebKeys.GatherHeadingsLevel, 3)).WithNesting().WithHeadingKey("HeadingKey"),
                                new WrapCodeExamplesInTabsModule(),
                                new AddHeadingIdsModule(),
                                new GovUkStylingModule(),
                                new RenderRazor()
                            }))

				// Build the Gov UK SASS
				.BuildPipeline("Compile CSS", builder => builder
					.WithInputReadFiles("../styles/main.scss")
					.WithProcessModules(
						new CompileSassWithDart()
					)
					.WithOutputWriteFiles("assets/css/main.css")
				)

				.RunAsync();
		}

		private static void RunWiddershins()
		{
			Console.WriteLine("Running Widdershins to generate documentation...");

			var widdershinsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "node_modules/widdershins/widdershins.js"));
			var swaggerJsonPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../DHSC.ANS.API.Consumer/bin/Debug/net9.0/swagger.json"));
			var markdownOutputPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "input/reference.md"));
			var widdershinsConfigPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "widdershins/widdershins-config.json"));

			var args = $"{widdershinsPath} --e \"{widdershinsConfigPath}\" --summary \"{swaggerJsonPath}\" -o \"{markdownOutputPath}\"";

			var processStartInfo = new ProcessStartInfo
			{
				FileName = "node",
				Arguments = args,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			try
			{
				var process = Process.Start(processStartInfo);
				process.WaitForExit();

				if (process.ExitCode == 0)
				{
					Console.WriteLine("Widdershins successfully generated the Markdown file.");
				}
				else
				{
					Console.WriteLine("Widdershins failed. Error:");
					Console.WriteLine(process.StandardError.ReadToEnd());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while running Widdershins: {ex.Message}");
			}
		}
	}
}

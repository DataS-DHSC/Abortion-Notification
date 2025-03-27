using dotless.Core.Utils;
using Microsoft.Extensions.Logging;
using Statiq.Common;
using Statiq.Core;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DHSC.ANS.API.Consumer.Docs.Modules
{
	public class AddHeadingIdsModule : Module
	{
		protected override async Task<IEnumerable<IDocument>> ExecuteInputAsync(IDocument input, IExecutionContext context)
		{
			var content = await input.GetContentStringAsync();

			var styledContent = ApplyHeadingIds(content);

			var outputDocument = input.Clone(context.GetContentProvider(styledContent));
			return outputDocument.Yield();
		}

		private string ApplyHeadingIds(string html)
		{
			html = Regex.Replace(html, @"<h(\d)>(.*?)</h\1>", m =>
			{
				var level = m.Groups[1].Value;
				var content = m.Groups[2].Value;

				var slug = Regex.Replace(content.ToLower(), @"[^a-z0-9\s]+", "").Replace(" ", "-").Trim('-');

				return $"<h{level} id=\"{slug}\">{content}\n</h{level}>";
			});

			return html;
		}
	}
}

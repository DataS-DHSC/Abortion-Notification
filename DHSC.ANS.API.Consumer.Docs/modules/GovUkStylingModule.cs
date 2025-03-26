using dotless.Core.Utils;
using Microsoft.Extensions.Logging;
using Statiq.Common;
using Statiq.Core;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DHSC.ANS.API.Consumer.Docs.Modules
{
	public class GovUkStylingModule : Module
	{
		protected override async Task<IEnumerable<IDocument>> ExecuteInputAsync(IDocument input, IExecutionContext context)
		{
			var content = await input.GetContentStringAsync();

			var styledContent = ApplyGovUkStyling(content);

			var outputDocument = input.Clone(context.GetContentProvider(styledContent));
			return outputDocument.Yield();
		}

		private string ApplyGovUkStyling(string html)
		{
			html = Regex.Replace(html, @"<table>", "<table class='govuk-table'>");
			html = Regex.Replace(html, @"<thead>", "<thead class='govuk-table__head'>");
			html = Regex.Replace(html, @"<th>", "<th class='govuk-table__header'>");
			html = Regex.Replace(html, @"<tbody>", "<tbody class='govuk-table__body'>");
			html = Regex.Replace(html, @"<td>", "<td class='govuk-table__cell'>");
			html = Regex.Replace(html, @"<h1>", "<h1 class='govuk-heading-xl'>");
			html = Regex.Replace(html, @"<h2>", "<h2 class='govuk-heading-l'>");
			html = Regex.Replace(html, @"<h3>", "<h3 class='govuk-heading-m'>");
			html = Regex.Replace(html, @"<h4>", "<h4 class='govuk-heading-s'>");
			html = Regex.Replace(html, @"<p>", "<p class='govuk-body-m'>");
			html = Regex.Replace(html, @"<ul>", "<ul class='govuk-list govuk-list--bullet'>");
			html = Regex.Replace(html, @"<ol>", "<ol class='govuk-list govuk-list--number'>");
			html = Regex.Replace(html, @"<hr />", "<hr class='govuk-section-break govuk-section-break--xl govuk-section-break--visible'>");

			return html;
		}
	}
}

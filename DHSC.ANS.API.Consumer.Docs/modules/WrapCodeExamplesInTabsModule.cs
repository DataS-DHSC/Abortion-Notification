using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Statiq.Common;
using Statiq.Core;
using Microsoft.Extensions.Logging;

// Resolve ambiguity by aliasing the two IDocument types:
using StatiqDoc = Statiq.Common.IDocument;
using AngleDoc = AngleSharp.Dom.IDocument;

namespace DHSC.ANS.API.Consumer.Docs.Modules
{
    public class WrapCodeExamplesInTabsModule : Module
    {
        protected override async Task<IEnumerable<StatiqDoc>> ExecuteInputAsync(StatiqDoc input, IExecutionContext context)
        {
            var content = await input.GetContentStringAsync();
            var styledContent = await GroupCodeExamples(content, input, context);
            var outputDocument = input.Clone(context.GetContentProvider(styledContent));
            return outputDocument.Yield();
        }

        private async Task<string> GroupCodeExamples(string html, StatiqDoc input, IExecutionContext context)
        {
            var parser = new HtmlParser();
            AngleDoc doc = await parser.ParseDocumentAsync(html);

            // Find all blockquote elements with class "blockquote" whose text is exactly "Code samples"
            var codeSamplesHeadings = doc.QuerySelectorAll("h4")
                .Where(h => h.TextContent.Trim().Equals("Code samples", StringComparison.OrdinalIgnoreCase))
                .ToList();

            context.LogInformation($"{codeSamplesHeadings.Count} code headings were found in the document {input.Source}");

            int index = 0;

            // For each "Code samples" heading, group subsequent siblings that are code blocks.
            foreach (var heading in codeSamplesHeadings)
            {
                var group = new List<IElement>();
                // Get siblings following the heading until a non-<pre> element is encountered.
                var sibling = heading.NextElementSibling;
                while (sibling != null)
                {
                    // Break the grouping if we encounter any element that is not a <pre>
                    if (!sibling.TagName.Equals("PRE", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    // Only consider <pre> elements that contain a <code> child.
                    if (sibling.QuerySelector("code") != null)
                    {
                        group.Add(sibling);
                    }
                    sibling = sibling.NextElementSibling;
                }

                // If we found more than one code block, wrap them in a tab control.
                if (group.Count > 1)
                {
                    // Create the outer container for tabs.
                    var tabContainer = doc.CreateElement("div");
                    tabContainer.ClassList.Add("govuk-tabs");
                    tabContainer.SetAttribute("data-module", "govuk-tabs");

                    // Create the tab navigation list.
                    var tabList = doc.CreateElement("ul");
                    tabList.ClassList.Add("govuk-tabs__list");
                    tabContainer.AppendChild(tabList);

                    // Create container for the tab panels.
                    var panelsContainer = doc.CreateElement("div");

                    foreach (var preElement in group)
                    {
                        // Determine the language by inspecting the <code> element's class (e.g., "language-javascript")
                        var codeElement = preElement.QuerySelector("code");
                        string language = "Example";
                        if (codeElement != null)
                        {
                            var langClass = codeElement.ClassList.FirstOrDefault(c => c.StartsWith("language-"));
                            if (langClass != null)
                            {
                                language = langClass.Substring("language-".Length);
                            }
                        }
                        string tabId = $"{language}-{index}";

                        // Build the tab list item.
                        var li = doc.CreateElement("li");
                        li.ClassList.Add("govuk-tabs__list-item");
                        if (index == 0)
                        {
                            li.ClassList.Add("govuk-tabs__list-item--selected");
                        }
                        var a = doc.CreateElement("a");
                        a.ClassList.Add("govuk-tabs__tab");
                        a.SetAttribute("href", "#" + tabId);
                        a.TextContent = language;
                        li.AppendChild(a);
                        tabList.AppendChild(li);

                        // Build the corresponding tab panel.
                        var panel = doc.CreateElement("section");
                        panel.ClassList.Add("govuk-tabs__panel");
                        if (index != 0)
                        {
                            panel.ClassList.Add("govuk-tabs__panel--hidden");
                        }
                        panel.SetAttribute("id", tabId);
                        panel.AppendChild(preElement.Clone(true));
                        panelsContainer.AppendChild(panel);

                        index++;
                    }

                    // Append the panels container after the tab list.
                    tabContainer.AppendChild(panelsContainer);

                    // Insert the tab container in place of the first code block in the group,
                    // then remove all original code blocks in the group.
                    group.First().ParentElement.InsertBefore(tabContainer, group.First());
                    foreach (var pre in group)
                    {
                        pre.Remove();
                    }
                }
            }

            // Return the modified HTML.
            return doc.DocumentElement.OuterHtml;
        }
    }
}

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.XPath;

public class RemarksSchemaFilter : ISchemaFilter
{
	private readonly XPathDocument _xmlDoc;

	public RemarksSchemaFilter(string xmlPath)
	{
		_xmlDoc = new XPathDocument(xmlPath);
	}

	public void Apply(OpenApiSchema schema, SchemaFilterContext context)
	{
		// Attempt to find <remarks> for the class.
		var type = context.Type;
		var typeFullName = type.FullName; // e.g. "MyNamespace.PractitionerInfoDto"

		// Construct an XPath to get <remarks> node for the type.
		string xpath = $"/doc/members/member[@name='T:{typeFullName}']/remarks";

		var navigator = _xmlDoc.CreateNavigator();
		var node = navigator.SelectSingleNode(xpath);

		if (node != null)
		{
			// If we find a <remarks> node, append its inner XML to the existing schema description
			var remarksText = node.InnerXml
				.Replace("<para>", "<p>")        // basic transform for paragraphs
				.Replace("</para>", "</p>")
				// you can do more replacements as needed
				.Trim();

			remarksText = Regex.Replace(remarksText, @"\[([^\]]+)\]\(([^\)]+)\)", "<a href=\"$2\" target=\"_blank\">$1</a>");

			remarksText = Regex.Replace(remarksText, @"(?:[\r\n]+\s*)+", "\r\n");

			// Merge it into the existing description
			if (!string.IsNullOrWhiteSpace(remarksText))
			{
				schema.Description = (schema.Description ?? "") + "\n" + remarksText;
			}
		}
	}
}

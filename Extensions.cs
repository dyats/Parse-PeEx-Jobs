using HtmlAgilityPack;
using System.Text;

namespace ParseJobs;

public static class Extensions
{
    public static string ConvertHtmlToFormattedPlainText(string html)
    {
        if (string.IsNullOrEmpty(html))
        {
            return null;
        }

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        // Process the HTML while maintaining structure
        var htmlContent = doc.DocumentNode.InnerHtml;

        // Create a new document for clean parsing
        var cleanDoc = new HtmlDocument();
        cleanDoc.LoadHtml(htmlContent);

        // Recursively process nodes to maintain formatting
        string ProcessNode(HtmlNode node)
        {
            var text = new StringBuilder();

            foreach (var child in node.ChildNodes)
            {
                switch (child.NodeType)
                {
                    case HtmlNodeType.Text:
                        text.Append(child.InnerText.Trim());
                        break;

                    case HtmlNodeType.Element:
                        switch (child.Name.ToLower())
                        {
                            case "br":
                                text.AppendLine();
                                break;
                            case "p":
                                text.AppendLine(ProcessNode(child));
                                text.AppendLine();
                                break;
                            case "li":
                                text.AppendLine($"- {ProcessNode(child)}");
                                break;
                            case "ul":
                            case "ol":
                                text.AppendLine();
                                text.Append(ProcessNode(child));
                                text.AppendLine();
                                break;
                            default:
                                text.Append(ProcessNode(child));
                                break;
                        }
                        break;
                }
            }

            return text.ToString();
        }

        var plainText = ProcessNode(cleanDoc.DocumentNode)
            .Replace("&nbsp;", " ")
            .Replace("&quot;", "\"")
            .Replace("&amp;", "&");

        // Clean up multiple consecutive newlines
        plainText = string.Join("\n", plainText.Split('\n')
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line)));

        return plainText;
    }
}

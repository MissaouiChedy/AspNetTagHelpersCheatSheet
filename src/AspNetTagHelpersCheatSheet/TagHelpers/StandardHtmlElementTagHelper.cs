using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AspNetTagHelpersCheatSheet.TagHelpers
{
    [HtmlTargetElement("p")]
    public class StandardHtmlElementTagHelper : TagHelper
    {
        public override int Order { get; } = int.MinValue;
        
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperContent content = null;
            if (output.Content.IsModified)
            {
                content = output.Content;
            }
            else
            {
                content = await output.GetChildContentAsync();
            }
            output.Content.SetHtmlContent("Prepend 1 -> " + content.GetContent());
        }
    }

    [HtmlTargetElement("p")]
    public class OtherStandardHtmlElementTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperContent content = null;
            if (output.Content.IsModified)
            {
                content = output.Content;
            }
            else
            {
                content = await output.GetChildContentAsync();
            }
            output.Content.SetHtmlContent("Other Prepend -> " + content.GetContent());
        }
    }
}

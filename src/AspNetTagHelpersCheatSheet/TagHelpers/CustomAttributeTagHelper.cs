using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AspNetTagHelpersCheatSheet.TagHelpers
{
    [HtmlTargetElement(Attributes = "hello-prefix")]
    public class CustomAttributeTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            /*
             * Remove the custom attribute since it will be useless
             * after rendering
             */
            output.Attributes.Remove(new TagHelperAttribute("hello-prefix"));
            /*
             * Get the html element content asynchronously
             */
            TagHelperContent content = await output.GetChildContentAsync();
            /*
             * Prepend "Hello " to the initial content
             */
            output.Content.SetHtmlContent("Hello " + content.GetContent());
        }
    }
}

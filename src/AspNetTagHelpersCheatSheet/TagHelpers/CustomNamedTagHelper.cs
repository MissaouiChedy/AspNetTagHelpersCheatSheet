using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetTagHelpersCheatSheet.TagHelpers
{
    [HtmlTargetElement("arbitrary-name")]
    public class CustomNamedTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.Content.SetHtmlContent("Arbitrarly named!");
        }
    }
}

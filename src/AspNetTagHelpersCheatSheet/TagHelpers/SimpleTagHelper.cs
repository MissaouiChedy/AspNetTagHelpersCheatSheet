using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetTagHelpersCheatSheet.TagHelpers
{
    public class SimpleTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.Content.SetHtmlContent("Very simple!");
        }
    }
}

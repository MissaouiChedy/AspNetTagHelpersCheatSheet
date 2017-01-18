using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetTagHelpersCheatSheet.TagHelpers
{
    [HtmlTargetElement("empty-element", TagStructure = TagStructure.WithoutEndTag)]
    public class EmptyElementTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "hr";
        }
    }
}

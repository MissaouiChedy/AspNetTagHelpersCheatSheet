using Microsoft.AspNetCore.Razor.TagHelpers;


namespace AspNetTagHelpersCheatSheet.TagHelpers
{
    [HtmlTargetElement("p")]
    public class StandardHtmlElementTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            /*
             * Erases the content of the targeted element
             */
            output.Content.SetHtmlContent("Erased !");
        }
    }
}

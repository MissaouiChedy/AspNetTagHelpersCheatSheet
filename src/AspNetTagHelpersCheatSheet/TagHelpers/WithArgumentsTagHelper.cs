using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AspNetTagHelpersCheatSheet.TagHelpers
{
    public class Holder
    {
        public int Id { get; set; }
    }

    public class WithArgumentsTagHelper : TagHelper
    {
        public int NumberArg { get; set; }
        public string StringArg { get; set; }
        public Holder ObjectArg { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //set tag name
            output.TagName = "div";
            //add html attributes
            output.Attributes.SetAttribute(new TagHelperAttribute("class", "someclass"));
            //retrieve initial content
            var content = await output.GetChildContentAsync();
            //use interpolated strings
            output.Content.SetHtmlContent($@"Number -> {NumberArg} 
StringArg -> {StringArg} 
ObjectArg.Id -> {ObjectArg.Id}");
        }
    }
}

using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AspNetTagHelpersCheatSheet.TagHelpers
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // -> This attribute controls the tag helper activation
    [HtmlTargetElement("super-simple")] // -> by tag name
    //[HtmlTargetElement(Attributes="super-simple")] // -> by attribute presence
    //[HtmlTargetElement("div")] // -> targeting standard tag name
    //[HtmlTargetElement("p", Attributes="super-simple")] // -> mixed tag name and attributes
    public class SuperSample : TagHelper // The tag helper class name ends by "TagName" but it's not mandatory
    {
        //Properties in the class are mapped to custom html attributes on the cshtml side
        //By convention the custom html attribute name is the kebab-cased property name
        //This HtmlAttributeName CLR Attribute allows to set an arbitrary kebab-cased name
        [HtmlAttributeName("name")]
        public string Name { get; set; }

        //This property can be populated by a C# expression
        [HtmlAttributeName("person")]
        public Person Person { get; set; }

        // This method contains the actual rendering logic
        // the output argument must be populated with the actual html content
        // the context argument can be used as a dict that stores data that is communicated
        // between parent and children tag helpers
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Get the content specified inside the tag helper in the cshtml 
            TagHelperContent initialContent = await output.GetChildContentAsync();
            //Set the html tag that is going to substitute the element targeted by the tag helper  
            output.TagName = "p";

            //Set attributes on the resulting top level html element
            output.Attributes.SetAttribute(new TagHelperAttribute("class", "someclass"));
            
            //Generate actual content (notice the usage of interpolated string)
            string outputContent = $@"<h4>Name: {Name}</h4> 
<h4>Person.Id: {Person.Id}</h4>
<h4>Person.Name: {Person.Name}</h4>
<p>{initialContent.GetContent()}</p>";

            //Set the output content
            output.Content.SetHtmlContent(outputContent);
        }
    }
}

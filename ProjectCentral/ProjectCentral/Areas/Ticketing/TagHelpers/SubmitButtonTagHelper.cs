using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ProjectCentral.Areas.Ticketing.TagHelpers
{
    [HtmlTargetElement("button", Attributes ="submit")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            object style = output.Attributes.ContainsName("style") ? output.Attributes["style"].Value : null;
            output.Attributes.SetAttribute("style", style?.ToString() + ";background-image: linear-gradient(to right, red , yellow);");
        }
    }
}

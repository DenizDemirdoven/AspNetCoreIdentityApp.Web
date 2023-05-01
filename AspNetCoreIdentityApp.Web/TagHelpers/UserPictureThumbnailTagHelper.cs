using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCoreIdentityApp.Web.TagHelpers
{
    public class UserPictureThumbnailTagHelper: TagHelper
    {
        public string PictureUrl { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            if (String.IsNullOrEmpty(PictureUrl))
            {
                output.Attributes.SetAttribute("src", "/userphotos/default-profile.jpg");
                output.Attributes.SetAttribute("height", "300");

            }
            else
            {
                output.Attributes.SetAttribute("src", $"/userphotos/{PictureUrl}");
                output.Attributes.SetAttribute("height", "300");

            }

            base.Process(context, output);
        }

    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Zelenko30331_lab.TagHelpers
{
    [HtmlTargetElement("img", Attributes = "img-action, img-controller")]
    public class ImageTagHelper(LinkGenerator linkGenerator) : TagHelper
    {
        public string ImgController { get; set; }
        public string ImgAction { get; set; }
        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            output.Attributes.Add("src",
            linkGenerator.GetPathByAction(ImgAction, ImgController));
        }
    }
}

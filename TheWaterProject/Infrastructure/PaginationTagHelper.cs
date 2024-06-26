﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Infrastructure
{
    [HtmlTargetElement("div", Attributes ="page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        // Constructor to initialize the tag helper with an IUrlHelperFactory instance
        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }
        public PaginationInfo PageModel { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = String.Empty;
        public string PageClassNormal {  get; set; } = String.Empty;
        public string PageClassSelected {  get; set; } = String.Empty;

        // Method to process the tag helper
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                // Retrieve URL helper
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                // Create a div tag to contain pagination links
                TagBuilder result = new TagBuilder("div");

                // Loop through each page and create a link
                for (int i = 1; i<= PageModel.TotalNumPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");

                    // Set href attribute to link to the corresponding page
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });

                    // Add CSS classes if enabled
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }
                    tag.InnerHtml.Append(i.ToString());

                    result.InnerHtml.AppendHtml(tag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }

    }
}

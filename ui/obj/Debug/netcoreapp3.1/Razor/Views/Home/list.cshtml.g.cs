#pragma checksum "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06ed6ccf227f2adc365378b38d4fb7d6ca8d6d98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_list), @"mvc.1.0.view", @"/Views/Home/list.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06ed6ccf227f2adc365378b38d4fb7d6ca8d6d98", @"/Views/Home/list.cshtml")]
    public class Views_Home_list : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ui.ViewModels.PostViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n  <div class=\"row\">\r\n    <div >\r\n");
#nullable restore
#line 5 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
           if(Model.Count == 0){

#line default
#line hidden
#nullable disable
            WriteLiteral("              <div class=\"alert alert-danger\" role=\"alert\">\r\n                There is no post about \"");
#nullable restore
#line 7 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
                                   Write(ViewBag.query);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" !\r\n              </div>\r\n");
#nullable restore
#line 9 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
          }
          else{
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
       Write(await Html.PartialAsync("_filter"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
                                               
            
            foreach (var pvm in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"post-preview\">\r\n              <a class=\"btn btn-outline-primary float-right \"");
            BeginWriteAttribute("style", " style=\"", 502, "\"", 533, 3);
            WriteAttributeValue("", 510, "display:", 510, 8, true);
#nullable restore
#line 16 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
WriteAttributeValue("", 518, ViewBag.admin, 518, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 532, ";", 532, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 534, "\"", 570, 2);
            WriteAttributeValue("", 541, "/Home/deletepost/", 541, 17, true);
#nullable restore
#line 16 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
WriteAttributeValue("", 558, pvm.post.id, 558, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete &rarr;</a>\r\n              <a class=\"btn btn-outline-primary float-right mr-2\"");
            BeginWriteAttribute("style", " style=\"", 656, "\"", 687, 3);
            WriteAttributeValue("", 664, "display:", 664, 8, true);
#nullable restore
#line 17 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
WriteAttributeValue("", 672, ViewBag.admin, 672, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 686, ";", 686, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 688, "\"", 724, 2);
            WriteAttributeValue("", 695, "/Home/updatepost/", 695, 17, true);
#nullable restore
#line 17 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
WriteAttributeValue("", 712, pvm.post.id, 712, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Update &rarr;</a>\r\n              <a");
            BeginWriteAttribute("href", " href=\"", 761, "\"", 791, 2);
            WriteAttributeValue("", 768, "/Home/post/", 768, 11, true);
#nullable restore
#line 18 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
WriteAttributeValue("", 779, pvm.post.id, 779, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <h2 class=\"post-title\">\r\n                  ");
#nullable restore
#line 20 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
             Write(pvm.postHeader.heading);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h2>\r\n                <h3 class=\"post-subtitle\">\r\n                  ");
#nullable restore
#line 23 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
             Write(pvm.postHeader.subHeading);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h3>\r\n              </a>\r\n              <p class=\"post-meta\">Posted by\r\n                <a href=\"#\">Fatih Gurkan</a>\r\n                on ");
#nullable restore
#line 28 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
              Write(pvm.post.date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"float-right\">\r\n                      ");
#nullable restore
#line 30 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
                 Write(pvm.post.viewCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("  Views \r\n                </div>\r\n              </p>\r\n              \r\n              \r\n");
#nullable restore
#line 35 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
                 foreach (var item in pvm.categoryNames)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                  <a");
            BeginWriteAttribute("href", " href=\"", 1449, "\"", 1481, 2);
            WriteAttributeValue("", 1456, "/Home/post?category=", 1456, 20, true);
#nullable restore
#line 37 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
WriteAttributeValue("", 1476, item, 1476, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" > <strong>#");
#nullable restore
#line 37 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
                                                             Write(item );

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></a>\r\n");
#nullable restore
#line 38 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
                   
                }              

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n              </div>\r\n              <hr>\r\n");
#nullable restore
#line 43 "C:\Users\fatih\Documents\myblog\ui\Views\Home\list.cshtml"
            }
          }

#line default
#line hidden
#nullable disable
            WriteLiteral("          \r\n  \r\n    </div>\r\n  </div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ui.ViewModels.PostViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
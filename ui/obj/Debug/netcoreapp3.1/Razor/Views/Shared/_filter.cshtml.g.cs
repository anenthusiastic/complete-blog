#pragma checksum "C:\Users\fatih\Documents\myblog\ui\Views\Shared\_filter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e5abd999ce31508c647c408b44fe58cdfd6b260"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__filter), @"mvc.1.0.view", @"/Views/Shared/_filter.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e5abd999ce31508c647c408b44fe58cdfd6b260", @"/Views/Shared/_filter.cshtml")]
    public class Views_Shared__filter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<p><strong>Filtering by date interval</strong> </p> 
<form action=""/Home/filter"" class=""form-inline mt-2"">
    Start date: 
    <input name=""start"" type=""text"" class=""form-control mr-2""  placeholder=""YYYY-MM-DD"">
    End date:
    <input name=""end"" type=""text"" class=""form-control mr-2""  placeholder=""YYYY-MM-DD"">
    |
    <button type=""submit"" class=""btn btn-outline-primary  ml-2"">Filter</button>
</form>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
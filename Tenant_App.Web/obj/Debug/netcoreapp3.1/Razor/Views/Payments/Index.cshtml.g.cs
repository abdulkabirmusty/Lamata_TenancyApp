#pragma checksum "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b7ceaaa6df6de4dcc4ab17d32c679bdccb49634908dfb13e51557ab1b91f05d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payments_Index), @"mvc.1.0.view", @"/Views/Payments/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\_ViewImports.cshtml"
using Tenant_App.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\_ViewImports.cshtml"
using Tenant_App.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\_ViewImports.cshtml"
using Tenant_App.Models.DataObjects.EmailMessaging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\_ViewImports.cshtml"
using Tenant_App.Models.DataObjects.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\_ViewImports.cshtml"
using Tenant_App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b7ceaaa6df6de4dcc4ab17d32c679bdccb49634908dfb13e51557ab1b91f05d3", @"/Views/Payments/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"58cd435b732e03ae8ce38e487a3c957abe19ef16266bf57672ad4d013d579afc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Payments_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tenant_App.Models.DataObjects.PaymentDtos.PaymentDto>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-right:16px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Payments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetReceipt", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
  
    ViewData["Title"] = ViewBag.ProjectTitle + "::  " + "payment";

    Layout = "~/Views/Shared/_Secured.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>

    .dropdown-menus {
        display: none;
        position: absolute;
        background-color: #fff;
        border: 1px solid #ccc;
        padding: 0rem;
        margin: 0rem;
        list-style: none;
        z-index: 999;
        min-width: 100%
    }

    .dropdowns {
        width: 11.5vw;
        height: 0.5vw;
        position: relative;
        display: inline-block;
    }

    .dropdown-menus li {
        padding: 3px;
        cursor: pointer;
    }

        .dropdown-menus li:hover {
            background-color: #f4f4f4;
        }
</style>


<div class=""container-fluid content-top-gap"">

    <nav aria-label=""breadcrumb"" class=""mb-4"">
        <ol class=""breadcrumb my-breadcrumb"">
            <li class=""breadcrumb-item""><a");
            BeginWriteAttribute("href", " href=\"", 1159, "\"", 1218, 1);
#nullable restore
#line 49 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
WriteAttributeValue("", 1166, Url.Action("Index", "Dashboard", new { area = "" }), 1166, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Dashboard</a></li>\r\n            <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 1282, "\"", 1340, 1);
#nullable restore
#line 50 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
WriteAttributeValue("", 1289, Url.Action("Index", "Payments", new { area = "" }), 1289, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Payments Report</a></li>\r\n");
            WriteLiteral("        </ol>\r\n    </nav>\r\n\r\n    <div class=\"cards__heading\">\r\n        <h3>Payment Reports</h3>\r\n    </div>\r\n\r\n    <div class=\"card card_border p-lg-5 p-3 mb-4\">\r\n        <div class=\"card-body py-3 p-0\">\r\n");
            WriteLiteral(@"            <br /><br />
            <div class=""row"">


                <div class=""table-responsive "">
                    <table data-ordering=""false"" id=""example"" class=""table "" style=""width:100%; background-color: white;"">
                        <thead>
                            <tr>
                                <th class=""sn"">S/N</th>
                                <th class=""r1-col"">RRR</th>
                                <th class=""r1-col"">FullName</th>
                                <th class=""r1-col"">Payment purpose</th>
                                <th class=""r1-col"">Amount</th>
                                <th class=""r1-col"">Transaction Date</th>
                                <th class=""r1-col"">Expiry Date</th>
                                <th class=""r1-col"">Action</th>

                            </tr>
                        </thead>

                        <tbody class=""pl-3"">
");
#nullable restore
#line 87 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                              
                                int rowNo = 0;
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 91 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr class=\"td\">\r\n                                    <td class=\"sn\">");
#nullable restore
#line 94 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                                               Write(rowNo += 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 95 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                                                  Write(item.RRR);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 96 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                                                  Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 97 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                                                  Write(item.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 98 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                                                  Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 99 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                                                  Write(item.PaymentDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 100 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                                                  Write(item.ExpiryDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7ceaaa6df6de4dcc4ab17d32c679bdccb49634908dfb13e51557ab1b91f05d311995", async() => {
                WriteLiteral("\r\n                                            View Receipt\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 102 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                                                                                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 108 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>

                    </table>

                </div>
            </div>
        </div>
    </div>
</div>


<script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js""
        integrity=""sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4""
        crossorigin=""anonymous""></script>
<script src=""https://code.jquery.com/jquery-3.5.1.js""></script>
<script src="" https://cdn.datatables.net/1.13.2/js/jquery.dataTables.min.js""></script>
<script src="" https://cdn.datatables.net/1.13.2/js/dataTables.bootstrap5.min.js""></script>
<script src=""../js/layout.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.0.1/js/dataTables.buttons.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.0.1/js/buttons.html5.min.js""></script>

<script type=""text/javascript"">

    function Create() {
        $(""#inlineForm"").hide();
        $(""#bodycontentPartial""");
            WriteLiteral(").show();\r\n        debugger\r\n        $.ajax({\r\n            type: \'GET\',\r\n            url: \"");
#nullable restore
#line 138 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
             Write(Url.Action("Create", "ContractType"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            success: function (content) {

                $(""#inlineForm"").show();
                console.log(content);
                $(""#bodycontentPartial"").html(content);
            }
        });
    }

    function Edit(id) {
        $(""#inlineForm"").hide();
        $(""#bodycontentPartial"").show();
        // debugger
        $.ajax({
            type: 'GET',
            url: """);
#nullable restore
#line 154 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
             Write(Url.Action("Edit", "ContractType"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            data: { id: id },
            success: function (content) {

                $(""#inlineForm"").show();
                console.log(content);
                $(""#bodycontentPartial"").html(content);
            }
        });
    }

    function Delete(id) {
        console.log(""here"");
        $(""#inlineForm"").hide();
        $(""#bodycontentPartial"").show();
        //debugger
        $.ajax({
            type: 'GET',
            url: """);
#nullable restore
#line 172 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Payments\Index.cshtml"
             Write(Url.Action("Delete", "ContractType"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            data: { id: id },\r\n            success: function (content) {\r\n                $(\"#inlineForm\").show();\r\n                $(\"#bodycontentPartial\").html(content);\r\n            }\r\n        });\r\n    }\r\n</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tenant_App.Models.DataObjects.PaymentDtos.PaymentDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5a51f1acc193785e5dd3484eb6393a1cced7f70ad6ffdc388ac30e867e6e0c76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Property_Index), @"mvc.1.0.view", @"/Views/Property/Index.cshtml")]
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
#line 2 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"5a51f1acc193785e5dd3484eb6393a1cced7f70ad6ffdc388ac30e867e6e0c76", @"/Views/Property/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"58cd435b732e03ae8ce38e487a3c957abe19ef16266bf57672ad4d013d579afc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Property_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tenant_App.Models.DataObjects.PropertyDtos.PropertyDto>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Passport-preview"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("60"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("60"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
  
    ViewData["Title"] = ViewBag.ProjectTitle + "::  " + "Property";

    Layout = "~/Views/Shared/_Secured.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/vanilla-datatables@latest/vanilla-dataTables.min.css"">
<script src=""https://cdn.jsdelivr.net/npm/vanilla-datatables@latest/vanilla-dataTables.min.js""></script>
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
            BeginWriteAttribute("href", " href=\"", 1292, "\"", 1351, 1);
#nullable restore
#line 48 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
WriteAttributeValue("", 1299, Url.Action("Index", "Dashboard", new { area = "" }), 1299, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Dashboard</a></li>\r\n            <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 1415, "\"", 1473, 1);
#nullable restore
#line 49 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
WriteAttributeValue("", 1422, Url.Action("Index", "Property", new { area = "" }), 1422, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Setup</a></li>
            <li class=""breadcrumb-item active"" aria-current=""page"">Manage Properties</li>
        </ol>
    </nav>

    <div class=""cards__heading"">
        <h3>Manage Properties</h3>
    </div>

    <div class=""card card_border p-lg-5 p-3 mb-4"">
        <div class=""card-body py-3 p-0"">
            <div>
                <button onclick=""Create()"" role=""button"" data-toggle=""modal"" data-target=""#centralModalInfo"" id=""addDeptModalOpen"" class=""btn btn-primary btn-style mt-4"">
                    <i class=""fa-solid fa-plus""></i> Add Property
                </button>
            </div>
            <br /><br />
            <div class=""row"">


                <div class=""table-responsive "">
                    <table data-ordering=""false"" id=""example"" class=""table "" style=""width:100%; background-color: white;"">
                        <thead>
                            <tr>
                                <th class=""sn"">S/N</th>
                                <th class=""r1-");
            WriteLiteral("col\">Property Name</th>\r\n                                <th class=\"r1-col\">Shop No.</th>\r\n                                <th class=\"r1-col\">Duration</th>\r\n");
            WriteLiteral("                                <th class=\"r1-col\">Image</th>\r\n                                <th class=\"r1-col\">Actions</th>\r\n\r\n                            </tr>\r\n                        </thead>\r\n\r\n                        <tbody class=\"pl-3\">\r\n");
#nullable restore
#line 85 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
                              
                                int rowNo = 0;
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 89 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr class=\"td\">\r\n                                    <td class=\"sn\">");
#nullable restore
#line 92 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
                                               Write(rowNo += 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 93 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
                                                  Write(item.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 94 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
                                                  Write(item.RoomNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 95 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
                                                  Write(item.DurationAllowed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                                    <td class=\"r1-col\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5a51f1acc193785e5dd3484eb6393a1cced7f70ad6ffdc388ac30e867e6e0c7611872", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3744, "~/", 3744, 2, true);
#nullable restore
#line 98 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
AddHtmlAttributeValue("", 3746, item.PropertyImage, 3746, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral(@"                                    </td>
                                    <td class=""r1-col"" id=""date_row"">
                                        <div class=""dropdowns"">
                                            <i class=""fa-solid fa-ellipsis-vertical""></i>
                                            <ul class=""dropdown-menus"">

                                                <li data-value=""edit"" data-id=""");
#nullable restore
#line 106 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
                                                                          Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" role=""button"" data-toggle=""modal"" data-target=""#centralModalInfo"" class='editAction' id=""editDepartment"">
                                                    <i class=""fa fa-edit""></i> Edit
                                                </li>
                                                <li data-value=""delete"" data-id=""");
#nullable restore
#line 109 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
                                                                            Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" role=""button"" data-toggle=""modal"" data-target=""#centralModalInfo"" class=""editAction"" id=""deleteDepartment"">
                                                    <i class=""fa fa-trash""></i> Delete
                                                </li>
                                                
                                            </ul>
                                        </div>
                                    </td>
                                </tr>
");
#nullable restore
#line 117 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>

                    </table>
                    <div class=""modal item-fade text-left"" id=""inlineForm"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel17"" aria-hidden=""true"">
                        <div class=""modal-dialog modal-dialog-centered modal-lg"" role=""document"" ");
            WriteLiteral(">\r\n                            <!-- Modal content -->\r\n");
            WriteLiteral("                                <div class=\"modal-content\" id=\"bodycontentPartial\">\r\n                                </div>\r\n");
            WriteLiteral(@"                        </div>
                    </div>
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
        $(""#bodycontentPartial"").show();
   ");
            WriteLiteral("     debugger\r\n        $.ajax({\r\n            type: \'GET\',\r\n            url: \"");
#nullable restore
#line 157 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
             Write(Url.Action("Create", "Property"));

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
        debugger
        $.ajax({
            type: 'GET',
            url: """);
#nullable restore
#line 173 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
             Write(Url.Action("Edit", "Property"));

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
#line 191 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Property\Index.cshtml"
             Write(Url.Action("Delete", "Property"));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tenant_App.Models.DataObjects.PropertyDtos.PropertyDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

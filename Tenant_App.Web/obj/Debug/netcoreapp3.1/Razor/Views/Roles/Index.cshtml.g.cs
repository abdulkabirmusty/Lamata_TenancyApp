#pragma checksum "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b4c0181ebcf6963d1074f0edd417cbc084a6bad4cc9c4fb8eb485f971952cd51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Roles_Index), @"mvc.1.0.view", @"/Views/Roles/Index.cshtml")]
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
#line 1 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b4c0181ebcf6963d1074f0edd417cbc084a6bad4cc9c4fb8eb485f971952cd51", @"/Views/Roles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"58cd435b732e03ae8ce38e487a3c957abe19ef16266bf57672ad4d013d579afc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Roles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-right:16px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Permission", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
  
    ViewData["Title"] = ViewBag.ProjectTitle + "::  " + "Role Management";

    Layout = "~/Views/Shared/_Secured.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<style type=""text/css"">
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
            BeginWriteAttribute("href", " href=\"", 1019, "\"", 1078, 1);
#nullable restore
#line 47 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
WriteAttributeValue("", 1026, Url.Action("Index", "Dashboard", new { area = "" }), 1026, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Dashboard</a></li>\r\n            <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 1142, "\"", 1208, 1);
#nullable restore
#line 48 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
WriteAttributeValue("", 1149, Url.Action("Index", "IndividualTenant", new { area = "" }), 1149, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Tenants</a></li>
            <li class=""breadcrumb-item active"" aria-current=""page"">Manage Tenants</li>
        </ol>
    </nav>

    <div class=""cards__heading"">
        <h3>Manage Roles/Permissions</h3>
    </div>

    <div class=""card card_border p-lg-5 p-3 mb-4"">
        <div class=""card-body py-3 p-0"">
");
            WriteLiteral(@"            <br /><br />
            <div class=""row"">


                <div class=""table-responsive "">
                    <table data-ordering=""false"" id=""example"" class=""table "" style=""width:100%; background-color: white;"">
                        <thead>
                            <tr>
                                <th>S/N</th>
                                <th>Role</th>
                                <th>Actions</th>

                            </tr>
                        </thead>

                        <tbody class=""pl-3"">
");
#nullable restore
#line 86 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
                              
                                int rowNo = 0;
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 90 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
                             foreach (var role in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr class=\"td\">\r\n                                    <td>");
#nullable restore
#line 93 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
                                    Write(rowNo += 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 95 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
                                   Write(role.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </td>
                                    <td id=""date_row"">

                                        <div class=""dropdowns"">
                                            <i class=""fa-solid fa-ellipsis-vertical""></i>
                                            <ul class=""dropdown-menus"">
");
            WriteLiteral("                                                <li data-value=\"delete\" data-id=\"\" role=\"button\" data-toggle=\"modal\" data-target=\"#centralModalInfo\" class=\'editAction\' id=\"deleteDepartment\">\r\n");
#nullable restore
#line 109 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
                                                     if (role.Name != "Admin")
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b4c0181ebcf6963d1074f0edd417cbc084a6bad4cc9c4fb8eb485f971952cd5111008", async() => {
                WriteLiteral("\r\n                                                            <i class=\"fas fa-user-gear\"></i> Manage Permissions\r\n                                                        ");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-roleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 111 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
                                                                                                                                          WriteLiteral(role.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-roleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 114 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </li>\r\n                                            </ul>\r\n                                        </div>\r\n\r\n                                    </td>\r\n\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 123 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\Roles\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n   ");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

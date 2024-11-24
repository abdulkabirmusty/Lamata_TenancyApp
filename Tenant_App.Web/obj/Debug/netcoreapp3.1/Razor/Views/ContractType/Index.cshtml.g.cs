#pragma checksum "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4543f624fb8a1585a622a379b9307e5c08b9d8c576fde45252ec07e2abe0dba9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContractType_Index), @"mvc.1.0.view", @"/Views/ContractType/Index.cshtml")]
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
#line 4 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4543f624fb8a1585a622a379b9307e5c08b9d8c576fde45252ec07e2abe0dba9", @"/Views/ContractType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"58cd435b732e03ae8ce38e487a3c957abe19ef16266bf57672ad4d013d579afc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ContractType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tenant_App.Models.DataObjects.ContractTypeDtos.ContractTypeDto>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
  
    ViewData["Title"] = ViewBag.ProjectTitle + "::  " + "Contract Type";

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
            BeginWriteAttribute("href", " href=\"", 1179, "\"", 1238, 1);
#nullable restore
#line 49 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
WriteAttributeValue("", 1186, Url.Action("Index", "Dashboard", new { area = "" }), 1186, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Dashboard</a></li>\r\n            <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 1302, "\"", 1364, 1);
#nullable restore
#line 50 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
WriteAttributeValue("", 1309, Url.Action("Index", "ContractType", new { area = "" }), 1309, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Setup</a></li>
            <li class=""breadcrumb-item active"" aria-current=""page"">Manage Contract Type</li>
        </ol>
    </nav>

    <div class=""cards__heading"">
        <h3>Manage Contract Type</h3>
    </div>

    <div class=""card card_border p-lg-5 p-3 mb-4"">
        <div class=""card-body py-3 p-0"">
            <div>
                <button onclick=""Create()"" role=""button"" data-toggle=""modal"" data-target=""#centralModalInfo"" id=""addDeptModalOpen"" class=""btn btn-primary btn-style mt-4"">
                    <i class=""fa-solid fa-plus""></i> Add Contract Type
                </button>
            </div>
            <br /><br />
            <div class=""row"">


                <div class=""table-responsive "">
                    <table data-ordering=""false"" id=""example"" class=""table "" style=""width:100%; background-color: white;"">
                        <thead>
                            <tr>
                                <th class=""sn"">S/N</th>
                                <th");
            WriteLiteral(" class=\"r1-col\">Contract Type</th>\r\n                                <th class=\"r1-col\">Actions</th>\r\n\r\n                            </tr>\r\n                        </thead>\r\n\r\n                        <tbody class=\"pl-3\">\r\n");
#nullable restore
#line 82 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
                              
                                int rowNo = 0;
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 86 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr class=\"td\">\r\n                                    <td class=\"sn\">");
#nullable restore
#line 89 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
                                               Write(rowNo += 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"r1-col\">");
#nullable restore
#line 90 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                    <td class=""r1-col"" id=""date_row"">
                                        <div class=""dropdowns"">
                                            <i class=""fa-solid fa-ellipsis-vertical""></i>
                                            <ul class=""dropdown-menus"">

                                                <li data-value=""edit"" data-id=""");
#nullable restore
#line 96 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
                                                                          Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" role=""button"" data-toggle=""modal"" data-target=""#centralModalInfo"" class='editAction' id=""editDepartment"">
                                                    <i class=""fa fa-edit""></i> Edit
                                                </li>
                                                <li data-value=""delete"" data-id=""");
#nullable restore
#line 99 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
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
#line 106 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>

                    </table>
                    <div class=""modal item-fade text-left"" id=""inlineForm"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel17"" aria-hidden=""true"">
                        <div class=""modal-dialog modal-dialog-centered modal-dialog-scrollable"" role=""document"">
                            <!-- Modal content -->
                            <div class=""modal-dialog modal-lg"" role=""document"" style=""box-shadow: 0 6px 12px rgba(0, 0, 0, 0.1);"">
");
            WriteLiteral(@"                                <div class=""modal-content"" id=""bodycontentPartial"">
                                </div>
                            </div>
                        </div>
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
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.0.1/js/but");
            WriteLiteral("tons.html5.min.js\"></script>\r\n\r\n<script type=\"text/javascript\">\r\n\r\n    function Create() {\r\n        $(\"#inlineForm\").hide();\r\n        $(\"#bodycontentPartial\").show();\r\n        debugger\r\n        $.ajax({\r\n            type: \'GET\',\r\n            url: \"");
#nullable restore
#line 147 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
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
#line 163 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
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
#line 181 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\ContractType\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tenant_App.Models.DataObjects.ContractTypeDtos.ContractTypeDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
#pragma checksum "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\CustomAccount\viewAmount.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a04566d9f4db563cf8fc2df65ce89ec4dc8e3164ea5759e69fc169aabcb3c1ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CustomAccount_viewAmount), @"mvc.1.0.view", @"/Views/CustomAccount/viewAmount.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a04566d9f4db563cf8fc2df65ce89ec4dc8e3164ea5759e69fc169aabcb3c1ba", @"/Views/CustomAccount/viewAmount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"58cd435b732e03ae8ce38e487a3c957abe19ef16266bf57672ad4d013d579afc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_CustomAccount_viewAmount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tenant_App.Models.DataObjects.Account.RegPaymentDto>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "InitiateAndConfirmPayment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Payment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("msform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\CustomAccount\viewAmount.cshtml"
  
	ViewData["Title"] = "Cooperate Tenant Register";
	Layout = "~/Views/Shared/_contestantReg.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css"" rel=""stylesheet"">
<script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js""></script>

<div Class=""container"">
	<h2 id=""heading"">Payment details</h2>
	<p>Confirm your details before making registartion payment</p>
	<div class=""container-fluid"">
		<button class=""cancel-button"" onclick=""cancelRegistration()"">
			<i class=""fas fa-times""></i>
		</button>
		<div class=""row justify-content-center"">
			<div class=""card "" style=""width: 72vw;"">
				<button onclick=""goBack()"" role=""button"" class=""btn py-2 px-4 text-1vw"" style=""color: #707070;"">
					<i class=""fa-solid fa-arrow-left""></i> Go Back
				</button>
				");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a04566d9f4db563cf8fc2df65ce89ec4dc8e3164ea5759e69fc169aabcb3c1ba6664", async() => {
                WriteLiteral("\r\n\t\t\t\t\t<input name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 1038, "\"", 1059, 1);
#nullable restore
#line 23 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\CustomAccount\viewAmount.cshtml"
WriteAttributeValue("", 1046, Model.UserId, 1046, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"hidden\"/>\r\n\t\t\t\t\t<p>Full name : ");
#nullable restore
#line 24 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\CustomAccount\viewAmount.cshtml"
                              Write(Model.FullName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n\t\t\t\t\t<p>Email : ");
#nullable restore
#line 25 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\CustomAccount\viewAmount.cshtml"
                          Write(Model.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\t\t\t\t\t<p>Amount : ");
#nullable restore
#line 26 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\CustomAccount\viewAmount.cshtml"
                           Write(Model.Amount);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p> \r\n\t\t\t\t\t<input name=\"amount\"");
                BeginWriteAttribute("value", " value=\"", 1217, "\"", 1238, 1);
#nullable restore
#line 27 "C:\Users\AbdulkabirAbdulwasiu\Documents\Lamata_TenantApp\Tenant_App\Tenant_App.Web\Views\CustomAccount\viewAmount.cshtml"
WriteAttributeValue("", 1225, Model.Amount, 1225, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"hidden\" />\r\n\t\t\t\t\t<button type=\"submit\" style=\"btn btn-success\">Make Payment</button>\r\n\t\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n<script>\r\n\tfunction goBack() {\r\n\t\twindow.location.href = \"/Home/Index\";\r\n\t}\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tenant_App.Models.DataObjects.Account.RegPaymentDto> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
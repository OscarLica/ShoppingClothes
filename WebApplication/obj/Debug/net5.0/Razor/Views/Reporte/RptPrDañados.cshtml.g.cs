#pragma checksum "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ac51e77d61796418c5c002387dfbd34a6fa1e3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reporte_RptPrDañados), @"mvc.1.0.view", @"/Views/Reporte/RptPrDañados.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ac51e77d61796418c5c002387dfbd34a6fa1e3a", @"/Views/Reporte/RptPrDañados.cshtml")]
    public class Views_Reporte_RptPrDañados : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DataEntities.ReporteProductos>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ac51e77d61796418c5c002387dfbd34a6fa1e3a3896", async() => {
                WriteLiteral("\r\n    <title> Reporte de productos dañados</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4ac51e77d61796418c5c002387dfbd34a6fa1e3a4210", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ac51e77d61796418c5c002387dfbd34a6fa1e3a6092", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""row justify-content-start text-center"">
            <h1 class=""text-info"">Reporte de productos dañados</h1>
            <span>PALLA'S STORE</span>
        </div>
        <table class=""table table-hover table-active"">
            <thead>
                <tr>
                    <th>Producto</th>
                    <th>Marca</th>
                    <th>Talla</th>
                    <th>Color</th>
                    <th>Detalle Ingreso</th>
                    <th>Detalle Salida</th>
                    <th>Fecha Ingreso</th>
                    <th>Fecha Salida</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 31 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr class=\"text-center\">\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                       Write(item.Producto);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                       Write(item.Marca);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                       Write(item.Talla);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 37 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                       Write(item.Color);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 38 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                       Write(item.DescripcionIngreso);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 39 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                       Write(item.DescripcionSalida);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 41 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                              
                                if (item.FechaIngreso.HasValue)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <span>");
#nullable restore
#line 44 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                                     Write(item.FechaIngreso.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 45 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                                }

                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <span>---</span>\r\n");
#nullable restore
#line 50 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 54 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                              
                                if (item.FechaSalida.HasValue)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <span>");
#nullable restore
#line 57 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                                     Write(item.FechaSalida.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral(";</span>\r\n");
#nullable restore
#line 58 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                                }

                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <span>---</span>\r\n");
#nullable restore
#line 63 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 67 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Views\Reporte\RptPrDañados.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DataEntities.ReporteProductos>> Html { get; private set; }
    }
}
#pragma warning restore 1591

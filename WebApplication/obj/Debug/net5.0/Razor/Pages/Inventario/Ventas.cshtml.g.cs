#pragma checksum "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6a2e78a44deb124ba90aad8110c49c6e2b53e5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication.Pages.Inventario.Pages_Inventario_Ventas), @"mvc.1.0.razor-page", @"/Pages/Inventario/Ventas.cshtml")]
namespace WebApplication.Pages.Inventario
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\_ViewImports.cshtml"
using WebApplication.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6a2e78a44deb124ba90aad8110c49c6e2b53e5c", @"/Pages/Inventario/Ventas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84408ba84c9e3bdbcfa44baf57646e5398341b63", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Inventario_Ventas : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Inventario/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Inventario/Ventas"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Inventario/General"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6a2e78a44deb124ba90aad8110c49c6e2b53e5c4561", async() => {
                WriteLiteral("Inventario compras");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n        <li class=\"breadcrumb-item active\" aria-current=\"page\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6a2e78a44deb124ba90aad8110c49c6e2b53e5c5720", async() => {
                WriteLiteral("Inventario ventas");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n        <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6a2e78a44deb124ba90aad8110c49c6e2b53e5c6849", async() => {
                WriteLiteral("Inventario general");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n    </ol>\r\n</nav>\r\n\r\n");
#nullable restore
#line 13 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
 foreach (var grupoInv in Model.Inventario.GroupBy(x => new { x.NoFactura, x.Fecha }).Select(y => new { NoFactura = y.Key.NoFactura, Fecha = y.Key.Fecha, Productos = y.ToList() }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h3>Factura : ");
#nullable restore
#line 17 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                     Write(grupoInv.NoFactura);

#line default
#line hidden
#nullable disable
            WriteLiteral("   Fecha : ");
#nullable restore
#line 17 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                                                   Write(grupoInv.Fecha.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
        </div>
        <div class=""col-md-12"">
            <table class=""table"">
                <thead>
                    <tr>
                        <th>
                            Producto
                        </th>
                        <th>
                            Marca
                        </th>
                        <th>
                            Talla
                        </th>
                        <th>
                            Color
                        </th>
                        <th>
                            Precio venta
                        </th>
                        <th>
                            Cantidad
                        </th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 44 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                     foreach (var item in grupoInv.Productos.ToList())
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 48 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                           Write(item.NombreProducto);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 51 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                           Write(item.Marca);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 54 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                           Write(item.Talla);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 57 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                           Write(item.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                C$ ");
#nullable restore
#line 60 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                              Write(item.Precio.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 63 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                           Write(item.Cantidad);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 66 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n                <tfoot>\r\n                    <tr>\r\n                        <td></td>\r\n                        <td></td>\r\n                        <td></td>\r\n                        <td>Total</td>\r\n                        <td>C$ ");
#nullable restore
#line 74 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
                          Write(grupoInv.Productos.Sum(x => x.Precio).ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td></td>\r\n                    </tr>\r\n                </tfoot>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 81 "C:\Users\Oscar Jimenez\Downloads\Clothing13\WebApplication\Pages\Inventario\Ventas.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication.Pages.Inventario.VentasModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication.Pages.Inventario.VentasModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication.Pages.Inventario.VentasModel>)PageContext?.ViewData;
        public WebApplication.Pages.Inventario.VentasModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
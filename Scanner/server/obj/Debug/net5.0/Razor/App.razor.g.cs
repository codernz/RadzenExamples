#pragma checksum "C:\Data\Radzen\Scanner\server\App.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b653e8b0849f6f60ceb11ad6bcebe878f65f9b25"
// <auto-generated/>
#pragma warning disable 1591
namespace Scanner
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Data\Radzen\Scanner\server\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Data\Radzen\Scanner\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Data\Radzen\Scanner\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Data\Radzen\Scanner\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Data\Radzen\Scanner\server\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Data\Radzen\Scanner\server\_Imports.razor"
using Scanner.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Data\Radzen\Scanner\server\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
    public partial class App : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.Router>(0);
            __builder.AddAttribute(1, "AppAssembly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Reflection.Assembly>(
#nullable restore
#line 5 "C:\Data\Radzen\Scanner\server\App.razor"
                     typeof(Startup).Assembly

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "Found", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.RouteData>)((routeData) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.RouteView>(3);
                __builder2.AddAttribute(4, "RouteData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.RouteData>(
#nullable restore
#line 7 "C:\Data\Radzen\Scanner\server\App.razor"
                                  routeData

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(5, "DefaultLayout", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Type>(
#nullable restore
#line 7 "C:\Data\Radzen\Scanner\server\App.razor"
                                                            typeof(MainLayout)

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.AddAttribute(6, "NotFound", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.LayoutView>(7);
                __builder2.AddAttribute(8, "Layout", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Type>(
#nullable restore
#line 10 "C:\Data\Radzen\Scanner\server\App.razor"
                            typeof(MainLayout)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(10, "<h1>Page not found</h1>\n            ");
                    __builder3.AddMarkupContent(11, "<p>Sorry, but there\'s nothing here!</p>");
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591

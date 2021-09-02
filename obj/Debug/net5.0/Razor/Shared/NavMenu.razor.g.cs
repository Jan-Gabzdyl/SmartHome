#pragma checksum "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50572f3229bf5417a19e5ee0ef08d646f15db36c"
// <auto-generated/>
#pragma warning disable 1591
namespace SmartHome.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/pi/Desktop/SmartHome/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/pi/Desktop/SmartHome/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/pi/Desktop/SmartHome/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/pi/Desktop/SmartHome/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/pi/Desktop/SmartHome/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/pi/Desktop/SmartHome/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/pi/Desktop/SmartHome/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/pi/Desktop/SmartHome/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/pi/Desktop/SmartHome/_Imports.razor"
using SmartHome;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/pi/Desktop/SmartHome/_Imports.razor"
using SmartHome.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/home/pi/Desktop/SmartHome/_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/home/pi/Desktop/SmartHome/_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
using SmartHome.Bluetooth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
using SmartHome.Bluetooth.Devices;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddAttribute(2, "b-s87hrsxfl6");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href b-s87hrsxfl6>SmartHome</a>\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "b-s87hrsxfl6");
            __builder.AddMarkupContent(8, "<span class=\"navbar-toggler-icon\" b-s87hrsxfl6></span>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", 
#nullable restore
#line 12 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "b-s87hrsxfl6");
            __builder.OpenElement(14, "ul");
            __builder.AddAttribute(15, "class", "nav flex-column");
            __builder.AddAttribute(16, "b-s87hrsxfl6");
            __builder.OpenElement(17, "li");
            __builder.AddAttribute(18, "class", "nav-item px-3");
            __builder.AddAttribute(19, "b-s87hrsxfl6");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(20);
            __builder.AddAttribute(21, "class", "nav-link");
            __builder.AddAttribute(22, "href", "");
            __builder.AddAttribute(23, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 15 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
                                                     NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(25, "<span class=\"oi oi-bluetooth\" aria-hidden=\"true\" b-s87hrsxfl6></span> Bluetooth\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 19 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
         if (allDevices.TemperatureSensors.Count>0)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(26, "li");
            __builder.AddAttribute(27, "class", "nav-item px-3");
            __builder.AddAttribute(28, "b-s87hrsxfl6");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(29);
            __builder.AddAttribute(30, "class", "nav-link");
            __builder.AddAttribute(31, "href", "temperature-sensors");
            __builder.AddAttribute(32, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(33, "<span class=\"oi oi-cloudy\" aria-hidden=\"true\" b-s87hrsxfl6></span> Czujniki temperatury\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 26 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
          if (allDevices.LightSwitches.Count>0)
         {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(34, "li");
            __builder.AddAttribute(35, "class", "nav-item px-3");
            __builder.AddAttribute(36, "b-s87hrsxfl6");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(37);
            __builder.AddAttribute(38, "class", "nav-link");
            __builder.AddAttribute(39, "href", "light-switches");
            __builder.AddAttribute(40, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(41, "<span class=\"oi oi-lightbulb\" aria-hidden=\"true\" b-s87hrsxfl6></span> Włączniki światła\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 34 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
         }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 38 "/home/pi/Desktop/SmartHome/Shared/NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AllDevices allDevices { get; set; }
    }
}
#pragma warning restore 1591
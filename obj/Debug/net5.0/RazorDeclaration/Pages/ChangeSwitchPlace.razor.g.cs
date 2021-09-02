// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SmartHome.Pages
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
#line 1 "/home/pi/Desktop/SmartHome/Pages/ChangeSwitchPlace.razor"
using SmartHome.Bluetooth.Devices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/pi/Desktop/SmartHome/Pages/ChangeSwitchPlace.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
    public partial class ChangeSwitchPlace : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 19 "/home/pi/Desktop/SmartHome/Pages/ChangeSwitchPlace.razor"
 

    class Form
    {
        [Required(ErrorMessage = "To pole nie może być puste")]
        [StringLength(50, ErrorMessage = "Podana nazwa jest za długa")]
        public string Place { get; set; }
    }

    [CascadingParameter] BlazoredModalInstance ModalInstance { get; set; }
    [Parameter] public TemperatureSensor temperatureSensor { get; set; }

    private Form form = new Form();

    protected async override Task OnInitializedAsync()
    {
        form.Place = temperatureSensor.Place;
        StateHasChanged();
    }

    private async void HandleValidSubmit()
    {
        temperatureSensor.Place = form.Place;
        await ModalInstance.CloseAsync();
    }

    private void CancelClick()
    {
        ModalInstance.CancelAsync();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591

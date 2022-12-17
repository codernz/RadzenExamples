using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Lakes.Models.LakeData;
using Microsoft.EntityFrameworkCore;

namespace Lakes.Pages
{
    public partial class HomeComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected LakeDataService LakeData { get; set; }

        IEnumerable<Lakes.Models.LakeData.VwPlace> _LakeResult;
        protected IEnumerable<Lakes.Models.LakeData.VwPlace> LakeResult
        {
            get
            {
                return _LakeResult;
            }
            set
            {
                if (!object.Equals(_LakeResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "LakeResult", NewValue = value, OldValue = _LakeResult };
                    _LakeResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var lakeDataGetVwPlacesResult = await LakeData.GetVwPlaces();
            LakeResult = lakeDataGetVwPlacesResult;
        }
    }
}

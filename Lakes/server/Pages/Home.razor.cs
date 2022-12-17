using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.JSInterop;

namespace Lakes.Pages
{
    public partial class HomeComponent
    {
        public RadzenGoogleMap map { get; set; }


        protected override void OnAfterRender(bool firstRender)
        {
            if (map != null && firstRender)
            {
                var t = Task.Run(async delegate
                {
                   
                    await Task.Delay(1000);
                    await DisplayLakesAsync();
                });
            }
        }
        private async Task DisplayLakesAsync()
        {
          
         //   await JSRuntime.InvokeVoidAsync("clearMap", map.UniqueID);

            foreach (var lake in LakeResult)
            {


                 

                string content = $"<strong>Lake: </strong>{lake.PlaceName}<p><p><strong>";
                await JSRuntime.InvokeVoidAsync("drawPolygon", lake.Area,  map.UniqueID, content);



            }


        }


    }
}

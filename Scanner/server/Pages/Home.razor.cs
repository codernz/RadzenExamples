using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using BlazorBarcodeScanner.ZXing.JS;

namespace Scanner.Pages
{
    public partial class HomeComponent
    {

        public BarcodeReader _reader;
        public void LocalReceivedBarcodeText(BarcodeReceivedEventArgs args)
        {
            Code = args.BarcodeText;
            StateHasChanged();
        }
    }
}

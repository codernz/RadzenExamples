using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using ImportCsvFiles.Models.CsvImportExample;
using Microsoft.EntityFrameworkCore;

namespace ImportCsvFiles.Pages
{
    public partial class ImportFileComponent : ComponentBase
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
        protected CsvImportExampleService CsvImportExample { get; set; }
        protected RadzenDataList<ImportCsvFiles.Models.Mappings> datalist0;

        List<string> _fieldNames;
        protected List<string> fieldNames
        {
            get
            {
                return _fieldNames;
            }
            set
            {
                if (!object.Equals(_fieldNames, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "fieldNames", NewValue = value, OldValue = _fieldNames };
                    _fieldNames = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<ImportCsvFiles.Models.Mappings> _ImportFields;
        protected IEnumerable<ImportCsvFiles.Models.Mappings> ImportFields
        {
            get
            {
                return _ImportFields;
            }
            set
            {
                if (!object.Equals(_ImportFields, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "ImportFields", NewValue = value, OldValue = _ImportFields };
                    _ImportFields = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string[] _csvFile;
        protected string[] csvFile
        {
            get
            {
                return _csvFile;
            }
            set
            {
                if (!object.Equals(_csvFile, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "csvFile", NewValue = value, OldValue = _csvFile };
                    _csvFile = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _BeforeFileisImported;
        protected bool BeforeFileisImported
        {
            get
            {
                return _BeforeFileisImported;
            }
            set
            {
                if (!object.Equals(_BeforeFileisImported, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "BeforeFileisImported", NewValue = value, OldValue = _BeforeFileisImported };
                    _BeforeFileisImported = value;
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
            fieldNames = new List<string>();

            ImportFields = new List<ImportCsvFiles.Models.Mappings>().AsEnumerable() ;

            csvFile = new string[0];

            BeforeFileisImported = true;
        }

        protected async System.Threading.Tasks.Task Upload0Complete(UploadCompleteEventArgs args)
        {
            fieldNames = (System.Text.Json.JsonSerializer.Deserialize<string[]>(args.JsonResponse.RootElement.GetProperty("fieldNames").GetRawText())).ToList<string>();
ImportFields = (System.Text.Json.JsonSerializer.Deserialize<Models.Mappings[]>(args.JsonResponse.RootElement.GetProperty("map").GetRawText(), new System.Text.Json.JsonSerializerOptions
          {
              PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
          })).ToList<Models.Mappings>();
          
csvFile = (System.Text.Json.JsonSerializer.Deserialize<string[]>(args.JsonResponse.RootElement.GetProperty("csvFile").GetRawText()));          

BeforeFileisImported=false;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            getDatabaseFields(',');
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            ClearFields();
        }
    }
}

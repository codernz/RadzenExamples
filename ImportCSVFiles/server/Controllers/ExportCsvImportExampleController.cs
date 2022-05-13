using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImportCsvFiles.Data;

namespace ImportCsvFiles
{
    public partial class ExportCsvImportExampleController : ExportController
    {
        private readonly CsvImportExampleContext context;

        public ExportCsvImportExampleController(CsvImportExampleContext context)
        {
            this.context = context;
        }
        [HttpGet("/export/CsvImportExample/customers/csv")]
        [HttpGet("/export/CsvImportExample/customers/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCustomersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Customers, Request.Query), fileName);
        }

        [HttpGet("/export/CsvImportExample/customers/excel")]
        [HttpGet("/export/CsvImportExample/customers/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCustomersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Customers, Request.Query), fileName);
        }
        [HttpGet("/export/CsvImportExample/customersstagings/csv")]
        [HttpGet("/export/CsvImportExample/customersstagings/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCustomersStagingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.CustomersStagings, Request.Query), fileName);
        }

        [HttpGet("/export/CsvImportExample/customersstagings/excel")]
        [HttpGet("/export/CsvImportExample/customersstagings/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCustomersStagingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.CustomersStagings, Request.Query), fileName);
        }
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lakes.Data;

namespace Lakes
{
    public partial class ExportLakeDataController : ExportController
    {
        private readonly LakeDataContext context;
        private readonly LakeDataService service;
        public ExportLakeDataController(LakeDataContext context, LakeDataService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/LakeData/vwplaces/csv")]
        [HttpGet("/export/LakeData/vwplaces/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportVwPlacesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetVwPlaces(), Request.Query), fileName);
        }

        [HttpGet("/export/LakeData/vwplaces/excel")]
        [HttpGet("/export/LakeData/vwplaces/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportVwPlacesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetVwPlaces(), Request.Query), fileName);
        }
    }
}

using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using System.Linq;
using System.Collections.Generic;
using ImportCsvFiles.Models.CsvImportExample;
using Radzen;


using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ImportCsvFiles
{
    public partial class UploadController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public UploadController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        // Single file upload
        [HttpPost("upload/single")]
        public IActionResult Single(IFormFile file)
        {
            string[] csvFile = null;
            string[] headers = null;
            List<Models.Mappings> Map = new List<Models.Mappings>();

            //Get the Fields in the table Customer

            var fieldNames = new Customer().GetType().GetProperties().Select(p => p.Name).ToList();

            //Add a "None"  to the start of the csv field list , this is used as the default value
            fieldNames.Insert(0, "None");
            try
            {
                //Code for importing a csv

                if (file.FileName.EndsWith(".csv"))
                {
                    using (var sreader = new StreamReader(file.OpenReadStream()))
                    {
                        // Read file into a string array
                        csvFile = sreader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                }
                                    }
                ////Future code to import a spreadsheet
                if (file.FileName.EndsWith(".xlsx"))
                {
                    List<string> Linelist = new List<string>();

                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(file.OpenReadStream(), false))
                    {
                        Sheet sheet = doc.WorkbookPart.Workbook.Descendants<Sheet>().ElementAt(0);
                        Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                        string line = "";

                        foreach (Row row in worksheet.Descendants<Row>())
                        {
                                                      foreach (Cell c in row.Elements<Cell>())
                            {
                                var cellValue = c.CellValue;
                                var text = (cellValue == null) ? c.InnerText : cellValue.Text;
                                if ((c.DataType != null) && (c.DataType == CellValues.SharedString))
                                {
                                    text = doc.WorkbookPart.SharedStringTablePart.SharedStringTable
                                        .Elements<SharedStringItem>().ElementAt(
                                            Convert.ToInt32(c.CellValue.Text)).InnerText;
                                }
                                line += (text ?? string.Empty).Trim() + ",";
                            }

                            Linelist.Add(line);
                            line = "";
                                        }
                        doc.Close();
                        csvFile = Linelist.ToArray();
                    }
                }

                if (csvFile.Length != 0)
                {
                    
                    int i = 0;
                    // Get the header row of the CSV file and put it in an array
                    headers = csvFile[0].Split(',');
                    // Match CSV header to database Field names if possible
                    foreach (string line in headers)
                    {
                        if (line.Length != 0)
                        {
                            Models.Mappings m = new Models.Mappings();
                            m.Position = i;
                            m.CSVField = line;
                            m.DatabaseField = fieldNames.Where(f => f.Contains(line)).DefaultIfEmpty("None").FirstOrDefault();
                            Map.Add(m);
                            i++;
                        }
                    }

                }
                // Return values back to the program
                return Ok(new { map = Map, fieldNames = fieldNames, csvFile = csvFile });
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        // Multiple files upload
        [HttpPost("upload/multiple")]
        public IActionResult Multiple(IFormFile[] files)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Multiple files upload with parameter
        [HttpPost("upload/{id}")]
        public IActionResult Post(IFormFile[] files, int id)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Image file upload (used by HtmlEditor components)
        [HttpPost("upload/image")]
        public IActionResult Image(IFormFile file)
        {
            try
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                using (var stream = new FileStream(Path.Combine(environment.WebRootPath, fileName), FileMode.Create))
                {
                    // Save the file
                    file.CopyTo(stream);

                    // Return the URL of the file
                    var url = Url.Content($"~/{fileName}");

                    return Ok(new { Url = url });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

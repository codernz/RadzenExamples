using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace ImportCsvFiles.Pages
{
    public partial class ImportFileComponent
    {







        public void getDatabaseFields(char separator = ',')
        {

            bool FirstLine = true;
            foreach (string line in csvFile)
            {
                // Don't import Header
                if (!FirstLine)
                {
                    // 
                    string[] values = line.Split(separator);
                    // New Customers_Staging record
                    Models.CsvImportExample.CustomersStaging table = new Models.CsvImportExample.CustomersStaging();

                    foreach (Models.Mappings field in ImportFields)
                    {

                        if (field.CSVField != "None")
                        {
                            switch (field.DatabaseField)
                            {
                                case "City":
                                    table.City = values[field.Position];
                                    break;
                                case "Country":
                                    table.Country = values[field.Position];
                                    break;
                                case "Company":
                                    table.Company = values[field.Position];
                                    break;
                                case "EmailAddress":
                                    table.EmailAddress = values[field.Position];
                                    break;
                                case "Gender":
                                    table.Gender = values[field.Position];
                                    break;
                                case "GivenName":
                                    table.GivenName = values[field.Position];
                                    break;

                                case "MiddleInitial":
                                    table.MiddleInitial = values[field.Position];
                                    break;
                                case "StreetAddress":
                                    table.StreetAddress = values[field.Position];
                                    break;
                                case "Surname":
                                    table.Surname = values[field.Position];
                                    break;
                                case "Title":
                                    table.Title = values[field.Position];
                                    break;

                                case "ZipCode":
                                    table.ZipCode = int.Parse(values[field.Position]);
                                    break;
                                default:

                                    break;
                            }
                        }
                    }
                    _ = CsvImportExample.CreateCustomersStaging(table);

                }
                FirstLine = false;
            }
            //Run the stored procedure
            _ = CsvImportExample.UspCustomerUpdates();
    ClearFields();
        }
        public void ClearFields()
        {
            BeforeFileisImported = true;
            csvFile = null;
            ImportFields = new List<Models.Mappings>();

            StateHasChanged();
        }

    }
}

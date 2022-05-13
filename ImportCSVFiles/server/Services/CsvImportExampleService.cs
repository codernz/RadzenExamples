using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using ImportCsvFiles.Data;

namespace ImportCsvFiles
{
    public partial class CsvImportExampleService
    {
        CsvImportExampleContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly CsvImportExampleContext context;
        private readonly NavigationManager navigationManager;

        public CsvImportExampleService(CsvImportExampleContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task ExportCustomersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/csvimportexample/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/csvimportexample/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCustomersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/csvimportexample/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/csvimportexample/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCustomersRead(ref IQueryable<Models.CsvImportExample.Customer> items);

        public async Task<IQueryable<Models.CsvImportExample.Customer>> GetCustomers(Query query = null)
        {
            var items = Context.Customers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCustomersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomerCreated(Models.CsvImportExample.Customer item);
        partial void OnAfterCustomerCreated(Models.CsvImportExample.Customer item);

        public async Task<Models.CsvImportExample.Customer> CreateCustomer(Models.CsvImportExample.Customer customer)
        {
            OnCustomerCreated(customer);

            Context.Customers.Add(customer);
            Context.SaveChanges();

            OnAfterCustomerCreated(customer);

            return customer;
        }
        public async Task ExportCustomersStagingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/csvimportexample/customersstagings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/csvimportexample/customersstagings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCustomersStagingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/csvimportexample/customersstagings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/csvimportexample/customersstagings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCustomersStagingsRead(ref IQueryable<Models.CsvImportExample.CustomersStaging> items);

        public async Task<IQueryable<Models.CsvImportExample.CustomersStaging>> GetCustomersStagings(Query query = null)
        {
            var items = Context.CustomersStagings.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCustomersStagingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomersStagingCreated(Models.CsvImportExample.CustomersStaging item);
        partial void OnAfterCustomersStagingCreated(Models.CsvImportExample.CustomersStaging item);

        public async Task<Models.CsvImportExample.CustomersStaging> CreateCustomersStaging(Models.CsvImportExample.CustomersStaging customersStaging)
        {
            OnCustomersStagingCreated(customersStaging);

            Context.CustomersStagings.Add(customersStaging);
            Context.SaveChanges();

            OnAfterCustomersStagingCreated(customersStaging);

            return customersStaging;
        }

      public async Task<int> UspCustomerUpdates()
      {
          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
          };

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[usp_CustomerUpdate]", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnUspCustomerUpdatesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUspCustomerUpdatesInvoke(ref int result);

        partial void OnCustomerDeleted(Models.CsvImportExample.Customer item);
        partial void OnAfterCustomerDeleted(Models.CsvImportExample.Customer item);

        public async Task<Models.CsvImportExample.Customer> DeleteCustomer(int? customerId)
        {
            var itemToDelete = Context.Customers
                              .Where(i => i.CustomerID == customerId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCustomerDeleted(itemToDelete);

            Context.Customers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCustomerDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCustomerGet(Models.CsvImportExample.Customer item);

        public async Task<Models.CsvImportExample.Customer> GetCustomerByCustomerId(int? customerId)
        {
            var items = Context.Customers
                              .AsNoTracking()
                              .Where(i => i.CustomerID == customerId);

            var itemToReturn = items.FirstOrDefault();

            OnCustomerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.CsvImportExample.Customer> CancelCustomerChanges(Models.CsvImportExample.Customer item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCustomerUpdated(Models.CsvImportExample.Customer item);
        partial void OnAfterCustomerUpdated(Models.CsvImportExample.Customer item);

        public async Task<Models.CsvImportExample.Customer> UpdateCustomer(int? customerId, Models.CsvImportExample.Customer customer)
        {
            OnCustomerUpdated(customer);

            var itemToUpdate = Context.Customers
                              .Where(i => i.CustomerID == customerId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(customer);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterCustomerUpdated(customer);

            return customer;
        }

        partial void OnCustomersStagingDeleted(Models.CsvImportExample.CustomersStaging item);
        partial void OnAfterCustomersStagingDeleted(Models.CsvImportExample.CustomersStaging item);

        public async Task<Models.CsvImportExample.CustomersStaging> DeleteCustomersStaging(int? customerStagingId)
        {
            var itemToDelete = Context.CustomersStagings
                              .Where(i => i.Customer_StagingID == customerStagingId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCustomersStagingDeleted(itemToDelete);

            Context.CustomersStagings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCustomersStagingDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCustomersStagingGet(Models.CsvImportExample.CustomersStaging item);

        public async Task<Models.CsvImportExample.CustomersStaging> GetCustomersStagingByCustomerStagingId(int? customerStagingId)
        {
            var items = Context.CustomersStagings
                              .AsNoTracking()
                              .Where(i => i.Customer_StagingID == customerStagingId);

            var itemToReturn = items.FirstOrDefault();

            OnCustomersStagingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.CsvImportExample.CustomersStaging> CancelCustomersStagingChanges(Models.CsvImportExample.CustomersStaging item)
        {
            var entityToCancel = Context.Entry(item);
            entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
            entityToCancel.State = EntityState.Unchanged;

            return item;
        }

        partial void OnCustomersStagingUpdated(Models.CsvImportExample.CustomersStaging item);
        partial void OnAfterCustomersStagingUpdated(Models.CsvImportExample.CustomersStaging item);

        public async Task<Models.CsvImportExample.CustomersStaging> UpdateCustomersStaging(int? customerStagingId, Models.CsvImportExample.CustomersStaging customersStaging)
        {
            OnCustomersStagingUpdated(customersStaging);

            var itemToUpdate = Context.CustomersStagings
                              .Where(i => i.Customer_StagingID == customerStagingId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(customersStaging);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterCustomersStagingUpdated(customersStaging);

            return customersStaging;
        }
    }
}

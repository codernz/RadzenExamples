using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportCsvFiles.Models.CsvImportExample
{
  [Table("Customers", Schema = "dbo")]
  public partial class Customer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerID
    {
      get;
      set;
    }
    public string Gender
    {
      get;
      set;
    }
    public string Title
    {
      get;
      set;
    }
    public string GivenName
    {
      get;
      set;
    }
    public string MiddleInitial
    {
      get;
      set;
    }
    public string Surname
    {
      get;
      set;
    }
    public string StreetAddress
    {
      get;
      set;
    }
    public string City
    {
      get;
      set;
    }
    public int? ZipCode
    {
      get;
      set;
    }
    public string Country
    {
      get;
      set;
    }
    public string EmailAddress
    {
      get;
      set;
    }
    public int Age
    {
      get;
      set;
    }
    public string Company
    {
      get;
      set;
    }
  }
}

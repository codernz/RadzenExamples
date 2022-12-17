using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lakes.Models.LakeData
{
  [Table("vw_Places", Schema = "dbo")]
  public partial class VwPlace
  {
    public string Area
    {
      get;
      set;
    }
    public string PlaceName
    {
      get;
      set;
    }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FamilyHistoryConsultant.Data
{
  public class Child
  {
    public int Id { get; set; }
    public string DirectoryName { get; set; }
    public string Gender { get; set; }
    public long IndividualId { get; set; }
    public string LatinName { get; set; }
    public bool LatinNameDifferent { get; set; }
    public string PreferredName { get; set; }
    public string Surname { get; set; }
    public HeadOfHouse HeadOfHouse { get; set; }
  }
}
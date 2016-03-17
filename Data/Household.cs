using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FamilyHistoryConsultant.Data
{
  public class Household
  {
    public int Id { get; set; }
    public IList<Child> Children { get; set; }
    public string CoupleName { get; set; }
    public HeadOfHouse HeadOfHouse { get; set; }
    public long HeadOfHouseIndividualId { get; set; }
    public string HouseholdName { get; set; }
    public bool IsProfilePrivate { get; set; }
    public Spouse Spouse { get; set; }
    public int UnitNo { get; set; }
  }
}
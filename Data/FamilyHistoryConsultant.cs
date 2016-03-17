using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyHistoryConsultant.Data {
  public class FamilyHistoryConsultant {
    [Key, ForeignKey("MemberRecord")]
    public int Id { get; set; }
    public DateTime CallingDate { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public virtual MemberRecord MemberRecord { get; set; }
  }
}
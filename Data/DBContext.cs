using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FamilyHistoryConsultant.Data
{
  public class DBContext : DbContext
  {
    public DBContext()
      : base("DefaultConnection")
    {

    }

    public DbSet<Topic> Topics { get; set; }
    public DbSet<Reply> Replies { get; set; }
    public IEnumerable<Reply> RepliesList { get; set; }
    public DbSet<Household> Household { get; set; }
    public DbSet<HeadOfHouse> HeadOfHouse { get; set; }
    public DbSet<Spouse> Spouse { get; set; }
    public DbSet<Child> Child { get; set; }
    public DbSet<MemberRecord> MemberRecord { get; set; }
    public DbSet<FamilyHistoryConsultant> FamilyHistoryConsultant { get; set; }
  }
}
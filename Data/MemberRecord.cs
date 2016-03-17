using AutoMapper;
using FamilyHistoryConsultant.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FamilyHistoryConsultant.Data
{
  public class MemberRecord : IHaveCustomMappings
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SpokenName { get; set; }
    public int NameOrder { get; set; }
    public string BirthDate { get; set; }
    public string BirthDateSort { get; set; }
    public string FormattedBirthDate { get; set; }
    public string Gender { get; set; }
    public string Mrn { get; set; }
    public long MemberRecordId { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int UnitNumber { get; set; }
    public string UnitName { get; set; }
    public string Priesthood { get; set; }
    public int Age { get; set; }
    public int ActualAge { get; set; }
    public string GenderLabelShort { get; set; }
    public bool? Visible { get; set; }
    public bool? NonMember { get; set; }
    public bool? OutOfUnitMember { get; set; }
    public string Address { get; set; }
    public string FormattedMrn { get; set; }
    public bool? SetApart { get; set; }
    public string FormattedBirthDateFull { get; set; }
    public string SustainedDate { get; set; }
    public virtual FamilyHistoryConsultant FamilyHistoryConsultant { get; set; }

    public void CreateMappings(IConfiguration configuration) {
      configuration.CreateMap<Models.MemberRecord, Data.MemberRecord>()
        .ForMember(dest => dest.MemberRecordId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Id, opt => opt.Ignore())
        ;
    }

  }
}
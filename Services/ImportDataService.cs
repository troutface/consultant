using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using FamilyHistoryConsultant.Models;
using Newtonsoft.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilyHistoryConsultant.Data;

namespace FamilyHistoryConsultant.Services
{
  public class ImportDataService : IImportDataService
  {
    private IRepository _repo;

    public ImportDataService(IRepository repo) {
      _repo = repo;
    }

    public HttpClient ImportHouseholdData(MemoryStream s)
    {
      HttpClient response = new HttpClient();

      return response;
    }

    public HttpClient ImportMemberRecordData(MemoryStream s)
    {
      HttpClient response = new HttpClient();

      return response;
    }

    public void PersistMemberRecords()
    {
      var minimumAge = 12;
      List<Models.MemberRecord> membershipRecords = new List<Models.MemberRecord>();
      using (StreamReader r = new StreamReader(@"C:\Users\Greg\Documents\toolbox\practice\practice\membersNew.json"))
      {
        string json = r.ReadToEnd();
        List<Models.MemberRecord> items = JsonConvert.DeserializeObject<List<Models.MemberRecord>>(json);
        membershipRecords = items;
      }
      DateTime now = DateTime.Now;
      var membersTwelveAndOlder = membershipRecords.Where(x => x.Age >= minimumAge).ToList<Models.MemberRecord>();

      var membersToPersist = Mapper.Map<List<Models.MemberRecord>, List<Data.MemberRecord>>(membersTwelveAndOlder);
      var result = _repo.AddMemberRecords(membersToPersist);
      var recordsSaved = _repo.Save();
    }

    public void PersistHouseholdRecords() {
      List<Models.Household> householdRecords = new List<Models.Household>();
      using (StreamReader s = new StreamReader(@"C:\Users\Greg\Documents\toolbox\practice\practice\familiesNew.json"))
      {
        string json = s.ReadToEnd();
        List<Models.Household> family = JsonConvert.DeserializeObject<List<Models.Household>>(json);
        householdRecords = family;
      }
      var householdsToPersist = Mapper.Map<List<Models.Household>, List<Data.Household>>(householdRecords);
      var result = _repo.AddHouseholds(householdsToPersist);
      var recordsSaved = _repo.Save();
    }
  }
}
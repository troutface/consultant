using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyHistoryConsultant.Data
{
  public class Repository : IRepository
  {
    DBContext _ctx;
    public Repository(DBContext ctx)
    {
      _ctx = ctx;
    }
    public IQueryable<Topic> GetTopics()
    {
      return _ctx.Topics;
    }

    public IQueryable<Reply> GetRepliesByTopic(int topicId)
    {
      return _ctx.Replies.Where(x => x.Id == topicId);
    }

    public IEnumerable<Reply> GetRepliesByTopicToList(int topicId)
    {
      return _ctx.Replies.Where(x => x.Id == topicId).ToList<Reply>();
    }

    public IQueryable<Household> GetHouseholds()
    {
      return _ctx.Household;
    }
    public IQueryable<Household> GetHouseholdByHeadOfHouse(long headOfHouseId)
    {
      return _ctx.Household.Where(x => x.HeadOfHouse.IndividualId == headOfHouseId);
    }

    public IQueryable<MemberRecord> GetMemberByMemberRecordId(long MemberRecordId)
    {
      return _ctx.MemberRecord.Where(x => x.MemberRecordId == MemberRecordId);
    }

    public IQueryable<MemberRecord> GetAllMemberRecords() {
      return _ctx.MemberRecord;
    }

    public int Save() {
      try {
        return _ctx.SaveChanges();// > 0;
      } catch (Exception ex){
        return 0;
      }
    }

    public bool AddHouseholds(List<Data.Household> households) {
      try {
        foreach (var household in households) {
          _ctx.Household.Add(household);
        }
        return true;
      } catch (Exception ex) {
        return false;
      }
    }

    public bool AddMemberRecords(List<Data.MemberRecord> memberRecords) {
      try {
        foreach (var record in memberRecords) {
          _ctx.MemberRecord.Add(record);
        }
        return true;
      } catch (Exception ex) {
        return false;
      }
    }

    public IQueryable<FamilyHistoryConsultant> GetActiveFamilyHistoryConsultants() {
        return _ctx.FamilyHistoryConsultant.Where(x => x.ReleaseDate == null);
    }

    public IQueryable<FamilyHistoryConsultant> GetAllFamilyHistoryConsultants() {
        return _ctx.FamilyHistoryConsultant;
    }
  }
}
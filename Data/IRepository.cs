using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyHistoryConsultant.Data
{
  public interface IRepository
  {
    IQueryable<Topic> GetTopics();
    IQueryable<Reply> GetRepliesByTopic(int topicId);
    IEnumerable<Reply> GetRepliesByTopicToList(int topicId);
    IQueryable<Household> GetHouseholdByHeadOfHouse(long headOfHouseId);
    IQueryable<Household> GetHouseholds();
    IQueryable<MemberRecord> GetAllMemberRecords();
    IQueryable<FamilyHistoryConsultant> GetAllFamilyHistoryConsultants();
    IQueryable<FamilyHistoryConsultant> GetActiveFamilyHistoryConsultants(); 
    
    //bool Save();
    int Save();
    bool AddHouseholds(List<Data.Household> households);
    bool AddMemberRecords(List<Data.MemberRecord> memberRecords);
  }
}

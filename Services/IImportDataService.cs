using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FamilyHistoryConsultant.Services
{
  public interface IImportDataService
  {
    HttpClient ImportHouseholdData(MemoryStream s);
    HttpClient ImportMemberRecordData(MemoryStream s);
    void PersistMemberRecords();
    void PersistHouseholdRecords();

  }
}

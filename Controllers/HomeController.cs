using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyHistoryConsultant.Models;
using FamilyHistoryConsultant.Services;
using FamilyHistoryConsultant.Data;

namespace FamilyHistoryConsultant.Controllers
{
    public class HomeController : Controller
    {
      private IMailService _mail;
      private IRepository _repo;
      private IImportDataService _importDataService;
      public HomeController(IMailService mail, IRepository repo, IImportDataService importDataService)
      {
        _mail = mail;
        _repo = repo;
        _importDataService = importDataService;
      }
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var topics = _repo.GetTopics().OrderByDescending(t => t.Created);

            var consultants = _repo.GetActiveFamilyHistoryConsultants();

            _importDataService.PersistMemberRecords();

            var members = _repo.GetAllMemberRecords();

            _importDataService.PersistHouseholdRecords();

            var households = _repo.GetHouseholds();
            var householdByHeadOfHouse = _repo.GetHouseholdByHeadOfHouse(74);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
          var msg = string.Format("Comment From: {1}{0}Email: {2}{0}Website: {3}{0}Comment: {4}{0}",
            Environment.NewLine,
            model.name,
            model.email,
            model.website,
            model.comment);

          if (_mail.SendMail("noreply@troutface.com", "troutface29@gmail.com", "Website Contact", msg))
          {
            ViewBag.MailSent = true;
          }

          return View();
        }

        public ActionResult ChecklistStatus()
        {
          return View();
        }
    }
}

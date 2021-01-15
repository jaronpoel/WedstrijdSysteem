using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptions.MatchReport;
using Logic;
using Microsoft.AspNetCore.Mvc;
using WedstrijdSysteem.Models;

namespace WedstrijdSysteem.Controllers
{
    public class ReportsController : Controller
    {
        private MatchReportCollection MatchReportCollection { get; } = new MatchReportCollection();
        private MatchReport MatchReport { get; } = new MatchReport();

        public ActionResult Oversight()
        {
            AllMatchReportsViewModel ViewModel = new AllMatchReportsViewModel();
            ViewModel.ListOfMatchReports = MatchReportCollection.GetAllMatchReports();
            return View(ViewModel);
        }
        public ActionResult SingleReport(int id)
        {
            MatchReport list = MatchReportCollection.GetMatchReportByID(id);
            if (list == null)
            {
                return RedirectToAction("Reports", "Oversight");
            }
            ViewBag.Matchreport = list;
            return View();
        }
        public ActionResult NewReport()
        {
            return View();
        }

        public ActionResult UpdateFullReport(int id)
        {
            MatchReport list = MatchReportCollection.GetMatchReportByID(id);
            if (list == null)
            {
                return RedirectToAction("Reports", "Oversight");
            }
            ViewBag.Matchreport = list;
            return View();
        }

        public ActionResult DeleteReport(int id)
        {
            MatchReportCollection.DeleteMatchReport(id);
            return RedirectToAction("Oversight", "Reports");
        }

        [HttpPost]
        public IActionResult NewMatchReportAdded(MatchReportViewModel matchreport)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("NewReport", "Reports");
            }

            try
            {
                MatchReport newreport = new MatchReport(0, DateTime.Now, matchreport.Title, matchreport.Report, null);
                MatchReportCollection.AddMatchReport(newreport);
                return RedirectToAction("Oversight", "Reports");
            }
            catch (AddMatchReportFailedException exception)
            {
                ModelState.AddModelError("", exception.Message);
                return RedirectToAction("NewReport", "Reports");
            }
        }

        //Update
        [HttpPost]
        public IActionResult UpdateTitle(SetTitleViewModel title, int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                MatchReport.SetTitle(title.Title, id);
                return RedirectToAction("Oversight", "Reports");
            }
            catch (SetFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdateReport(SetReportViewModel reporttext, int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                MatchReport.SetReport(reporttext.Report, id);
                return RedirectToAction("Oversight", "Reports");
            }
            catch (SetFailedException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}

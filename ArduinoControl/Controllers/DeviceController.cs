using Anotar.NLog;
using ArduinoControl.Rules;
using System;
using System.Web.Mvc;

namespace ArduinoControl.Controllers
{
    public class DeviceController : Controller
    {
        private IDeviceRules _deviceRules;

        public DeviceController(IDeviceRules deviceRules)
        {
            this._deviceRules = deviceRules;
        }

        // GET: Device
        public ActionResult Index()
        {
            var count = _deviceRules.GetRecordCount();
            //ViewBag.Count = count.ToString();
            return View();
        }

        // GET: Device/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Device/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Device/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Device/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Device/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Device/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Device/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeviceList(int jtStartIndex = 0, int jtPageSize = 10, string jtSorting = null)
        {
            if (string.IsNullOrEmpty(jtSorting))
                jtSorting = "DeviceName ASC";
            try
            {
                var returnList = _deviceRules.Get(jtPageSize, jtStartIndex, jtSorting);
                int totalRecords = _deviceRules.GetRecordCount();
                return Json(new
                {
                    Result = "OK",
                    Records = returnList,
                    TotalRecordCount = totalRecords
                });
            }
            catch (Exception e)
            {
                LogTo.Fatal("Error while extracting data:\r\n:Error message: " +
                    e.Message);
                return Json(new { Result = "ERROR", Message = "Error while retrieving data; please try later\n" + e.Message });
            }
        }
    }
}
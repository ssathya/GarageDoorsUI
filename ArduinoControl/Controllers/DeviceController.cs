using Anotar.NLog;
using ArduinoControl.Models.AppModel.ViewModel;
using ArduinoControl.Rules;
using AutoMapper.Internal;
using System;
using System.Web.Mvc;

namespace ArduinoControl.Controllers
{
    [Authorize]
    public class DeviceController : Controller
    {
        private readonly IDeviceRules _deviceRules;
        private readonly string _exceptinMessage;

        public DeviceController(IDeviceRules deviceRules)
        {
            this._deviceRules = deviceRules;
            _exceptinMessage = "Error while accessing database";
        }

        // GET: Device
        public ActionResult Index()
        {
            var count = _deviceRules.GetRecordCount();
            //ViewBag.Count = count.ToString();
            return View();
        }

        // POST: Device/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeviceView deviceView)
        {
            if (deviceView != null && User != null)
                deviceView.UserName = User.Identity.Name;
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.GetEnumerator();
                    var message = errors.ToNullSafeString();

                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! Error " +
                                  message
                    });
                }
                if (_deviceRules.AddRecord(ref deviceView))
                    return Json(new
                    {
                        Result = "OK",
                        Record = deviceView
                    });
                else
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "We tried hard but beyond control\r\n " +
                                  "Please try later"
                    });
                }
            }
            catch (Exception exception)
            {
                LogTo.Fatal("{0}{1}", _exceptinMessage, exception.Message);
                return Json(new
                {
                    Result = "ERROR",
                    Message = "We tried hard but beyond control\r\n " +
                              "Please try later"
                });
            }
        }

        // POST: Device/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DeviceView deviceView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.GetEnumerator();
                    var message = errors.ToNullSafeString();

                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! Error " +
                                  message
                    });
                }
                if (deviceView != null && id != deviceView.Id)
                    deviceView.Id = id;
                _deviceRules.UpdateRecord(ref deviceView);
                return Json(new
                {
                    Result = "OK",
                    Record = 1
                });
            }
            catch (Exception e)
            {
                LogTo.Fatal("Error while adding record \r\nMessage:" +
                    e.Message);
                return Json(new
                {
                    Result = "ERROR",
                    Message = "Error while editing record" +
                              "Please try later"
                });
            }
        }

        // POST: Device/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == default(int))
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! " +
                                  "Please reload the page"
                    });
                var deleteRecord = _deviceRules.DeleteRecord(id);
                return Json(new
                {
                    Result = deleteRecord ? "OK" : "ERROR",
                    Message = deleteRecord
                        ? ""
                        : "Error while deleting record \r\nPlease try later"
                });
            }
            catch (Exception exception)
            {
                LogTo.Fatal("Error while deleting record ");
                LogTo.Fatal(exception.Message);
                return Json(new
                {
                    Result = "ERROR",
                    Message = "Error while deleting record \r\nPlease try later"
                });
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

        public ActionResult InputPortsList(int deviceId)
        {
            if (deviceId == default(int))
                return Json(new
                {
                    Result = "ERROR",
                    Message = "Invalid Device Selected"
                });
            return Json(new
            {
                Result = "OK",
                Records = ""
            });
        }

        public ActionResult InputPortsDelete()
        {
            throw new NotImplementedException();
        }

        public ActionResult InputPortsUpdate()
        {
            throw new NotImplementedException();
        }

        public ActionResult InputPortsCreate()
        {
            throw new NotImplementedException();
        }
    }
}
using Anotar.NLog;
using ArduinoControl.Models.AppModel.ViewModel;
using AutoMapper.Internal;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ArduinoControl.Controllers
{
    public partial class DeviceController
    {
        #region Public Methods

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InputPortsCreate(InputPortView inputPortView)
        {
            if (inputPortView == null)
                return Json(new
                {
                    Result = "ERROR",
                    Message = "We tried hard but beyond control\r\n " +
                              "Please try later"
                });
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! "
                    });
                }
                if (_iPortRules.AddRecord(ref inputPortView))
                    return Json(new
                    {
                        Result = "OK",
                        Record = inputPortView
                    });
                return Json(new
                {
                    Result = "ERROR",
                    Message = "We tried hard but beyond control\r\n " +
                              "Please try later"
                });
            }
            catch (Exception exception)
            {
                LogTo.Fatal("{0}{1}", _exceptionMessage, exception.Message);
                return Json(new
                {
                    Result = "ERROR",
                    Message = "We tried hard but beyond control\r\n " +
                              "Please try later"
                });
            }
        }

        public ActionResult InputPortsDelete(int id)
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

        /// <summary>
        /// Inputs the ports list.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        public ActionResult InputPortsList(int deviceId)
        {
            if (deviceId == default(int))
                return Json(new
                {
                    Result = "ERROR",
                    Message = "Invalid Device Selected"
                });
            var device = _deviceRules.GetRecord(deviceId);
            var inputsList = _iPortRules.Get(device).ToList();
            return Json(new
            {
                Result = "OK",
                Records = inputsList,
                TotoalRecordCount = inputsList.Count()
            });
        }

        public ActionResult InputPortsUpdate(InputPortView inputPortView)
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
                _iPortRules.UpdateRecord(ref inputPortView);
                return Json(new
                {
                    Result = "OK",
                    Record = inputPortView
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

        #endregion Public Methods
    }
}
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

        /// <summary>
        /// Outputs the ports create.
        /// </summary>
        /// <param name="outputPortView">The output port view.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OutputPortsCreate(OutputPortView outputPortView)
        {
            if (outputPortView == null)
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
                if (_outPortRules.AddRecord(ref outputPortView))
                    return Json(new
                    {
                        Result = "OK",
                        Record = outputPortView
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

        /// <summary>
        /// Outputs the ports delete.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult OutputPortsDelete(int id)
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
                var deleteRecord = _outPortRules.DeleteRecord(id);
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
        /// Outputs the ports list.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        public ActionResult OutputPortsList(int deviceId)
        {
            if (deviceId == default(int))
                return Json(new
                {
                    Result = "ERROR",
                    Message = "Invalid Device Selected"
                });
            var device = _deviceRules.GetRecord(deviceId);
            var outputList = _outPortRules.Get(device).ToList();
            return Json(new
            {
                Result = "OK",
                Records = outputList,
                TotoalRecordCount = outputList.Count()
            });
        }

        /// <summary>
        /// Outputs the ports update.
        /// </summary>
        /// <param name="outputPortView">The output port view.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OutputPortsUpdate(OutputPortView outputPortView)
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
                _outPortRules.UpdateRecord(ref outputPortView);
                return Json(new
                {
                    Result = "OK",
                    Record = outputPortView
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
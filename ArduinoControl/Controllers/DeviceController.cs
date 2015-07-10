using Anotar.NLog;
using ArduinoControl.Models.AppModel.ViewModel;
using ArduinoControl.Rules;
using AutoMapper.Internal;
using System;
using System.Web.Mvc;

namespace ArduinoControl.Controllers
{
    [Authorize]
    public partial class DeviceController : Controller
    {
        #region Private Fields

        private readonly IDeviceRules _deviceRules;
        private readonly string _exceptionMessage;
        private readonly IIPortRules _iPortRules;
        private readonly IOutPortRules _outPortRules;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceController"/> class.
        /// </summary>
        /// <param name="deviceRules">The device rules.</param>
        /// <param name="iPortRules">The i port rules.</param>
        /// <param name="outPortRules"></param>
        public DeviceController(IDeviceRules deviceRules, IIPortRules iPortRules, IOutPortRules outPortRules)
        {
            _deviceRules = deviceRules;
            _iPortRules = iPortRules;
            _outPortRules = outPortRules;
            _exceptionMessage = "Error while accessing database";
        }

        #endregion Public Constructors

        #region Public Methods

        // POST: Device/Create
        /// <summary>
        /// Creates the specified device view.
        /// </summary>
        /// <param name="deviceView">The device view.</param>
        /// <returns></returns>
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

        // POST: Device/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Devices the list.
        /// </summary>
        /// <param name="jtStartIndex">Start index of the jt.</param>
        /// <param name="jtPageSize">Size of the jt page.</param>
        /// <param name="jtSorting">The jt sorting.</param>
        /// <returns></returns>
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

        // POST: Device/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="deviceView">The device view.</param>
        /// <returns></returns>
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

        // GET: Device
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        #endregion Public Methods
    }
}
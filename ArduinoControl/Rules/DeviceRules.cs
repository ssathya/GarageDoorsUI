using Anotar.NLog;
using ArduinoControl.Models.AppModel.PhysicalModel;
using ArduinoControl.Models.AppModel.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ArduinoControl.Rules
{
    public class DeviceRules : IDeviceRules
    {
        #region Private Fields

        /// <summary>
        /// The _device context
        /// </summary>
        private readonly DeviceContext _deviceContext;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceRules"/> class.
        /// </summary>
        /// <param name="deviceContext">The device context.</param>
        public DeviceRules(DeviceContext deviceContext)
        {
            _deviceContext = deviceContext;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Adds the record.
        /// </summary>
        /// <param name="deviceView">The device view.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        public bool AddRecord(ref DeviceView deviceView)
        {
            try
            {
                var newRecord = Mapper.Map<Device>(deviceView);
                _deviceContext.Devices.Add(newRecord);
                _deviceContext.SaveChanges();
                deviceView = Mapper.Map<DeviceView>(newRecord);
            }
            catch (Exception e)
            {
                LogTo.Fatal("Database insert failed.\r\n Error Message :" + e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the specified row count.
        /// </summary>
        /// <param name="rowCount">The row count.</param>
        /// <param name="startingRow">The starting row.</param>
        /// <param name="sortColumn">The sort column.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        public IEnumerable<DeviceView> Get(int rowCount, int startingRow = 0, string sortColumn = null)
        {
            if (sortColumn == null)
                sortColumn = "DeviceName ASC";
            var values = _deviceContext.Devices.OrderBy(sortColumn).Skip(startingRow).Take(rowCount);

            var devicesList = Mapper.Map<List<DeviceView>>(values.ToList());
            return devicesList;
        }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <param name="iD">The i d.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        public Device GetRecord(int iD)
        {
            return _deviceContext.Devices.Find(iD);
        }

        /// <summary>
        /// Gets the record count.
        /// </summary>
        /// <returns></returns>
        [LogToErrorOnException]
        public int GetRecordCount()
        {
            return _deviceContext.Devices.Count();
        }

        /// <summary>
        /// Updates the record.
        /// </summary>
        /// <param name="deviceView">The device view.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        public bool UpdateRecord(ref DeviceView deviceView)
        {
            var device = _deviceContext.Devices.Find(deviceView.Id);
            if (device == null)
                return false;
            Mapper.Map(deviceView, device);
            try
            {
                var saveChanges = _deviceContext.SaveChanges();
                Mapper.Map(device, deviceView);
            }
            catch (Exception exception)
            {
                LogTo.Fatal("Error while updating record\r\n Message: ");
                LogTo.Fatal(exception.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Deletes the record.
        /// </summary>
        /// <param name="iD">The i d.</param>
        /// <returns></returns>
        public bool DeleteRecord(int iD)
        {
            try
            {
                var device = _deviceContext.Devices.Find(iD);
                if (device != null)
                {
                    _deviceContext.Devices.Remove(device);
                    _deviceContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                LogTo.Fatal("Error while deleting record\r\n Message: ");
                LogTo.Fatal(exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _deviceContext.SaveChanges();
            _deviceContext.Dispose();
        }

        #endregion Public Methods
    }
}
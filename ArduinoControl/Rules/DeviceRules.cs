using Anotar.NLog;
using ArduinoControl.Models.AppModel.PhysicalModel;
using ArduinoControl.Models.AppModel.ViewModel;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace ArduinoControl.Rules
{
    public class DeviceRules
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
        public bool AddRecord(DeviceView deviceView)
        {
            var newRecord = Mapper.Map<Device>(deviceView);
            _deviceContext.Devices.Add(newRecord);
            _deviceContext.SaveChanges();
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
            var values = _deviceContext.Devices;
            DynamicQueryable.Take(values.OrderBy(string.IsNullOrEmpty(sortColumn) ? "Id ASC" : sortColumn)
                    .Skip(startingRow), rowCount);
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
        public bool UpdateRecord(DeviceView deviceView)
        {
            var device = _deviceContext.Devices.Find(deviceView.Id);
            if (device == null)
                return false;
            Mapper.Map(deviceView, device);
            var saveChanges = _deviceContext.SaveChanges();
            return true;
        }

        #endregion Public Methods
    }
}
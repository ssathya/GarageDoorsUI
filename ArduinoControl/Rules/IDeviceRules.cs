using System.Collections.Generic;
using Anotar.NLog;
using ArduinoControl.Models.AppModel.PhysicalModel;
using ArduinoControl.Models.AppModel.ViewModel;

namespace ArduinoControl.Rules
{
    public interface IDeviceRules
    {
        /// <summary>
        /// Adds the record.
        /// </summary>
        /// <param name="deviceView">The device view.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        bool AddRecord(DeviceView deviceView);

        /// <summary>
        /// Gets the specified row count.
        /// </summary>
        /// <param name="rowCount">The row count.</param>
        /// <param name="startingRow">The starting row.</param>
        /// <param name="sortColumn">The sort column.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        IEnumerable<DeviceView> Get(int rowCount, int startingRow = 0, string sortColumn = null);

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <param name="iD">The i d.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        Device GetRecord(int iD);

        /// <summary>
        /// Gets the record count.
        /// </summary>
        /// <returns></returns>
        [LogToErrorOnException]
        int GetRecordCount();

        /// <summary>
        /// Updates the record.
        /// </summary>
        /// <param name="deviceView">The device view.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        bool UpdateRecord(DeviceView deviceView);
    }
}
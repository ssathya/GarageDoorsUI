using Anotar.NLog;
using ArduinoControl.Models.AppModel.PhysicalModel;
using ArduinoControl.Models.AppModel.ViewModel;
using System;
using System.Collections.Generic;

namespace ArduinoControl.Rules
{
    public interface IDeviceRules : IDbWrapper, IDisposable
    {
        /// <summary>
        /// Gets the specified row count.
        /// </summary>
        /// <param name="rowCount">The row count.</param>
        /// <param name="startingRow">The starting row.</param>
        /// <param name="sortColumn">The sort column.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        IEnumerable<DeviceView> Get(int rowCount, int startingRow = 0, string sortColumn = null);
    }
}
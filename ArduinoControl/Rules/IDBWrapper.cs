using Anotar.NLog;
using ArduinoControl.Models.AppModel.PhysicalModel;
using ArduinoControl.Models.AppModel.ViewModel;
using System.Collections.Generic;

namespace ArduinoControl.Rules
{
    public interface IDbWrapper
    {
        #region Public Methods

        /// <summary>
        /// Adds the record.
        /// </summary>
        /// <param name="deviceView">The device view.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        bool AddRecord(ref DeviceView deviceView);

        /// <summary>
        /// Deletes the record.
        /// </summary>
        /// <param name="iD">The i d.</param>
        /// <returns></returns>
        bool DeleteRecord(int iD);

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
        bool UpdateRecord(ref DeviceView deviceView);

        #endregion Public Methods
    }
}
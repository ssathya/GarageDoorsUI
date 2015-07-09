using Anotar.NLog;
using ArduinoControl.Models.AppModel.PhysicalModel;
using ArduinoControl.Models.AppModel.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArduinoControl.Rules
{
    public class InputPortRules : IIPortRules
    {
        #region Private Fields

        private readonly DeviceContext _deviceContext;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InputPortRules"/> class.
        /// </summary>
        /// <param name="deviceContext">The device context.</param>
        public InputPortRules(DeviceContext deviceContext)
        {
            _deviceContext = deviceContext;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Adds the record.
        /// </summary>
        /// <param name="record">The record to be added.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        public bool AddRecord(ref InputPortView record)
        {
            try
            {
                var newRecord = Mapper.Map<InputPort>(record);
                _deviceContext.InputPorts.Add(newRecord);
                _deviceContext.SaveChanges();
                record = Mapper.Map<InputPortView>(newRecord);
                return true;
            }
            catch (Exception e)
            {
                LogTo.Fatal("Database insert failed.\r\n Error Message :" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Deletes the record.
        /// </summary>
        /// <param name="iD">The i d.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        public bool DeleteRecord(int iD)
        {
            try
            {
                var device = _deviceContext.InputPorts.Find(iD);
                if (device == null) return false;
                _deviceContext.InputPorts.Remove(device);
                _deviceContext.SaveChanges();
                return true;
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
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            _deviceContext.SaveChanges();
            _deviceContext.Dispose();
        }

        /// <summary>
        /// Gets the specified device view.
        /// </summary>
        /// <param name="deviceView">The device view.</param>
        /// <returns></returns>
        public IEnumerable<InputPortView> Get(DeviceView deviceView)
        {
            if (deviceView == null) return null;
            var inputs = _deviceContext.InputPorts.Where(i => i.DeviceId == deviceView.Id);
            var inputPortViewList = Mapper.Map<List<InputPortView>>(inputs.ToList());
            return inputPortViewList;
        }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <param name="iD">The i d.</param>
        /// <returns></returns>
        public InputPortView GetRecord(int iD)
        {
            var record = _deviceContext.InputPorts.Find(iD);
            return record == null ? null : Mapper.Map<InputPortView>(record);
        }

        /// <summary>
        /// Gets the record count.
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            return _deviceContext.InputPorts.Count();
        }

        /// <summary>
        /// Updates the record.
        /// </summary>
        /// <param name="record">The record to be updated.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        public bool UpdateRecord(ref InputPortView record)
        {
            var inputs = _deviceContext.InputPorts.Find(record.Id);
            if (inputs == null) return false;
            record.Device = inputs.Device;
            Mapper.Map(record, inputs);
            try
            {
                _deviceContext.SaveChanges();
                Mapper.Map(record, inputs);
                return true;
            }
            catch (Exception exception)
            {
                LogTo.Fatal("Error while updating record\r\n Message: ");
                LogTo.Fatal(exception.Message);
                return false; ;
            }
        }

        #endregion Public Methods
    }
}
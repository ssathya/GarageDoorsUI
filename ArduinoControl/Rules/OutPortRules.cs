using Anotar.NLog;
using ArduinoControl.Models.AppModel.PhysicalModel;
using ArduinoControl.Models.AppModel.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArduinoControl.Rules
{
    public class OutPortRules : IOutPortRules
    {
        #region Private Fields

        private readonly DeviceContext _deviceContext;

        #endregion Private Fields

        #region Public Constructors

        public OutPortRules(DeviceContext deviceContext)
        {
            _deviceContext = deviceContext;
        }

        #endregion Public Constructors

        #region Public Methods

        [LogToErrorOnException]
        public bool AddRecord(ref OutputPortView record)
        {
            try
            {
                var newRecord = Mapper.Map<OutputPort>(record);
                _deviceContext.OutputPorts.Add(newRecord);
                _deviceContext.SaveChanges();
                record = Mapper.Map<OutputPortView>(newRecord);
                return true;
            }
            catch (Exception e)
            {
                LogTo.Fatal("Database insert failed.\r\n Error Message :" + e.Message);
                return false;
            }
        }

        public bool DeleteRecord(int iD)
        {
            try
            {
                var device = _deviceContext.OutputPorts.Find(iD);
                if (device == null) return false;
                _deviceContext.OutputPorts.Remove(device);
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

        public void Dispose()
        {
            _deviceContext.SaveChanges();
            _deviceContext.Dispose();
        }

        public IEnumerable<OutputPortView> Get(DeviceView deviceView)
        {
            if (deviceView == null) return null;
            var outputs = _deviceContext.OutputPorts.Where(i => i.DeviceId == deviceView.Id);
            var inputPortViewList = Mapper.Map<List<OutputPortView>>(outputs.ToList());
            return inputPortViewList;
        }

        public OutputPortView GetRecord(int iD)
        {
            var record = _deviceContext.InputPorts.Find(iD);
            return record == null ? null : Mapper.Map<OutputPortView>(record);
        }

        public int GetRecordCount()
        {
            return _deviceContext.OutputPorts.Count();
        }

        public bool UpdateRecord(ref OutputPortView record)
        {
            var outputs = _deviceContext.OutputPorts.Find(record.Id);
            if (outputs == null) return false;
            record.Device = outputs.Device;
            Mapper.Map(record, outputs);
            try
            {
                _deviceContext.SaveChanges();
                Mapper.Map(record, outputs);
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
using Anotar.NLog;
using ArduinoControl.Models.AppModel.ViewModel;
using System;
using System.Collections.Generic;

namespace ArduinoControl.Rules
{
    public interface IOutPortRules : IDbWrapper<OutputPortView>, IDisposable
    {
        [LogToErrorOnException]
        IEnumerable<OutputPortView> Get(DeviceView deviceView);
    }
}
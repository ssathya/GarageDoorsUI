using Anotar.NLog;
using ArduinoControl.Models.AppModel.ViewModel;
using System;
using System.Collections.Generic;

namespace ArduinoControl.Rules
{
    public interface IIPortRules : IDbWrapper<InputPortView>, IDisposable
    {
        [LogToErrorOnException]
        IEnumerable<InputPortView> Get(DeviceView deviceView);
    }
}
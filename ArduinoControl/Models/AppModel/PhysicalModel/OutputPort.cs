using System.ComponentModel.DataAnnotations;

namespace ArduinoControl.Models.AppModel.PhysicalModel
{
    public class OutputPort : PortsCommonValues
    {
        public bool PulseOrState { get; set; }

        [Range(1, 60)]
        public int PulseDuration { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ArduinoControl.Models.AppModel.PhysicalModel
{
    public class InputPort : PortsCommonValues
    {
        public float NominalLowValue { get; set; }

        public float NominalHighValue { get; set; }

        public float AlarmLow { get; set; }

        public float AlaarmHigh { get; set; }

        [StringLength(50), DataType(DataType.EmailAddress)]
        public string AlarmNotificationAddress { get; set; }

        [Range(0, 60)]
        public int MinutesBetweenNotification { get; set; }
    }
}
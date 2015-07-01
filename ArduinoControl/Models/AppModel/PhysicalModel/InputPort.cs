using System.ComponentModel.DataAnnotations;

namespace ArduinoControl.Models.AppModel.PhysicalModel
{
    public class InputPort
    {
        public int Id { get; set; }

        public int DeviceId { get; set; }

        public virtual Device Device { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        public float MultiplicationFactor { get; set; }

        public float NominalLowValue { get; set; }

        public float NominalHighValue { get; set; }

        public float AlarmLow { get; set; }

        public float AlaarmHigh { get; set; }

        public string AlarmNotificationAddress { get; set; }

        [Range(0, 60)]
        public int MinutesBetweenNotification { get; set; }
    }
}
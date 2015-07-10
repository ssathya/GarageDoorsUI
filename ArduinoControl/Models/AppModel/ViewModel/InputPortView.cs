using ArduinoControl.Models.AppModel.PhysicalModel;
using System.ComponentModel.DataAnnotations;

namespace ArduinoControl.Models.AppModel.ViewModel
{
    public class InputPortView
    {
        public int Id { get; set; }

        public int DeviceId { get; set; }

        public virtual Device Device { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(50), Required]
        public string FeedName { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        [Range(0, 1000)]
        public float MultiplicationFactor { get; set; }

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
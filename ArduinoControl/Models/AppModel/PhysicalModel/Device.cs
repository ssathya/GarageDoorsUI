using System.ComponentModel.DataAnnotations;

namespace ArduinoControl.Models.AppModel.PhysicalModel
{
    public class Device
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(30)]
        public string DeviceName { get; set; }

        [MaxLength(255)]
        public string DataSourceUrl { get; set; }

        [Range(1, 120)]
        public int FreqToPoll { get; set; }

        [Range(1, 1440)]
        public int ExpectedReportingFreq { get; set; }

        [Range(1, 1440)]
        public int DurationToIgnore { get; set; }

        [DataType(DataType.EmailAddress), MaxLength(100)]
        public string AddressToNotifyIfNoResponse { get; set; }

        [Range(5, 60)]
        public int MinutesBetweenNotification { get; set; }
    }
}
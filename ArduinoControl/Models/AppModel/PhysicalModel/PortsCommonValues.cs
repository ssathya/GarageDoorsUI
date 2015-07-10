using System.ComponentModel.DataAnnotations;

namespace ArduinoControl.Models.AppModel.PhysicalModel
{
    public abstract class PortsCommonValues
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
    }
}
using System.Data.Entity;

namespace ArduinoControl.Models.AppModel.PhysicalModel
{
    public class DeviceContext : DbContext
    {
        public DeviceContext()
            : base("Device")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Device> Devices { get; set; }

        public virtual DbSet<InputPort> InputPorts { get; set; }

        public virtual DbSet<OutputPort> OutputPorts { get; set; }
    }
}
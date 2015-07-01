using ArduinoControl.Models.AppModel.PhysicalModel;
using ArduinoControl.Models.AppModel.ViewModel;
using AutoMapper;

namespace ArduinoControl.Rules
{
    public static class AutoMapperConfig
    {
        public static void Start()
        {
            Mapper.CreateMap<Device, DeviceView>();
            Mapper.CreateMap<InputPort, InputPortView>();
            Mapper.CreateMap<OutputPort, OutputPortView>();

            Mapper.CreateMap<DeviceView, Device>();
            Mapper.CreateMap<InputPortView, InputPort>();
            Mapper.CreateMap<OutputPortView, OutputPort>();
        }
    }
}
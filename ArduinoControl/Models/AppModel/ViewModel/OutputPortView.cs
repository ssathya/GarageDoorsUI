﻿using ArduinoControl.Models.AppModel.PhysicalModel;
using System.ComponentModel.DataAnnotations;

namespace ArduinoControl.Models.AppModel.ViewModel
{
    public class OutputPortView
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

        public bool PulseOrState { get; set; }

        [Range(1, 60)]
        public int PulseDuration { get; set; }
    }
}
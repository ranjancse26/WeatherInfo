using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherInfo.Models
{
    public class WeatherInfoViewModel
    {
        public WeatherBug.WeatherInfo WeatherInfo { get; set; }
        [Required]
        public int WeatherCode { get; set; }
    }
}
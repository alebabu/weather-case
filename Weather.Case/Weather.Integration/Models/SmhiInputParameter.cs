using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Integration.Models
{
    public enum SmhiInputParameter
    {
        AirTemperatureInstantHourly = 1,         // Air temperature, instantaneous once per hour (°C)
        WindGustMaxHourly = 21                   // Wind gust, max value once per hour (m/s)
    }
}

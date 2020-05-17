using System;
using System.Collections.Generic;
using System.Text;

namespace ClimaCellCore.Models
{
    class ClimaCellResponse
    {
        public string AttributionLine => "Powered by Dark Sky";
        public string DataSource => "https://www.climacell.co/";
        public ResponseHeaders Headers { get; set; }
        public bool IsSuccessStatus { get; set; }
        public Forecast Response { get; set; }
    }
}

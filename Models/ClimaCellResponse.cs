using System;
using System.Collections.Generic;
using System.Text;

namespace ClimaCellCore.Models
{
    public class ClimaCellResponse
    {
        public string AttributionLine => "Powered by ClimaCell";
        public string DataSource => "https://www.climacell.co/";
        public ResponseHeaders Headers { get; set; }
        public bool IsSuccessStatus { get; set; }
        public RealTime Response { get; set; }
        public string ResponseReasonPhrase { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BDLab3_4
{
    class Series
    {
        [JsonProperty("ID_D_SERIES")]
        public string ID_D_SERIES;
        [JsonProperty("D_SERIES")]
        public string D_SERIES;
    }
}

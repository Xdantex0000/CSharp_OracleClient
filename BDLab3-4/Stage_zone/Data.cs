using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BDLab3_4
{
    class Data
    {
        [JsonProperty("ID_DATA")]
        public string ID_DATA;

        [JsonProperty("THEFT_DATA")]
        public string THEFT_DATA;

        [JsonProperty("INSERT_DATE")]
        public string INSERT_DATE;
    }
}

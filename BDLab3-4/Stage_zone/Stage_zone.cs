using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace BDLab3_4
{
    class Stage_zone
    {
        [JsonProperty("ID")]
        public string ID;

        [JsonProperty("OVD")]
        public string OVD;

        [JsonProperty("D_SERIES")]
        public string D_SERIES;

        [JsonProperty("D_NUMBER")]
        public string D_NUMBER;

        [JsonProperty("D_TYPE")]
        public string D_TYPE;

        [JsonProperty("D_STATUS")]
        public string D_STATUS;

        [JsonProperty("THEFT_DATA")]
        public string THEFT_DATA;

        [JsonProperty("INSERT_DATE")]
        public string INSERT_DATE;
    }
}

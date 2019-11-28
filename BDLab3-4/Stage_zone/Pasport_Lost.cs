using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BDLab3_4
{
    class Pasport_Lost
    {
        [JsonProperty("ID")]
        public string ID;

        [JsonProperty("ID_OVD")]
        public string ID_OVD;

        [JsonProperty("ID_D_SERIES")]
        public string ID_D_SERIES;

        [JsonProperty("D_NUMBER")]
        public string D_NUMBER;

        [JsonProperty("ID_D_TYPE")]
        public string ID_D_TYPE;

        [JsonProperty("ID_D_STATUS")]
        public string ID_D_STATUS;

        [JsonProperty("THEFT_DATA")]
        public string THEFT_DATA;

        [JsonProperty("INSERT_DATE")]
        public string INSERT_DATE;
    }
}

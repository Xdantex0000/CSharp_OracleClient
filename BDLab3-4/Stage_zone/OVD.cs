using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BDLab3_4
{
    class OVD
    {
        [JsonProperty("ID_OVD")]
        public string ID_OVD;
        [JsonProperty("OVD")]
        public string OVD_DATA;
    }
}

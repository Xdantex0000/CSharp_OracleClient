using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BDLab3_4
{
    class Status
    {
        [JsonProperty("ID_D_STATUS")]
        public string ID_D_STATUS;
        [JsonProperty("D_STATUS")]
        public string D_STATUS;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BDLab3_4
{
    class Types
    {
        [JsonProperty("ID_D_TYPE")]
        public string ID_D_TYPE;
        [JsonProperty("D_TYPE")]
        public string D_TYPE;
    }
}

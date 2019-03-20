using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Commission.Server.Models
{
    public class ReturnModel
    {
        [JsonProperty("code")]
        public ECode Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        public ReturnModel(ECode code, string msg, object data = null)
        {
            Code = code;
            Msg = msg;
            Data = data;
        }
    }
}


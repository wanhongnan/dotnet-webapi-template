using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using System.ComponentModel.DataAnnotations;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using Commission.Server.Models;
using static Commission.Server.ProviderModel;
using Commission.Server.Exceptions;

namespace Commission.Server
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("provider")]
    [Permission(EPermission.Any, Order = 3)]
    [ParamValid(Order = 2)]
    [AgentValidate(Order = 1)]
    [WebApiExceptionFilter]
    [JsonFormat]

    public class ProviderController : AgentController
    {
        [HttpGet("all")]
        public async Task<Company> All()
        {
            throw new FailException(ECode.PARAMETER_ERROR,"ddddd");
            return new Company();
        }

        [HttpPost("enable")]
        public async Task<bool> Enable([FromBody] EnableRequest req)
        {
            return true;
        }

        [HttpGet("records/{id}")]
        public async Task LogRecord(int id)
        {
            await Task.FromResult("");
        }
    }

    public class ProviderModel
    {
        public class Company
        {
            [JsonProperty("companyId")]
            public int CompanyId { get; set; }
            [JsonProperty("companyName")]
            public string CompanyName { get; set; }
            [JsonProperty("status")]
            public int Status { get; set; }
            [JsonProperty("numberOfNonclosed")]
            public int NumberOfNonclosed { get; set; }
            [JsonProperty("amountOfNonclosed")]
            public int AmountOfNonclosed { get; set; }
        }

        public class AllReturn : List<Company> { }

        public class EnableRequest
        {
            [JsonProperty("companyId")]
            [JsonRequired]
            public int CompanyId { get; set; }
            [JsonProperty("enable")]
            [JsonRequired, Range(0,1)]
            public int Enable { get; set; }
        }

        public class LogRecord
        {
            [JsonProperty("time")]
            public string Time { get; set; }
            [JsonProperty("content")]
            public string Content { get; set; }
            [JsonProperty("operator")]
            public string Operator { get; set; }
        }
    }
}


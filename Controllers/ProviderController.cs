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

namespace Commission.Server
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("provider")]
    [Permission(EPermission.Any, Order = 3)]
    [ParamValid(Order = 2)]
    [AgentValidate(Order = 1)]
    [WebApiExceptionFilter]
    public class ProviderController : AgentController
    {
        [HttpGet("all")]
        public async Task<ReturnModel> All()
        {
            var ret = new AllReturn();

            var sql = "select * from CompanyPortal;";
            var data = await MySqlHelper.ExecuteDatasetAsync(PlatformConnectionString, sql);
            foreach (DataRow row in data.Tables[0].Rows)
            {
                var cmp = new ProviderModel.Company() {
                    CompanyId = (int)row["CompanyId"],
                    CompanyName = (string)row["CompanyName"].ToMyString(),
                    Status = (int)row["Status"],
                    NumberOfNonclosed = (int)row["NumberOfNonclosed"],
                    AmountOfNonclosed = (int)row["AmountOfNonclosed"],
                };
                ret.Add(cmp);
            }
            return new ReturnModel(ECode.SUCCESS, "成功", ret);
        }

        [HttpPost("enable")]
        public async Task<ReturnModel> Enable([FromBody] EnableRequest req)
        {
            var sql = "update CompanyPortal set Status = @Status where CompanyId=@CompanyId";
            var ret = await MySqlHelper.ExecuteNonQueryAsync(PlatformConnectionString, sql
                , new MySqlParameter("@Status", req.Enable)
                , new MySqlParameter("@CompanyId", req.CompanyId)
                );
            if (ret == 1)
                return new ReturnModel(ECode.SUCCESS, "成功");
            else
                return new ReturnModel(ECode.DATA_UNEXIST, "失败");
        }

        [HttpGet("records/{id}")]
        public async Task<ReturnModel> LogRecord(int id)
        {
            var data = new List<LogRecord>();
            for (int i = 0; i < 10; i++)
            {
                var rec = new LogRecord() {
                    Time = "2019/12/12(三) 00:00:00",
                    Content = "test",
                    Operator = "pgk123",
                };
                data.Add(rec);
            }
            var ret = new ReturnModel(ECode.SUCCESS, "成功", data);
            return await Task.FromResult(ret);
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


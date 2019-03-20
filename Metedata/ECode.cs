using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Commission.Server.Models
{
    public enum ECode
    {
        Exception = -1,    //   异常
	    SUCCESS = 200, // 操作成功
	    FAIL = 202, //    操作失败
	    UNAUTHORIZED = 403, //    无权限
	    PARAMETER_ERROR = 400, // 参数错误
	    UNSIGNATURE = 401, // 签名无效
	    DATA_UNEXIST = 404, //   数据不存在
	    TOKEN_ERROR  = 405, // TOKEN不合法
	    DATA_EXIST = 409, //  数据已存在
	    SYSTEM_ERROR = 500, //   系统内部异常
	    USER_UNEXIST = 300, //   用户不存在
	    USER_BALANCE_INSUFFICIENT = 301, //  用户余额不足
	    Ticket_Billed = 410, //  订单已结算
    }
}


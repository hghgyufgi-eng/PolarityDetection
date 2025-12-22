using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisDummy.Protocols.Loading.Model
{
    public static  class ErrorEnum
    {
        public static string GetErrMessage(int errcode) => errcode switch
        {
            1 => "电芯尺寸异常",
            6 => "泡棉上无电芯",
            8 => "当前列电芯缺料",
            9 => "电芯中心点波动和高度异常",
            10 => "电芯高度异常",
            14 => "点云异常",
            _ =>"未知错误"
        };
    }
}

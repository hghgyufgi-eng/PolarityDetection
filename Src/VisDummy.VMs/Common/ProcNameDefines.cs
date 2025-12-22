namespace VisDummy.VMs.Common
{
    public static class ProcedureLoading2D_Defines
    {
        public const string 流程名 = "Loading";

        #region 流程输出参数
        public const string ImagePath = "ImagePath";
        public const string IncomingDirection = "IncomingDirection";
        public const string BarCode = "BarCode";
        public const string ErrorCode = "ErrorCode";
        #endregion

        #region 流程输入参数
        public const string Function = "Function";
        public const string Position = "Position";
        public const string Batch = "Batch";
        #endregion
    }

    public static class Procedure2DSpot_Defines
    {
        public const string 流程名 = "Precision";

        #region 流程输出参数
        public const string ImagePath = "ImagePath";
        public const string Feature = "Feature";
        public const string Pixel = "Pixel";
        public const string ErrorCode = "ErrorCode";
        #endregion

        #region 流程输入参数
        public const string Camera = "Camera";
        public const string Position = "Position";
        #endregion
    }

    public static class Procedure模组检测2D_Defines
    {
        public const string 流程名 = "ModuleInspection";

        #region 流程输出参数
        public const string ImagePath = "ImagePath";
        public const string Component = "Component";
        public const string Polarity1 = "Polarity1";
        public const string Polarity2 = "Polarity2";
        public const string Polarity3 = "Polarity3";
        public const string Polarity4 = "Polarity4";
        public const string Polarity5 = "Polarity5";
        public const string Polarity6 = "Polarity6";
        public const string Polarity7 = "Polarity7";
        public const string Polarity8 = "Polarity8";
        public const string Polarity9 = "Polarity9";
        public const string Polarity10 = "Polarity10";
        public const string Polarity11 = "Polarity11";
        public const string Polarity12 = "Polarity12";
        public const string Polarity13 = "Polarity13";
        public const string Polarity14 = "Polarity14";
        public const string Polarity15 = "Polarity15";
        public const string Polarity16 = "Polarity16";
        public const string Polarity17 = "Polarity17";
        public const string Polarity18 = "Polarity18";
        public const string Polarity19 = "Polarity19";
        public const string Polarity20 = "Polarity20";
        public const string ErrorCode = "ErrorCode";
        #endregion

        #region 流程输入参数
        public const string Function = "Function";
        public const string Position = "Position";
        public const string Batch = "Batch";
        #endregion
    }

    public static class Procedure模组贴标2D_Defines
    {
        public const string 流程名 = "Labeling";

        #region 流程输出参数
        public const string ImagePath = "ImagePath";
        public const string ErrorCode = "ErrorCode";
        public const string BarCode = "BarCode";
        #endregion

        #region 流程输入参数
        public const string Function = "Function";
        public const string Position = "Position";
        public const string Batch = "Batch";
        #endregion
    }

    public static class Procedure垫片检测12D_Defines
    {
        public const string 流程名 = "Gasket1";

        #region 流程输出参数
        public const string ImagePath = "ImagePath";
        public const string ErrorCode = "ErrorCode";
        #endregion

        #region 流程输入参数
        public const string Function = "Function";
        public const string Position = "Position";
        public const string Batch = "Batch";
        #endregion
    }
    public static class Procedure垫片检测22D_Defines
    {
        public const string 流程名 = "Gasket2";

        #region 流程输出参数
        public const string ImagePath = "ImagePath";
        public const string ErrorCode = "ErrorCode";
        #endregion

        #region 流程输入参数
        public const string Function = "Function";
        public const string Position = "Position";
        public const string Batch = "Batch";
        #endregion
    }
    public static class Procedure模组入箱12D_Defines
    {
        public const string 流程名 = "IntoBox1";

        #region 流程输出参数
        public const string ImagePath = "ImagePath"; 
        public const string ErrorCode = "ErrorCode";
        public const string OffsetX = "OffsetX";
        public const string OffsetY = "OffsetY";
        public const string OffsetA = "OffsetA";
        #endregion

        #region 流程输入参数
        public const string Function = "Function";
        public const string Position = "Position";
        public const string Batch = "Batch";
        #endregion
    }
    public static class Procedure模组入箱22D_Defines
    {
        public const string 流程名 = "IntoBox2";

        #region 流程输出参数
        public const string ImagePath = "ImagePath";
        public const string ErrorCode = "ErrorCode";
        public const string OffsetX = "OffsetX";
        public const string OffsetY = "OffsetY";
        public const string OffsetA = "OffsetA";
        #endregion

        #region 流程输入参数
        public const string Function = "Function";
        public const string Position = "Position";
        public const string Batch = "Batch";
        #endregion
    }

    public static class Procedure极性检测2D_Defines
    {
        public const string 流程名 = "极性检测1";

        #region 流程输出参数

        public const string 图像路径 = "图像路径";

        public const string 电芯码1 = "电芯码1";
        public const string 电芯码2 = "电芯码2";
        public const string 电芯1极性 = "电芯1极性";
        public const string 电芯2极性 = "电芯2极性";
        public const string 电芯1种类 = "电芯1种类";
        public const string 电芯2种类 = "电芯2种类";
        public const string 电芯1有无 = "电芯1有无";
        public const string 电芯2有无 = "电芯2有无";



        public const string 输入参数状态 = "输入参数状态";
        public const string 总输出状态 = "总输出状态";

        #endregion

        #region 流程输入参数
        public const string 功能号 = "功能号";
        public const string 拍照位置 = "拍照位置";
        public const string 批次号 = "批次号";
        public const string 拍照次数 = "拍照次数";
        #endregion
    }

    public static class Procedure极性检测2D1_Defines
    {
        public const string 流程名 = "极性检测2";

        #region 流程输出参数

        public const string 图像路径 = "图像路径";

        public const string 电芯码1 = "电芯码1";
        public const string 电芯码2 = "电芯码2";
        public const string 电芯1极性 = "电芯1极性";
        public const string 电芯2极性 = "电芯2极性";
        public const string 电芯1种类 = "电芯1种类";
        public const string 电芯2种类 = "电芯2种类";
        public const string 电芯1有无 = "电芯1有无";
        public const string 电芯2有无 = "电芯2有无";



        public const string 输入参数状态 = "输入参数状态";
        public const string 总输出状态 = "总输出状态";

        #endregion

        #region 流程输入参数
        public const string 功能号 = "功能号";
        public const string 拍照位置 = "拍照位置";
        public const string 批次号 = "批次号";
        public const string 拍照次数 = "拍照次数";
        #endregion
    }




    public static class Procedure大面贴胶检测12D_Defines
    {
        public const string 流程名 = "大面贴胶检测内";

        #region 流程输出参数
        public const string 图像路径 = "图像路径";

        public const string 无左电芯 = "无左电芯";
        public const string 无右电芯 = "无右电芯";
        public const string 无左胶料 = "无左胶料";
        public const string 无右胶料 = "无右胶料";
        public const string 左未撕纸 = "左未撕纸";
        public const string 右未撕纸 = "右未撕纸";
        public const string 输入参数状态 = "输入参数状态";
        public const string 总输出状态 = "总输出状态";

        #endregion

        #region 流程输入参数
        public const string 功能号 = "功能号";
        public const string 拍照位置 = "拍照位置";
        public const string 批次号 = "批次号";
        #endregion
    }

    public static class Procedure大面贴胶检测22D_Defines
    {
        public const string 流程名 = "大面贴胶检测外";

        #region 流程输出参数
        public const string 图像路径 = "图像路径";

        public const string 无左电芯 = "无左电芯";
        public const string 无右电芯 = "无右电芯";
        public const string 无左胶料 = "无左胶料";
        public const string 无右胶料 = "无右胶料";
        public const string 左未撕纸 = "左未撕纸";
        public const string 右未撕纸 = "右未撕纸";
        public const string 输入参数状态 = "输入参数状态";
        public const string 总输出状态 = "总输出状态";

        #endregion

        #region 流程输入参数
        public const string 功能号 = "功能号";
        public const string 拍照位置 = "拍照位置";
        public const string 批次号 = "批次号";
        #endregion
    }

    public static class Procedure大面贴胶检测32D_Defines
    {
        public const string 流程名 = "NG替换";

        #region 流程输出参数
        public const string 图像路径 = "图像路径";

        public const string 无电芯 = "无电芯";
        public const string 无胶料 = "无胶料";
        public const string 未撕纸 = "未撕纸";
        public const string 输入参数状态 = "输入参数状态";
        public const string 总输出状态 = "总输出状态";

        #endregion

        #region 流程输入参数
        public const string 功能号 = "功能号";
        public const string 拍照位置 = "拍照位置";
        public const string 批次号 = "批次号";
        #endregion
    }

    public static class Procedure大面贴胶检测2DSpot_Defines
    {
        public const string 流程名 = "大面自动校验";

        #region 流程输出参数

        public const string 图像路径 = "图像路径";
        public const string 总输出状态 = "总输出状态";
        public const string 特征大小 = "特征大小";
        public const string 像素精度 = "像素精度";

        #endregion

        #region 流程输入参数
        public const string 相机号 = "相机号";
        #endregion
    }


    public static class Procedure极性检测2DSpot_Defines
    {
        public const string 流程名 = "极性检测自动校验";

        #region 流程输出参数

        public const string 图像路径 = "图像路径";
        public const string 总输出状态 = "总输出状态";
        public const string 特征大小 = "特征大小";
        public const string 像素精度 = "像素精度";

        #endregion

        #region 流程输入参数
        public const string 相机号 = "相机号";
        #endregion
    }

    public static class Procedure侧面贴胶检测2D_Defines
    {
        public const string 流程名 = "检测流程";

        #region 流程输出参数
        public const string 电芯1图像路径 = "电芯1图像路径";
        public const string 电芯2图像路径 = "电芯2图像路径";
        public const string 电芯3图像路径 = "电芯3图像路径";
        public const string 电芯4图像路径 = "电芯4图像路径";

        public const string 电芯1左位置度 = "电芯1左位置度";
        public const string 电芯1右位置度 = "电芯1右位置度";
        public const string 电芯1上位置度 = "电芯1上位置度";

        public const string 电芯2左位置度 = "电芯2左位置度";
        public const string 电芯2右位置度 = "电芯2右位置度";
        public const string 电芯2上位置度 = "电芯2上位置度";

        public const string 电芯3左位置度 = "电芯3左位置度";
        public const string 电芯3右位置度 = "电芯3右位置度";
        public const string 电芯3上位置度 = "电芯3上位置度";

        public const string 电芯4左位置度 = "电芯4左位置度";
        public const string 电芯4右位置度 = "电芯4右位置度";
        public const string 电芯4上位置度 = "电芯4上位置度";

        public const string 电芯1NG = "电芯1NG";
        public const string 电芯2NG = "电芯2NG";
        public const string 电芯3NG = "电芯3NG";
        public const string 电芯4NG = "电芯4NG";

        public const string PLC参数NG = "PLC参数NG";
        public const string 找特征点NG = "找特征点NG";
        public const string 视觉流程NG = "视觉流程NG";
        public const string 总输出状态 = "总输出状态";

        #endregion

        #region 流程输入参数
        public const string 料号 = "料号";
        public const string 功能号 = "功能号";
        public const string 拍照位置号 = "拍照位置号";
        public const string 电芯码1 = "电芯码1";
        public const string 电芯码2 = "电芯码2";
        public const string 电芯码3 = "电芯码3";
        public const string 电芯码4 = "电芯码4";
        #endregion
    }

    public static class Procedure侧面贴胶检测2DSpot_Defines
    {
        public const string 流程名 = "校验流程";

        #region 流程输出参数

        public const string 找特征点NG = "找特征点NG";
        public const string 视觉流程NG = "视觉流程NG";

        public const string 总输出状态 = "总输出状态";

        public const string 相机校验NG = "相机校验NG";

        public const string 相机像素精度 = "相机像素精度";

        public const string 相机图像路径 = "相机图像路径";

        #endregion

    }

    public static class Procedure模组定位引导2DSpot_Defines
    {
        public const string 流程名 = "模组定位引导流程";

        #region 流程输出参数

        public const string PLC参数NG = "PLC参数NG";
        public const string 找特征点NG = "找特征点NG";
        public const string 视觉流程NG = "视觉流程NG";
        public const string 偏移量NG = "偏移量NG";
        public const string 模组长度NG = "模组长度NG";
        public const string 总输出状态 = "总输出状态";
        public const string 图像路径 = "图像路径";

        public const string X偏移量 = "X偏移量";
        public const string Y偏移量 = "Y偏移量";
        public const string A偏移量 = "A偏移量";
        public const string 模组长度 = "模组长度";

        #endregion

        #region 流程输入参数
        public const string 料号 = "料号";
        public const string 模组号 = "模组号";
        public const string 拍照位置 = "拍照位置";
        #endregion
    }

    public static class Procedure扫码判断流程2DSpot_Defines
    {
        public const string 流程名 = "扫码判断流程";

        #region 流程输出参数

        public const string PLC参数NG = "PLC参数NG";
        public const string 找特征点NG = "找特征点NG";
        public const string 极性NG = "极性NG";
        public const string 视觉流程NG = "视觉流程NG";
        public const string 总输出状态 = "总输出状态";
        public const string 图像路径 = "图像路径";

        public const string 电芯码1 = "电芯码1";
        public const string 电芯码2 = "电芯码2";

        #endregion

        #region 流程输入参数
        public const string 功能号 = "功能号";
        public const string 批次号 = "批次号";
        #endregion
    }


    public static class Procedure箱体定位引导2DSpot_Defines
    {
        public const string 流程名 = "箱体定位引导流程";

        #region 流程输出参数

        public const string 找特征点NG = "找特征点NG";
        public const string 视觉流程NG = "视觉流程NG";
        public const string PLC参数NG = "PLC参数NG";
        public const string 偏移量NG = "偏移量NG";
        public const string 间距NG = "间距NG";
        public const string 总输出状态 = "总输出状态";
        public const string 图像路径 = "图像路径";

        public const string X偏移量 = "X偏移量";
        public const string Y偏移量 = "Y偏移量";
        public const string A偏移量 = "A偏移量";

        #endregion

        #region 流程输入参数
        public const string 料号 = "料号";
        public const string 模组号 = "模组号";
        public const string 拍照位置 = "拍照位置";
        public const string Pack码 = "Pack码";
        #endregion
    }

    public static class Procedure底部拍照防呆流程2DSpot_Defines
    {
        public const string 流程名 = "底部拍照防呆流程";

        #region 流程输出参数

        public const string 视觉流程NG = "视觉流程NG";
        public const string 底部异物NG = "底部异物NG";
        public const string 总输出状态 = "总输出状态";
        public const string 图像路径 = "图像路径";

        #endregion

        #region 流程输入参数

        public const string 料号 = "料号";
        public const string Pack码 = "Pack码";

        #endregion
    }

    public static class Procedure校准流程2DSpot_Defines
    {
        public const string 流程名 = "校准流程";

        #region 流程输出参数

        public const string 找特征点NG = "找特征点NG";
        public const string 视觉流程NG = "视觉流程NG";
        public const string PLC参数NG = "PLC参数NG";
        public const string 偏移量NG = "偏移量NG";
        public const string 总输出状态 = "总输出状态";

        public const string 图像路径 = "图像路径";
        public const string 像素精度 = "像素精度";

        #endregion

        #region 流程输入参数

        public const string 料号 = "料号";
        public const string 相机号 = "相机号";

        #endregion
    }

    public static class Procedure自动标定流程2DSpot_Defines
    {
        public const string 流程名 = "自动标定流程";

        #region 流程输出参数

        public const string 找特征点NG = "找特征点NG";
        public const string 视觉流程NG = "视觉流程NG";
        public const string PLC参数NG = "PLC参数NG";
        public const string 总输出状态 = "总输出状态";

        public const string 图像路径 = "图像路径";

        #endregion

        #region 流程输入参数

        public const string 料号 = "料号";
        public const string 相机号 = "相机号";
        public const string 位置序号 = "位置序号";
        public const string 位置坐标X = "位置坐标X";
        public const string 位置坐标Y = "位置坐标Y";
        public const string 位置坐标A = "位置坐标A";

        #endregion
    }
}

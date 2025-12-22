using Microsoft.FSharp.Core;
using VisDummy.Abstractions.Args;
using VisDummy.Abstractions.Calibrations;
using VisDummy.Abstractions.Warp;

namespace VisDummy.Abstractions.Infra
{
    public interface IVisProc
    {
        /// <summary>
        /// 标定
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<FSharpResult<CalibarateNthPointOkWrap, IErr_CalibrateNthPoint>> CalibrateAsync(CalibrateNthPointArgs args);

        /// <summary>
        /// 大包装2D
        /// </summary>
        /// <returns></returns>
        Task<FSharpResult<StationOkWrap_Loading, StationErrWrap_Loading>> LoadingProcAsync(StationArgs args);
        /// <summary>
        /// 大包装点检
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<FSharpResult<SpotStationOkWarp, SpotStationErrWarp>> SpotProcAsync(SpotStationArgs args);

        /// <summary>
        /// 大面贴胶检测12D
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <returns></returns>
        Task<FSharpResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>> 大面贴胶检测1ProcAsync(StationArgs_Large args);

        /// <summary>
        /// 大面贴胶检测22D
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<FSharpResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>> 大面贴胶检测2ProcAsync(StationArgs_Large args);

        /// <summary>
        /// 大面贴胶检测NG替换
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<FSharpResult<StationOkWrap_大面贴胶检测, StationErrWrap_大面贴胶检测>> 大面贴胶检测NG替换ProcAsync(StationArgs_Large args);

        
        /// <summary>
        /// 大面贴胶检测校准
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<FSharpResult<SpotStationOkWarp_大面贴胶检测, SpotStationErrWarp_大面贴胶检测>> 大面贴胶检测SpotProcAsync(SpotStationArgs_Large args);


        /// <summary>
        /// 极性检测2D
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<FSharpResult<StationOkWrap_极性检测, StationErrWrap_极性检测>> 极性检测ProcAsync(StationArgs_Polarity args);


        /// <summary>
        /// 极性检测2D
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<FSharpResult<StationOkWrap_极性检测, StationErrWrap_极性检测>> 极性检测ProcAsync1(StationArgs_Polarity args);



        /// <summary>
        /// 大面贴胶检测校准
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<FSharpResult<SpotStationOkWarp_极性检测, SpotStationErrWarp_极性检测>> 极性检测SpotProcAsync(SpotStationArgs_JX args);


    }
}

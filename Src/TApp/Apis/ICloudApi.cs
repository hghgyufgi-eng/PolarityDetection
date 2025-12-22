using Refit;
using StdUnit.Zero.Shared;

namespace TApp.Apis;


public interface ICloudApi
{
    [Post("/api/Log/OperationLog/AddLog")]
    Task<Resp<object>> AddOperationLog(string operatorName, string record);
}
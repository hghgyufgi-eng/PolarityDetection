using Itminus.Middlewares;
using Microsoft.Extensions.Logging;
using VisDummy.Protocols.极性检测2.Middlewares;

namespace VisDummy.Protocols.极性检测2.Middlewares.Common
{
    public class FlushPending2Middleware : IWorkMiddleware<ScanContext>
    {
        private readonly ILogger<FlushPending2Middleware> _logger;
        private readonly 极性检测2Flusher _flusher;

        public FlushPending2Middleware(ILogger<FlushPending2Middleware> logger, 极性检测2Flusher flusher)
        {
            _logger = logger;
            _flusher = flusher;
        }

        public async Task InvokeAsync(ScanContext context, WorkDelegate<ScanContext> next)
        {
            try
            {
                await _flusher.FlushAsync(context.MstMsg);
            }
            finally
            {
                await next(context);
            }
        }
    }

}

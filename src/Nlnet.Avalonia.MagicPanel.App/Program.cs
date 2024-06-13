using System;
using Avalonia;
using Avalonia.Logging;
using Avalonia.ReactiveUI;
using Nlnet.Sharp;

namespace Nlnet.Avalonia.MagicPanel.App
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                BuildAvaloniaApp()
                    .StartWithClassicDesktopLifetime(args);
            }
            catch (Exception e)
            {
                typeof(App).Trace(e.ToString());
                if (e.InnerException != null)
                {
                    typeof(App).Trace(e.InnerException.ToString());
                }

                Logger.Sink?.Log(LogEventLevel.Error, nameof(Program), null, "{0}, {1}", e, e.InnerException);
            }
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        private static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI()
                .LogToLocalFile();
        }
    }
}

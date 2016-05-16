﻿using System;
using System.IO;
using System.Linq;
using AldursLab.WurmApi;
using AldursLab.WurmApi.Modules.Wurm.InstallDirectory;
using AldursLab.WurmAssistant3.Areas.Config.Modules;
using AldursLab.WurmAssistant3.Areas.Core.Components.Singletons;
using AldursLab.WurmAssistant3.Areas.Core.Contracts;
using AldursLab.WurmAssistant3.Areas.Logging.Contracts;
using AldursLab.WurmAssistant3.Areas.WurmApi.Contracts;
using AldursLab.WurmAssistant3.Areas.WurmApi.Modules;
using AldursLab.WurmAssistant3.Utils.IoC;
using Ninject;

namespace AldursLab.WurmAssistant3.Areas.WurmApi
{
    public static class WurmApiSetup
    {
        public static void TryAutodetectWurmInstallDir(IKernel kernel)
        {
            var consoleArgs = kernel.Get<IConsoleArgs>();
            try
            {
                if (!consoleArgs.WurmUnlimitedMode)
                {
                    var dir = WurmClientInstallDirectory.AutoDetect();
                    kernel.Bind<IWurmClientInstallDirectory>().ToConstant(dir);
                }
                // autodetection is not available for WurmUnlimited
                // todo: explore how to detect steam library path
            }
            catch (Exception exception)
            {
                kernel.LogCoreInfo(exception,
                    "Autodetection of Wurm Online Game Client failed. Reason: " + exception.Message);
            }
        }

        public static void BindSingletonApi(IKernel kernel)
        {
            var api = ConstructWurmApi(kernel);
            kernel.Bind<IWurmApi>().ToConstant(api);
            kernel.Bind<WurmClientValidator, IWurmClientValidator>().To<WurmClientValidator>().InSingletonScope();
        }

        public static void ValidateWurmGameClientConfig(IKernel kernel)
        {
            var validator = kernel.Get<WurmClientValidator>();
            if (!validator.SkipOnStart)
            {
                var issues = validator.Validate();
                if (issues.Any()) validator.ShowSummaryWindow(issues);
            }
        }

        static IWurmApi ConstructWurmApi(IKernel kernel)
        {
            var consoleArgs = kernel.Get<IConsoleArgs>();

            WurmAssistantConfig config = kernel.Get<WurmAssistantConfig>();
            IWurmApiLoggerFactory loggerFactory = kernel.Get<IWurmApiLoggerFactory>();
            IWurmAssistantDataDirectory dataDirectory = kernel.Get<IWurmAssistantDataDirectory>();
            IWurmApiEventMarshaller eventMarshaller = kernel.Get<IWurmApiEventMarshaller>();

            IWurmClientInstallDirectory wurmInstallDirectory = kernel.Get<IWurmClientInstallDirectory>();
            ServerInfoManager serverInfoManager = kernel.Get<ServerInfoManager>();

            WurmApiConfig wurmApiConfig;
            if (config.RunningPlatform != Platform.Unknown)
            {
                wurmApiConfig = new WurmApiConfig
                {
                    Platform = config.RunningPlatform,
                    ClearAllCaches = config.DropAllWurmApiCachesToggle,
                    WurmUnlimitedMode = consoleArgs.WurmUnlimitedMode
                };
                serverInfoManager.UpdateWurmApiConfigDictionary(wurmApiConfig.ServerInfoMap);
            }
            else
            {
                throw new InvalidOperationException("config.RunningPlatform is Unknown");
            }

            var wurmApiDataDir = new DirectoryInfo(Path.Combine(dataDirectory.DirectoryPath, "WurmApi"));

            var wurmApi = AldursLab.WurmApi.WurmApiFactory.Create(
                new WurmApiCreationOptions()
                {
                    DataDirPath = wurmApiDataDir.FullName,
                    WurmApiLogger = loggerFactory.Create(),
                    WurmApiEventMarshaller = eventMarshaller,
                    WurmClientInstallDirectory = wurmInstallDirectory,
                    WurmApiConfig = wurmApiConfig
                });

            config.DropAllWurmApiCachesToggle = false;

            return wurmApi;
        }
    }
}

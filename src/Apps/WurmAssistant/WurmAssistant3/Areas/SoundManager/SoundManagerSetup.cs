﻿using System.IO;
using AldursLab.WurmApi;
using AldursLab.WurmAssistant3.Areas.Config.Contracts;
using AldursLab.WurmAssistant3.Areas.Core.Contracts;
using AldursLab.WurmAssistant3.Areas.Features.Contracts;
using AldursLab.WurmAssistant3.Areas.SoundManager.Contracts;
using AldursLab.WurmAssistant3.Areas.SoundManager.Modules;
using AldursLab.WurmAssistant3.Areas.SoundManager.Modules.BuiltIn;
using AldursLab.WurmAssistant3.Areas.SoundManager.Modules.Irrklang;
using Ninject;

namespace AldursLab.WurmAssistant3.Areas.SoundManager
{
    public static class SoundManagerSetup
    {
        public static void Bind(IKernel kernel)
        {
            var dataDirectory = kernel.Get<IWurmAssistantDataDirectory>();
            var config = kernel.Get<IWurmAssistantConfig>();
            if (config.RunningPlatform == Platform.Windows)
            {
                kernel.Bind<ISoundEngine>().To<IrrklangSoundEngineProxy>().InSingletonScope();
            }
            else
            {
                kernel.Bind<ISoundEngine>().To<DefaultSoundEngine>().InSingletonScope();
            }

            kernel.Bind<Modules.SoundManager, ISoundManager>()
                  .To<Modules.SoundManager>()
                  .InSingletonScope();

            kernel.Bind<ISoundsLibrary>()
                  .To<SoundsLibrary>()
                  .InSingletonScope()
                  .WithConstructorArgument("soundFilesPath", Path.Combine(dataDirectory.DirectoryPath, "SoundBank"));

            kernel.Bind<IFeature>().ToMethod(context => context.Kernel.Get<Modules.SoundManager>()).Named("Sounds Manager");
        }
    }
}

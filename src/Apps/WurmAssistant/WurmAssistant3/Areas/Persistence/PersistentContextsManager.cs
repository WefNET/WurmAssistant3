﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using AldursLab.Persistence;
using AldursLab.Persistence.Simple;
using AldursLab.WurmAssistant3.Areas.Core;
using JetBrains.Annotations;

namespace AldursLab.WurmAssistant3.Areas.Persistence
{
    [KernelBind(BindingHint.Singleton), UsedImplicitly]
    class PersistentContextsManager : IPersistentContextProvider, IDisposable
    {
        const string ContextIdValidationPattern = @"^[a-zA-Z0-9\-]+$";

        readonly IWurmAssistantDataDirectory wurmAssistantDataDirectory;
        readonly Dictionary<string, PersistentContextContainer> activeContexts = new Dictionary<string, PersistentContextContainer>();
        readonly object locker = new object();

        readonly ITimer timer;

        public PersistentContextsManager([NotNull] IWurmAssistantDataDirectory wurmAssistantDataDirectory,
            [NotNull] ITimerFactory timerFactory)
        {
            if (wurmAssistantDataDirectory == null) throw new ArgumentNullException(nameof(wurmAssistantDataDirectory));
            if (timerFactory == null) throw new ArgumentNullException(nameof(timerFactory));
            this.wurmAssistantDataDirectory = wurmAssistantDataDirectory;
            
            timer = timerFactory.CreateUiThreadTimer();
            timer.Interval = TimeSpan.FromSeconds(15);
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        void TimerOnTick(object sender, EventArgs eventArgs)
        {
            PerformAutoSave(saveAll:false);
        }

        public IPersistentContext GetPersistentContext(string contextId, PersistentContextOptions options)
        {
            if (!Validate(contextId))
            {
                throw new InvalidOperationException($"Format of contextId is not valid. " +
                                                    $"Format must match regex \"{ContextIdValidationPattern}\" " +
                                                    $"(only letters, numbers and dashes, no whitespaces).");
            }

            contextId = contextId.ToLowerInvariant();

            lock (locker)
            {
                if (activeContexts.ContainsKey(contextId))
                {
                    throw new InvalidOperationException("Context with this contextId has already been provided. " +
                                                        "Context for each contextId can only be retrieved once.");
                }
                var context = CreatePersistentContext(contextId, options);
                activeContexts.Add(contextId, new PersistentContextContainer(context, options));
                return context;
            }
        }

        public IPersistentContext GetPersistentContext(string contextId)
        {
            return GetPersistentContext(contextId, new PersistentContextOptions());
        }

        public void PerformAutoSave(bool saveAll)
        {
            lock (locker)
            {
                foreach (var value in activeContexts.Values)
                {
                    if (!value.PersistentContextOptions.DisableAutoSaving)
                    {
                        if (saveAll)
                        {
                            value.PersistentContext.SaveAll();
                        }
                        else
                        {
                            value.PersistentContext.SaveChanged();
                        }
                    }
                }
            }
        }

        PersistentContext CreatePersistentContext(string contextId, PersistentContextOptions options)
        {
            ISerializer defaultJsonSerializer = options.SerializerOverride ?? new DefaultJsonSerializer();

            var dataStorePath = Path.Combine(wurmAssistantDataDirectory.DirectoryPath, "DataV2", contextId);
            IDataStorage dataStorage = options.DataStorageOverride ?? new SqLiteDataStorage(dataStorePath);

            return new PersistentContext(defaultJsonSerializer, dataStorage);
        }

        bool Validate(string contextId)
        {
            return Regex.IsMatch(contextId, ContextIdValidationPattern);
        }

        class PersistentContextContainer
        {
            public PersistentContext PersistentContext { get; private set; }
            public PersistentContextOptions PersistentContextOptions { get; private set; }

            public PersistentContextContainer(PersistentContext persistentContext, PersistentContextOptions persistentContextOptions)
            {
                PersistentContext = persistentContext;
                PersistentContextOptions = persistentContextOptions;
            }
        }

        public void Dispose()
        {
            timer.Stop();
            PerformAutoSave(saveAll: true);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AldurSoft.Core.Testing;
using AldurSoft.WurmApi.Infrastructure;
using AldurSoft.WurmApi.Logging;
using AldurSoft.WurmApi.Validation;
using AldurSoft.WurmApi.Wurm.Configs;
using AldurSoft.WurmApi.Wurm.Configs.WurmConfigDirectoriesModule;
using AldurSoft.WurmApi.Wurm.Configs.WurmConfigsModule;
using AldurSoft.WurmApi.Wurm.GameClients;
using AldurSoft.WurmApi.Wurm.Paths;
using AldurSoft.WurmApi.Wurm.Paths.WurmPathsModule;
using Moq;

using NUnit.Framework;

namespace AldurSoft.WurmApi.Tests.Tests.WurmConfigsImpl
{
    public class WurmConfigsTests : WurmApiFixtureBase
    {
        private const string CompactConfigName = "compact";

        [Test]
        public void ReadingConfig()
        {
            using (var frame = new MockFrame(this))
            {
                var wurmConfigs = frame.System;
                var config = wurmConfigs.GetConfig(CompactConfigName);
                Assert.AreEqual(LogsLocation.ProfileFolder, config.AutoRunSource);
                Assert.AreEqual(LogsLocation.PlayerFolder, config.CustomTimerSource);
                Assert.AreEqual(LogsLocation.ProfileFolder, config.ExecSource);

                Assert.AreEqual(LogSaveMode.Monthly, config.EventLoggingType);
                Assert.AreEqual(LogSaveMode.Monthly, config.IrcLoggingType);
                Assert.AreEqual(LogSaveMode.Monthly, config.OtherLoggingType);

                Assert.AreEqual(SkillGainRate.Per0D001, config.SkillGainRate);

                Assert.AreEqual(true, config.SaveSkillsOnQuit);
                Assert.AreEqual(true, config.TimestampMessages);
                Assert.AreEqual(false, config.NoSkillMessageOnAlignmentChange);
                Assert.AreEqual(false, config.NoSkillMessageOnFavorChange);
            }
        }

        [Test]
        public void ChangingConfig()
        {
            var wurmDir = CreateTestPakFromDir(Path.Combine(TestPaksDirFullPath, "WurmDir-configs"));
            // wurm dir has to be reused
            {
                using (var frame = new MockFrame(this, wurmDir))
                {
                    var wurmConfigs = frame.System;
                    var config = wurmConfigs.GetConfig(CompactConfigName);
                    config.EventLoggingType = LogSaveMode.Daily;
                    config.IrcLoggingType = LogSaveMode.Daily;
                    config.OtherLoggingType = LogSaveMode.Daily;
                    config.SkillGainRate = SkillGainRate.PerInteger;
                    config.SaveSkillsOnQuit = false;
                    config.TimestampMessages = false;
                    config.NoSkillMessageOnAlignmentChange = true;
                    config.NoSkillMessageOnFavorChange = true;
                    Assert.AreEqual(config.EventLoggingType, LogSaveMode.Daily);
                    Assert.AreEqual(config.IrcLoggingType, LogSaveMode.Daily);
                    Assert.AreEqual(config.OtherLoggingType, LogSaveMode.Daily);
                    Assert.AreEqual(config.SkillGainRate, SkillGainRate.PerInteger);
                    Assert.AreEqual(config.SaveSkillsOnQuit, false);
                    Assert.AreEqual(config.TimestampMessages, false);
                    Assert.AreEqual(config.NoSkillMessageOnAlignmentChange, true);
                    Assert.AreEqual(config.NoSkillMessageOnFavorChange, true);
                }
            }

            {
                using (var frame = new MockFrame(this, wurmDir))
                {
                    var wurmConfigs = frame.System;
                    var config = wurmConfigs.GetConfig(CompactConfigName);
                    Assert.AreEqual(config.EventLoggingType, LogSaveMode.Daily);
                    Assert.AreEqual(config.IrcLoggingType, LogSaveMode.Daily);
                    Assert.AreEqual(config.OtherLoggingType, LogSaveMode.Daily);
                    Assert.AreEqual(config.SkillGainRate, SkillGainRate.PerInteger);
                    Assert.AreEqual(config.SaveSkillsOnQuit, false);
                    Assert.AreEqual(config.TimestampMessages, false);
                    Assert.AreEqual(config.NoSkillMessageOnAlignmentChange, true);
                    Assert.AreEqual(config.NoSkillMessageOnFavorChange, true);
                }
            }
        }

        [Test]
        public async Task ChangeEvents()
        {
            var wurmDir = CreateTestPakFromDir(Path.Combine(TestPaksDirFullPath, "WurmDir-configs"));
            // wurm dir has to be reused
            {
                using (var frame = new MockFrame(this, wurmDir))
                {
                    var wurmConfigs = frame.System;
                    var config = wurmConfigs.GetConfig(CompactConfigName);
                    config.SkillGainRate = SkillGainRate.PerInteger;
                    await Task.Delay(TimeSpan.FromMilliseconds(5));
                    // expecting changewatcher event may fail, depends on file system response time
                    ((IRequireRefresh)config).Refresh();
                }
            }

            {
                using (var frame = new MockFrame(this, wurmDir))
                {
                    var wurmConfigs = frame.System;
                    var config = wurmConfigs.GetConfig(CompactConfigName);
                    Assert.AreEqual(SkillGainRate.PerInteger, config.SkillGainRate);
                }
            }
        }

        // since detection method is gone, checking if wurm is running is no longer applicable
        //[Test]
        //public void CantChangeIfWurmRunning()
        //{
        //    using (var frame = new MockFrame(this))
        //    {
        //        frame.WurmGameClients.Setup(clients => clients.AnyRunning).Returns(true);
        //        var wurmConfigs = frame.System;
        //        var config = wurmConfigs.GetConfig(CompactConfigName);
        //        Assert.Throws<WurmApiException>(() => config.EventLoggingType = LogSaveMode.Daily);
        //        Assert.Throws<WurmApiException>(() => config.IrcLoggingType = LogSaveMode.Daily);
        //        Assert.Throws<WurmApiException>(() => config.OtherLoggingType = LogSaveMode.Daily);
        //        Assert.Throws<WurmApiException>(() => config.SkillGainRate = SkillGainRate.PerInteger);
        //        Assert.Throws<WurmApiException>(() => config.SaveSkillsOnQuit = false);
        //        Assert.Throws<WurmApiException>(() => config.TimestampMessages = false);
        //        Assert.Throws<WurmApiException>(() => config.NoSkillMessageOnAlignmentChange = true);
        //        Assert.Throws<WurmApiException>(() => config.NoSkillMessageOnFavorChange = true);
        //    }
        //}

        [Test]
        public void Name_Gets()
        {
            using (var frame = new MockFrame(this))
            {
                var wurmConfigs = frame.System;
                var config = wurmConfigs.GetConfig(CompactConfigName);
                Expect(config.Name, EqualTo(CompactConfigName));
            }
        }

        private class MockFrame : IDisposable
        {
            private readonly WurmConfigsTests baseFixture;
            private TestPak wurmDir;

            public WurmConfigs System { get; private set; }
            public Mock<IWurmGameClients> WurmGameClients = new Mock<IWurmGameClients>();
            public Mock<IWurmInstallDirectory> WurmInstallDirectory = new Mock<IWurmInstallDirectory>();
            private readonly WurmConfigDirectories wurmConfigDirectories;

            public MockFrame(WurmConfigsTests baseFixture, TestPak wurmDir = null)
            {
                if (baseFixture == null)
                {
                    throw new ArgumentNullException("baseFixture");
                }

                if (wurmDir != null)
                {
                    this.wurmDir = wurmDir;
                }
                else
                {
                    this.wurmDir = baseFixture.CreateTestPakFromDir(Path.Combine(TestPaksDirFullPath, "WurmDir-configs"));
                }

                this.baseFixture = baseFixture;
                WurmInstallDirectory.Setup(directory => directory.FullPath)
                    .Returns(this.wurmDir.DirectoryFullPath);

                wurmConfigDirectories = new WurmConfigDirectories(new WurmPaths(WurmInstallDirectory.Object));
                System = new WurmConfigs(
                    WurmGameClients.Object,
                    wurmConfigDirectories,
                    Mock.Of<ILogger>(),
                    Mock.Of<IThreadGuard>());
            }

            public void Dispose()
            {
                System.Dispose();
                wurmConfigDirectories.Dispose();
            }
        }
    }
}

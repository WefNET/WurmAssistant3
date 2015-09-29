﻿using System;
using System.Windows.Forms;
using AldursLab.WurmAssistant3.Core.Areas.Config.Contracts;
using AldursLab.WurmAssistant3.Core.Root.Contracts;
using JetBrains.Annotations;

namespace AldursLab.WurmAssistant3.Core.Areas.MainMenu.Views
{
    public partial class MenuView : UserControl
    {
        readonly ISettingsEditViewFactory settingsEditViewFactory;
        readonly IProcessStarter processStarter;
        readonly IUserNotifier userNotifier;

        public MenuView([NotNull] ISettingsEditViewFactory settingsEditViewFactory,
            [NotNull] IProcessStarter processStarter, [NotNull] IUserNotifier userNotifier)
        {
            if (settingsEditViewFactory == null) throw new ArgumentNullException("settingsEditViewFactory");
            if (processStarter == null) throw new ArgumentNullException("processStarter");
            if (userNotifier == null) throw new ArgumentNullException("userNotifier");
            this.settingsEditViewFactory = settingsEditViewFactory;
            this.processStarter = processStarter;
            this.userNotifier = userNotifier;
            InitializeComponent();
        }

        private void changeSettingsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var view = settingsEditViewFactory.CreateSettingsEditView();
            view.ShowDialog();
        }

        private void officialForumToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            userNotifier.Notify("Not yet implemented");
        }

        private void wikiToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            userNotifier.Notify("Not yet implemented");
        }

        private void pMAldurToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            userNotifier.Notify("Not yet implemented");
        }

        private void contributorsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            userNotifier.Notify("Not yet implemented");
        }

        private void donatorsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            userNotifier.Notify("Not yet implemented");
        }

        private void viewRoadmapToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            userNotifier.Notify("Not yet implemented");
        }
    }
}
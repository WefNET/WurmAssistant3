﻿using System;
using AldursLab.WurmAssistant3.Utils.WinForms;
using JetBrains.Annotations;

namespace AldursLab.WurmAssistant3.Areas.Core
{
    [KernelBind]
    public partial class SendBugReportForm : ExtendedForm
    {
        readonly IProcessStarter processStarter;

        public SendBugReportForm([NotNull] IProcessStarter processStarter)
        {
            if (processStarter == null) throw new ArgumentNullException("processStarter");
            this.processStarter = processStarter;
            InitializeComponent();
        }

        private void postOnForumBtn_Click(object sender, EventArgs e)
        {
            processStarter.StartSafe(
                "http://forum.wurmonline.com/index.php?/topic/68031-wurm-assistant-enrich-your-wurm-experience/?view=getnewpost");
        }

        private void sendPmBtn_Click(object sender, EventArgs e)
        {
            processStarter.StartSafe(
                "http://forum.wurmonline.com/index.php?/user/6302-aldur/");
        }

        private void sendMailBtn_Click(object sender, EventArgs e)
        {
            processStarter.StartSafe(
                "mailto:aldurro@gmail.com?Subject=Wurm%20Assistant%203%20Bug%20Report");
        }
    }
}

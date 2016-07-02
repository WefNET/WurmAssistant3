﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AldursLab.WurmApi;
using AldursLab.WurmAssistant3.Areas.Granger.CreatureEdit;
using AldursLab.WurmAssistant3.Areas.Granger.DataLayer;
using AldursLab.WurmAssistant3.Areas.Granger.HorseEdit;
using AldursLab.WurmAssistant3.Areas.Logging;
using JetBrains.Annotations;

namespace AldursLab.WurmAssistant3.Areas.Granger
{
    public partial class UcGrangerHerdList : UserControl
    {
        FormGrangerMain mainForm;
        GrangerContext context;
        ILogger logger;
        IWurmApi wurmApi;

        public UcGrangerHerdList()
        {
            InitializeComponent();
        }

        public void Init(
            [NotNull] FormGrangerMain mainForm,
            [NotNull] GrangerContext context, 
            [NotNull] ILogger logger,
            [NotNull] IWurmApi wurmApi)
        {
            if (mainForm == null) throw new ArgumentNullException(nameof(mainForm));
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            if (wurmApi == null) throw new ArgumentNullException(nameof(wurmApi));
            this.mainForm = mainForm;
            this.context = context;
            this.logger = logger;
            this.wurmApi = wurmApi;

            CustomizeOlv();

            this.context.OnHerdsModified += RefreshHerdList;
            RefreshHerdList(this, EventArgs.Empty);
        }

        HerdEntity SelectedHerd => (HerdEntity)objectListView1.SelectedObject;

        void CustomizeOlv()
        {
            objectListView1.BooleanCheckStateGetter = new BrightIdeasSoftware.BooleanCheckStateGetterDelegate(x =>
            {
                HerdEntity entity = (HerdEntity)x;
                return entity.Selected;
            });
            objectListView1.BooleanCheckStatePutter = new BrightIdeasSoftware.BooleanCheckStatePutterDelegate((x, y) =>
            {
                HerdEntity entity = (HerdEntity)x;
                this.context.UpdateHerdSelectedState(entity.HerdID, y);
                return entity.Selected;
            });
        }

        public void RefreshHerdList(object sender, EventArgs e)
        {
            HerdEntity[] herds = context.Herds.ToArray();
            objectListView1.SetObjects(herds, true);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHerdName ui = new FormHerdName(context, mainForm, logger);
            ui.ShowDialogCenteredOnForm(mainForm);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selHerd = SelectedHerd;
            if (selHerd == null)
            {
                MessageBox.Show("Please select a herd first.");
            }
            else
            {
                FormHerdName ui = new FormHerdName(context, mainForm, logger, selHerd.HerdID);
                ui.ShowDialogCenteredOnForm(mainForm);
            }
        }

        private void combineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selHerd = SelectedHerd;
            if (selHerd == null)
            {
                MessageBox.Show("Please select a herd first.");
            }
            else
            {
                FormHerdMerge ui = new FormHerdMerge(context, mainForm, selHerd.HerdID, logger);
                ui.ShowDialogCenteredOnForm(mainForm);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selHerd = SelectedHerd;
            if (selHerd == null)
            {
                MessageBox.Show("Please select a herd first.");
            }
            else
            {
                CreatureEntity[] creatures = context.Creatures.Where(x => x.Herd == selHerd.HerdID).ToArray();
                if (MessageBox.Show(
                    $"Herd {selHerd}\r\n will be deleted. " +
                    $"All creatures in this herd will also be deleted:\r\n" +
                    $"{(creatures.Length == 0 ? "no creatures in this herd" : string.Join(", ", creatures.AsEnumerable()))}\r\n\r\nContinue?",
                    "confirm",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    context.DeleteHerd(selHerd.HerdID);
                }
            }
        }

        private void addCreatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selHerd = SelectedHerd;
            if (selHerd == null)
            {
                MessageBox.Show("Please select a herd first.");
            }
            else
            {
                FormCreatureViewEdit ui = new FormCreatureViewEdit(mainForm,
                    null,
                    context,
                    CreatureViewEditOpType.New,
                    selHerd.HerdID,
                    logger,
                    wurmApi);
                ui.ShowDialog();
            }
        }

        private void objectListView1_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            addCreatureToolStripMenuItem.Enabled =
                deleteToolStripMenuItem.Enabled =
                    combineToolStripMenuItem.Enabled =
                        renameToolStripMenuItem.Enabled =
                            e.Model != null;
        }
    }
}

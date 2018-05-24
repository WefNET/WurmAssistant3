﻿using AldursLab.WurmAssistant3.Utils.WinForms;

namespace AldursLab.WurmAssistant3.Areas.Granger
{
    partial class FormGrangerGeneralOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGrangerGeneralOptions));
            this.checkBoxAlwaysUpdateUnlessMultiples = new System.Windows.Forms.CheckBox();
            this.timeSpanInputGroomingTime = new AldursLab.WurmAssistant3.Utils.WinForms.TimeSpanInput();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxUpdateAgeHealthAllEvents = new System.Windows.Forms.CheckBox();
            this.checkBoxDisableRowColoring = new System.Windows.Forms.CheckBox();
            this.checkBoxAdjustForDarkThemes = new System.Windows.Forms.CheckBox();
            this.checkBoxUseServerNameAsIdComponent = new System.Windows.Forms.CheckBox();
            this.checkBoxhideLiveTrackerPopups = new System.Windows.Forms.CheckBox();
            this.checkBoxDoNotMatchCreaturesByBrandName = new System.Windows.Forms.CheckBox();
            this.checkBoxUpdateCreatureColorsOnSmilexamines = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxAlwaysUpdateUnlessMultiples
            // 
            this.checkBoxAlwaysUpdateUnlessMultiples.AutoSize = true;
            this.checkBoxAlwaysUpdateUnlessMultiples.Location = new System.Drawing.Point(12, 12);
            this.checkBoxAlwaysUpdateUnlessMultiples.Name = "checkBoxAlwaysUpdateUnlessMultiples";
            this.checkBoxAlwaysUpdateUnlessMultiples.Size = new System.Drawing.Size(320, 30);
            this.checkBoxAlwaysUpdateUnlessMultiples.TabIndex = 0;
            this.checkBoxAlwaysUpdateUnlessMultiples.Text = "Always update creature, regardless which herd they are in, \r\nunless multiple crea" +
    "tures with same name exist in the database";
            this.checkBoxAlwaysUpdateUnlessMultiples.UseVisualStyleBackColor = true;
            // 
            // timeSpanInputGroomingTime
            // 
            this.timeSpanInputGroomingTime.Location = new System.Drawing.Point(12, 357);
            this.timeSpanInputGroomingTime.Margin = new System.Windows.Forms.Padding(2);
            this.timeSpanInputGroomingTime.Name = "timeSpanInputGroomingTime";
            this.timeSpanInputGroomingTime.Size = new System.Drawing.Size(231, 45);
            this.timeSpanInputGroomingTime.TabIndex = 2;
            this.timeSpanInputGroomingTime.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(238, 445);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(92, 29);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "Accept";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(336, 445);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(92, 29);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hide time in grooming column, after this amount of time since last grooming:";
            // 
            // checkBoxUpdateAgeHealthAllEvents
            // 
            this.checkBoxUpdateAgeHealthAllEvents.AutoSize = true;
            this.checkBoxUpdateAgeHealthAllEvents.Location = new System.Drawing.Point(12, 48);
            this.checkBoxUpdateAgeHealthAllEvents.Name = "checkBoxUpdateAgeHealthAllEvents";
            this.checkBoxUpdateAgeHealthAllEvents.Size = new System.Drawing.Size(319, 30);
            this.checkBoxUpdateAgeHealthAllEvents.TabIndex = 6;
            this.checkBoxUpdateAgeHealthAllEvents.Text = "Try to update creature age and health data from any log event\r\n(when unchecked, u" +
    "pdates only when smile-examining)";
            this.checkBoxUpdateAgeHealthAllEvents.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisableRowColoring
            // 
            this.checkBoxDisableRowColoring.AutoSize = true;
            this.checkBoxDisableRowColoring.Location = new System.Drawing.Point(12, 84);
            this.checkBoxDisableRowColoring.Name = "checkBoxDisableRowColoring";
            this.checkBoxDisableRowColoring.Size = new System.Drawing.Size(183, 17);
            this.checkBoxDisableRowColoring.TabIndex = 7;
            this.checkBoxDisableRowColoring.Text = "Disable grid row color highlighting";
            this.checkBoxDisableRowColoring.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdjustForDarkThemes
            // 
            this.checkBoxAdjustForDarkThemes.AutoSize = true;
            this.checkBoxAdjustForDarkThemes.Location = new System.Drawing.Point(12, 107);
            this.checkBoxAdjustForDarkThemes.Name = "checkBoxAdjustForDarkThemes";
            this.checkBoxAdjustForDarkThemes.Size = new System.Drawing.Size(292, 30);
            this.checkBoxAdjustForDarkThemes.TabIndex = 8;
            this.checkBoxAdjustForDarkThemes.Text = "Fix issues when using dark high-contrast windows theme\r\n(Wurm Assistant restart r" +
    "equired)";
            this.checkBoxAdjustForDarkThemes.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseServerNameAsIdComponent
            // 
            this.checkBoxUseServerNameAsIdComponent.AutoSize = true;
            this.checkBoxUseServerNameAsIdComponent.Location = new System.Drawing.Point(12, 143);
            this.checkBoxUseServerNameAsIdComponent.Name = "checkBoxUseServerNameAsIdComponent";
            this.checkBoxUseServerNameAsIdComponent.Size = new System.Drawing.Size(376, 69);
            this.checkBoxUseServerNameAsIdComponent.TabIndex = 9;
            this.checkBoxUseServerNameAsIdComponent.Text = resources.GetString("checkBoxUseServerNameAsIdComponent.Text");
            this.checkBoxUseServerNameAsIdComponent.UseVisualStyleBackColor = true;
            // 
            // checkBoxhideLiveTrackerPopups
            // 
            this.checkBoxhideLiveTrackerPopups.AutoSize = true;
            this.checkBoxhideLiveTrackerPopups.Location = new System.Drawing.Point(12, 218);
            this.checkBoxhideLiveTrackerPopups.Name = "checkBoxhideLiveTrackerPopups";
            this.checkBoxhideLiveTrackerPopups.Size = new System.Drawing.Size(324, 17);
            this.checkBoxhideLiveTrackerPopups.TabIndex = 10;
            this.checkBoxhideLiveTrackerPopups.Text = "Hide popups from creature updates triggered by live log events.";
            this.checkBoxhideLiveTrackerPopups.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoNotMatchCreaturesByBrandName
            // 
            this.checkBoxDoNotMatchCreaturesByBrandName.AutoSize = true;
            this.checkBoxDoNotMatchCreaturesByBrandName.Location = new System.Drawing.Point(12, 241);
            this.checkBoxDoNotMatchCreaturesByBrandName.Name = "checkBoxDoNotMatchCreaturesByBrandName";
            this.checkBoxDoNotMatchCreaturesByBrandName.Size = new System.Drawing.Size(411, 56);
            this.checkBoxDoNotMatchCreaturesByBrandName.TabIndex = 11;
            this.checkBoxDoNotMatchCreaturesByBrandName.Text = resources.GetString("checkBoxDoNotMatchCreaturesByBrandName.Text");
            this.checkBoxDoNotMatchCreaturesByBrandName.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpdateCreatureColorsOnSmilexamines
            // 
            this.checkBoxUpdateCreatureColorsOnSmilexamines.AutoSize = true;
            this.checkBoxUpdateCreatureColorsOnSmilexamines.Location = new System.Drawing.Point(12, 303);
            this.checkBoxUpdateCreatureColorsOnSmilexamines.Name = "checkBoxUpdateCreatureColorsOnSmilexamines";
            this.checkBoxUpdateCreatureColorsOnSmilexamines.Size = new System.Drawing.Size(295, 30);
            this.checkBoxUpdateCreatureColorsOnSmilexamines.TabIndex = 12;
            this.checkBoxUpdateCreatureColorsOnSmilexamines.Text = "Update creature colors on SmileXamines.\r\n(If disabled, color will be set only on " +
    "adding new creature)";
            this.checkBoxUpdateCreatureColorsOnSmilexamines.UseVisualStyleBackColor = true;
            // 
            // FormGrangerGeneralOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 486);
            this.Controls.Add(this.checkBoxUpdateCreatureColorsOnSmilexamines);
            this.Controls.Add(this.checkBoxDoNotMatchCreaturesByBrandName);
            this.Controls.Add(this.checkBoxhideLiveTrackerPopups);
            this.Controls.Add(this.checkBoxUseServerNameAsIdComponent);
            this.Controls.Add(this.checkBoxAdjustForDarkThemes);
            this.Controls.Add(this.checkBoxDisableRowColoring);
            this.Controls.Add(this.checkBoxUpdateAgeHealthAllEvents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.timeSpanInputGroomingTime);
            this.Controls.Add(this.checkBoxAlwaysUpdateUnlessMultiples);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGrangerGeneralOptions";
            this.ShowIcon = false;
            this.Text = "Granger general options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAlwaysUpdateUnlessMultiples;
        private TimeSpanInput timeSpanInputGroomingTime;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxUpdateAgeHealthAllEvents;
        private System.Windows.Forms.CheckBox checkBoxDisableRowColoring;
        private System.Windows.Forms.CheckBox checkBoxAdjustForDarkThemes;
        private System.Windows.Forms.CheckBox checkBoxUseServerNameAsIdComponent;
        private System.Windows.Forms.CheckBox checkBoxhideLiveTrackerPopups;
        private System.Windows.Forms.CheckBox checkBoxDoNotMatchCreaturesByBrandName;
        private System.Windows.Forms.CheckBox checkBoxUpdateCreatureColorsOnSmilexamines;
    }
}
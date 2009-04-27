/* 
 * Copyright 2008 - 2009, Haiku, Inc. All Rights Reserved. 
 * Distributed under the terms of the MIT License. 
 * 
 * Authors: 
 *         Fredrik Modéen, (Firstname@lastname.se)
 */ 

namespace Haiku
{
    partial class HaikuOnAStick
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HaikuOnAStick));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.grpBoxDownload = new System.Windows.Forms.GroupBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblFromServer = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.cmbImage = new System.Windows.Forms.ComboBox();
            this.labl1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkListBox = new System.Windows.Forms.CheckedListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnWriteToUSB = new System.Windows.Forms.Button();
            this.lblAction = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxBrowse = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBWriterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useDDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useFlashnulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpBoxDownload.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpBoxBrowse.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.AccessibleDescription = null;
            this.btnBrowse.AccessibleName = null;
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.BackgroundImage = null;
            this.btnBrowse.Font = null;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // grpBoxDownload
            // 
            this.grpBoxDownload.AccessibleDescription = null;
            this.grpBoxDownload.AccessibleName = null;
            resources.ApplyResources(this.grpBoxDownload, "grpBoxDownload");
            this.grpBoxDownload.BackgroundImage = null;
            this.grpBoxDownload.Controls.Add(this.lblImage);
            this.grpBoxDownload.Controls.Add(this.lblFromServer);
            this.grpBoxDownload.Controls.Add(this.cmbServer);
            this.grpBoxDownload.Controls.Add(this.cmbImage);
            this.grpBoxDownload.Font = null;
            this.grpBoxDownload.Name = "grpBoxDownload";
            this.grpBoxDownload.TabStop = false;
            // 
            // lblImage
            // 
            this.lblImage.AccessibleDescription = null;
            this.lblImage.AccessibleName = null;
            resources.ApplyResources(this.lblImage, "lblImage");
            this.lblImage.Font = null;
            this.lblImage.Name = "lblImage";
            // 
            // lblFromServer
            // 
            this.lblFromServer.AccessibleDescription = null;
            this.lblFromServer.AccessibleName = null;
            resources.ApplyResources(this.lblFromServer, "lblFromServer");
            this.lblFromServer.Font = null;
            this.lblFromServer.Name = "lblFromServer";
            // 
            // cmbServer
            // 
            this.cmbServer.AccessibleDescription = null;
            this.cmbServer.AccessibleName = null;
            resources.ApplyResources(this.cmbServer, "cmbServer");
            this.cmbServer.BackgroundImage = null;
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.Font = null;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
            // 
            // cmbImage
            // 
            this.cmbImage.AccessibleDescription = null;
            this.cmbImage.AccessibleName = null;
            resources.ApplyResources(this.cmbImage, "cmbImage");
            this.cmbImage.BackgroundImage = null;
            this.cmbImage.Font = null;
            this.cmbImage.FormattingEnabled = true;
            this.cmbImage.Name = "cmbImage";
            this.cmbImage.SelectedIndexChanged += new System.EventHandler(this.cmbImage_SelectedIndexChanged);
            // 
            // labl1
            // 
            this.labl1.AccessibleDescription = null;
            this.labl1.AccessibleName = null;
            resources.ApplyResources(this.labl1, "labl1");
            this.labl1.Font = null;
            this.labl1.Name = "labl1";
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = null;
            this.groupBox3.AccessibleName = null;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackgroundImage = null;
            this.groupBox3.Controls.Add(this.chkListBox);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Font = null;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chkListBox
            // 
            this.chkListBox.AccessibleDescription = null;
            this.chkListBox.AccessibleName = null;
            resources.ApplyResources(this.chkListBox, "chkListBox");
            this.chkListBox.BackgroundImage = null;
            this.chkListBox.CheckOnClick = true;
            this.chkListBox.Font = null;
            this.chkListBox.FormattingEnabled = true;
            this.chkListBox.Name = "chkListBox";
            // 
            // btnRefresh
            // 
            this.btnRefresh.AccessibleDescription = null;
            this.btnRefresh.AccessibleName = null;
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.BackgroundImage = null;
            this.btnRefresh.Font = null;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.AccessibleDescription = null;
            this.richTextBox.AccessibleName = null;
            resources.ApplyResources(this.richTextBox, "richTextBox");
            this.richTextBox.BackgroundImage = null;
            this.richTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox.Font = null;
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleDescription = null;
            this.progressBar1.AccessibleName = null;
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.BackgroundImage = null;
            this.progressBar1.Font = null;
            this.progressBar1.Name = "progressBar1";
            // 
            // btnWriteToUSB
            // 
            this.btnWriteToUSB.AccessibleDescription = null;
            this.btnWriteToUSB.AccessibleName = null;
            resources.ApplyResources(this.btnWriteToUSB, "btnWriteToUSB");
            this.btnWriteToUSB.BackgroundImage = null;
            this.btnWriteToUSB.Font = null;
            this.btnWriteToUSB.Name = "btnWriteToUSB";
            this.btnWriteToUSB.UseVisualStyleBackColor = true;
            this.btnWriteToUSB.Click += new System.EventHandler(this.btnWriteToUSB_Click);
            // 
            // lblAction
            // 
            this.lblAction.AccessibleDescription = null;
            this.lblAction.AccessibleName = null;
            resources.ApplyResources(this.lblAction, "lblAction");
            this.lblAction.Font = null;
            this.lblAction.Name = "lblAction";
            // 
            // progressBar2
            // 
            this.progressBar2.AccessibleDescription = null;
            this.progressBar2.AccessibleName = null;
            resources.ApplyResources(this.progressBar2, "progressBar2");
            this.progressBar2.BackgroundImage = null;
            this.progressBar2.Font = null;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Step = 1;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.Font = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpBoxBrowse
            // 
            this.grpBoxBrowse.AccessibleDescription = null;
            this.grpBoxBrowse.AccessibleName = null;
            resources.ApplyResources(this.grpBoxBrowse, "grpBoxBrowse");
            this.grpBoxBrowse.BackgroundImage = null;
            this.grpBoxBrowse.Controls.Add(this.btnBrowse);
            this.grpBoxBrowse.Font = null;
            this.grpBoxBrowse.Name = "grpBoxBrowse";
            this.grpBoxBrowse.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleDescription = null;
            this.menuStrip1.AccessibleName = null;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackgroundImage = null;
            this.menuStrip1.Font = null;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AccessibleDescription = null;
            this.fileToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.BackgroundImage = null;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSBWriterToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // uSBWriterToolStripMenuItem
            // 
            this.uSBWriterToolStripMenuItem.AccessibleDescription = null;
            this.uSBWriterToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.uSBWriterToolStripMenuItem, "uSBWriterToolStripMenuItem");
            this.uSBWriterToolStripMenuItem.BackgroundImage = null;
            this.uSBWriterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useDDToolStripMenuItem,
            this.useFlashnulToolStripMenuItem});
            this.uSBWriterToolStripMenuItem.Name = "uSBWriterToolStripMenuItem";
            this.uSBWriterToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // useDDToolStripMenuItem
            // 
            this.useDDToolStripMenuItem.AccessibleDescription = null;
            this.useDDToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.useDDToolStripMenuItem, "useDDToolStripMenuItem");
            this.useDDToolStripMenuItem.BackgroundImage = null;
            this.useDDToolStripMenuItem.CheckOnClick = true;
            this.useDDToolStripMenuItem.Name = "useDDToolStripMenuItem";
            this.useDDToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.useDDToolStripMenuItem.Click += new System.EventHandler(this.dDToolStripMenuItem_Click);
            // 
            // useFlashnulToolStripMenuItem
            // 
            this.useFlashnulToolStripMenuItem.AccessibleDescription = null;
            this.useFlashnulToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.useFlashnulToolStripMenuItem, "useFlashnulToolStripMenuItem");
            this.useFlashnulToolStripMenuItem.BackgroundImage = null;
            this.useFlashnulToolStripMenuItem.Checked = true;
            this.useFlashnulToolStripMenuItem.CheckOnClick = true;
            this.useFlashnulToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useFlashnulToolStripMenuItem.Name = "useFlashnulToolStripMenuItem";
            this.useFlashnulToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.useFlashnulToolStripMenuItem.Click += new System.EventHandler(this.useToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.AccessibleDescription = null;
            this.closeToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.BackgroundImage = null;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // HaikuOnAStick
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grpBoxBrowse);
            this.Controls.Add(this.labl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnWriteToUSB);
            this.Controls.Add(this.grpBoxDownload);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = null;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HaikuOnAStick";
            this.grpBoxDownload.ResumeLayout(false);
            this.grpBoxDownload.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.grpBoxBrowse.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxDownload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label labl1;
        private System.Windows.Forms.ComboBox cmbImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnWriteToUSB;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblFromServer;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpBoxBrowse;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSBWriterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useDDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useFlashnulToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox chkListBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}


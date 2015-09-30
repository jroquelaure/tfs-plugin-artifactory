namespace JFrogTFSPlugin.CustomTypes
{
    partial class ArtifactoryConfigurationDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtifactoryConfigurationDialog));
            this.ProxySettings_gp = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ProxyPassword_txt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ProxyPort_txt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ProxyUser_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ProxyHost_txt = new System.Windows.Forms.TextBox();
            this.ArtifactoryUrl_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TargetRepo_txt = new System.Windows.Forms.TextBox();
            this.ArtifactoryUser_txt = new System.Windows.Forms.TextBox();
            this.ArtifactoryPassword_txt = new System.Windows.Forms.TextBox();
            this.FolderToDeploy_txt = new System.Windows.Forms.TextBox();
            this.IncludePatterns_txt = new System.Windows.Forms.TextBox();
            this.ExcludePatterns_txt = new System.Windows.Forms.TextBox();
            this.ProxyEnabled_ck = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TimeOut_txt = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Ok_bt = new System.Windows.Forms.Button();
            this.Cancel_bt = new System.Windows.Forms.Button();
            this.NotFlatDeploy_ck = new System.Windows.Forms.CheckBox();
            this.BuildInfo_ck = new System.Windows.Forms.CheckBox();
            this.ProxySettings_gp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOut_txt)).BeginInit();
            this.SuspendLayout();
            // 
            // ProxySettings_gp
            // 
            this.ProxySettings_gp.Controls.Add(this.label12);
            this.ProxySettings_gp.Controls.Add(this.ProxyPassword_txt);
            this.ProxySettings_gp.Controls.Add(this.label11);
            this.ProxySettings_gp.Controls.Add(this.ProxyPort_txt);
            this.ProxySettings_gp.Controls.Add(this.label9);
            this.ProxySettings_gp.Controls.Add(this.ProxyUser_txt);
            this.ProxySettings_gp.Controls.Add(this.label8);
            this.ProxySettings_gp.Controls.Add(this.ProxyHost_txt);
            this.ProxySettings_gp.Location = new System.Drawing.Point(12, 403);
            this.ProxySettings_gp.Name = "ProxySettings_gp";
            this.ProxySettings_gp.Size = new System.Drawing.Size(902, 207);
            this.ProxySettings_gp.TabIndex = 20;
            this.ProxySettings_gp.TabStop = false;
            this.ProxySettings_gp.Text = "Proxy Settings";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "Password";
            // 
            // ProxyPassword_txt
            // 
            this.ProxyPassword_txt.Location = new System.Drawing.Point(199, 172);
            this.ProxyPassword_txt.Name = "ProxyPassword_txt";
            this.ProxyPassword_txt.Size = new System.Drawing.Size(697, 22);
            this.ProxyPassword_txt.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 3;
            this.label11.Text = "Proxy Port";
            // 
            // ProxyPort_txt
            // 
            this.ProxyPort_txt.Location = new System.Drawing.Point(199, 80);
            this.ProxyPort_txt.Name = "ProxyPort_txt";
            this.ProxyPort_txt.Size = new System.Drawing.Size(115, 22);
            this.ProxyPort_txt.TabIndex = 4;
            this.ProxyPort_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProxyPort_txt_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "User";
            // 
            // ProxyUser_txt
            // 
            this.ProxyUser_txt.Location = new System.Drawing.Point(199, 126);
            this.ProxyUser_txt.Name = "ProxyUser_txt";
            this.ProxyUser_txt.Size = new System.Drawing.Size(697, 22);
            this.ProxyUser_txt.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Proxy Host";
            // 
            // ProxyHost_txt
            // 
            this.ProxyHost_txt.Location = new System.Drawing.Point(199, 34);
            this.ProxyHost_txt.Name = "ProxyHost_txt";
            this.ProxyHost_txt.Size = new System.Drawing.Size(697, 22);
            this.ProxyHost_txt.TabIndex = 2;
            // 
            // ArtifactoryUrl_txt
            // 
            this.ArtifactoryUrl_txt.Location = new System.Drawing.Point(206, 13);
            this.ArtifactoryUrl_txt.Name = "ArtifactoryUrl_txt";
            this.ArtifactoryUrl_txt.Size = new System.Drawing.Size(708, 22);
            this.ArtifactoryUrl_txt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Artifactory URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target Repository";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "User login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Folder to deploy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Include Patterns";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Exclude Patterns";
            // 
            // TargetRepo_txt
            // 
            this.TargetRepo_txt.Location = new System.Drawing.Point(400, 60);
            this.TargetRepo_txt.Name = "TargetRepo_txt";
            this.TargetRepo_txt.Size = new System.Drawing.Size(514, 22);
            this.TargetRepo_txt.TabIndex = 4;
            // 
            // ArtifactoryUser_txt
            // 
            this.ArtifactoryUser_txt.Location = new System.Drawing.Point(400, 103);
            this.ArtifactoryUser_txt.Name = "ArtifactoryUser_txt";
            this.ArtifactoryUser_txt.Size = new System.Drawing.Size(257, 22);
            this.ArtifactoryUser_txt.TabIndex = 6;
            // 
            // ArtifactoryPassword_txt
            // 
            this.ArtifactoryPassword_txt.Location = new System.Drawing.Point(400, 146);
            this.ArtifactoryPassword_txt.Name = "ArtifactoryPassword_txt";
            this.ArtifactoryPassword_txt.Size = new System.Drawing.Size(257, 22);
            this.ArtifactoryPassword_txt.TabIndex = 8;
            // 
            // FolderToDeploy_txt
            // 
            this.FolderToDeploy_txt.Location = new System.Drawing.Point(206, 185);
            this.FolderToDeploy_txt.Name = "FolderToDeploy_txt";
            this.FolderToDeploy_txt.Size = new System.Drawing.Size(708, 22);
            this.FolderToDeploy_txt.TabIndex = 10;
            // 
            // IncludePatterns_txt
            // 
            this.IncludePatterns_txt.Location = new System.Drawing.Point(206, 228);
            this.IncludePatterns_txt.Name = "IncludePatterns_txt";
            this.IncludePatterns_txt.Size = new System.Drawing.Size(708, 22);
            this.IncludePatterns_txt.TabIndex = 12;
            // 
            // ExcludePatterns_txt
            // 
            this.ExcludePatterns_txt.Location = new System.Drawing.Point(206, 271);
            this.ExcludePatterns_txt.Name = "ExcludePatterns_txt";
            this.ExcludePatterns_txt.Size = new System.Drawing.Size(708, 22);
            this.ExcludePatterns_txt.TabIndex = 16;
            // 
            // ProxyEnabled_ck
            // 
            this.ProxyEnabled_ck.AutoSize = true;
            this.ProxyEnabled_ck.Location = new System.Drawing.Point(16, 376);
            this.ProxyEnabled_ck.Name = "ProxyEnabled_ck";
            this.ProxyEnabled_ck.Size = new System.Drawing.Size(130, 21);
            this.ProxyEnabled_ck.TabIndex = 19;
            this.ProxyEnabled_ck.Text = "Configure Proxy";
            this.ProxyEnabled_ck.UseVisualStyleBackColor = true;
            this.ProxyEnabled_ck.CheckedChanged += new System.EventHandler(this.ProxyEnabled_ck_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Timeout";
            // 
            // TimeOut_txt
            // 
            this.TimeOut_txt.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TimeOut_txt.Location = new System.Drawing.Point(206, 345);
            this.TimeOut_txt.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.TimeOut_txt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeOut_txt.Name = "TimeOut_txt";
            this.TimeOut_txt.Size = new System.Drawing.Size(120, 22);
            this.TimeOut_txt.TabIndex = 18;
            this.TimeOut_txt.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // Ok_bt
            // 
            this.Ok_bt.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok_bt.Location = new System.Drawing.Point(746, 625);
            this.Ok_bt.Name = "Ok_bt";
            this.Ok_bt.Size = new System.Drawing.Size(75, 23);
            this.Ok_bt.TabIndex = 21;
            this.Ok_bt.Text = "OK";
            this.Ok_bt.UseVisualStyleBackColor = true;
            // 
            // Cancel_bt
            // 
            this.Cancel_bt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_bt.Location = new System.Drawing.Point(839, 625);
            this.Cancel_bt.Name = "Cancel_bt";
            this.Cancel_bt.Size = new System.Drawing.Size(75, 23);
            this.Cancel_bt.TabIndex = 22;
            this.Cancel_bt.Text = "Cancel";
            this.Cancel_bt.UseVisualStyleBackColor = true;
            // 
            // NotFlatDeploy_ck
            // 
            this.NotFlatDeploy_ck.AutoSize = true;
            this.NotFlatDeploy_ck.Checked = true;
            this.NotFlatDeploy_ck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NotFlatDeploy_ck.Location = new System.Drawing.Point(206, 308);
            this.NotFlatDeploy_ck.Name = "NotFlatDeploy_ck";
            this.NotFlatDeploy_ck.Size = new System.Drawing.Size(193, 21);
            this.NotFlatDeploy_ck.TabIndex = 23;
            this.NotFlatDeploy_ck.Text = "Conserve folder hierarchy";
            this.NotFlatDeploy_ck.UseVisualStyleBackColor = true;
            // 
            // BuildInfo_ck
            // 
            this.BuildInfo_ck.AutoSize = true;
            this.BuildInfo_ck.Location = new System.Drawing.Point(16, 308);
            this.BuildInfo_ck.Name = "BuildInfo_ck";
            this.BuildInfo_ck.Size = new System.Drawing.Size(136, 21);
            this.BuildInfo_ck.TabIndex = 24;
            this.BuildInfo_ck.Text = "Enable Build Info";
            this.BuildInfo_ck.UseVisualStyleBackColor = true;
            // 
            // ArtifactoryConfigurationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 665);
            this.Controls.Add(this.BuildInfo_ck);
            this.Controls.Add(this.NotFlatDeploy_ck);
            this.Controls.Add(this.Cancel_bt);
            this.Controls.Add(this.Ok_bt);
            this.Controls.Add(this.ProxyEnabled_ck);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TimeOut_txt);
            this.Controls.Add(this.ExcludePatterns_txt);
            this.Controls.Add(this.IncludePatterns_txt);
            this.Controls.Add(this.FolderToDeploy_txt);
            this.Controls.Add(this.ArtifactoryPassword_txt);
            this.Controls.Add(this.ArtifactoryUser_txt);
            this.Controls.Add(this.TargetRepo_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ArtifactoryUrl_txt);
            this.Controls.Add(this.ProxySettings_gp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArtifactoryConfigurationDialog";
            this.Text = "Artifactory Plugin Configuration";
            this.ProxySettings_gp.ResumeLayout(false);
            this.ProxySettings_gp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOut_txt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ProxySettings_gp;
        private System.Windows.Forms.TextBox ArtifactoryUrl_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TargetRepo_txt;
        private System.Windows.Forms.TextBox ArtifactoryUser_txt;
        private System.Windows.Forms.TextBox ArtifactoryPassword_txt;
        private System.Windows.Forms.TextBox FolderToDeploy_txt;
        private System.Windows.Forms.TextBox IncludePatterns_txt;
        private System.Windows.Forms.TextBox ExcludePatterns_txt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ProxyPassword_txt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ProxyUser_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ProxyHost_txt;
        private System.Windows.Forms.CheckBox ProxyEnabled_ck;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown TimeOut_txt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Ok_bt;
        private System.Windows.Forms.Button Cancel_bt;
        private System.Windows.Forms.CheckBox NotFlatDeploy_ck;
        private System.Windows.Forms.CheckBox BuildInfo_ck;
        private System.Windows.Forms.TextBox ProxyPort_txt;
    }
}
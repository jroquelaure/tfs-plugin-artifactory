using System;
using System.Windows.Forms;

namespace JFrogTFSPlugin.CustomTypes
{
    public partial class ArtifactoryConfigurationDialog : Form
    {
        public ArtifactoryConfigurationDialog()
        {
            InitializeComponent();
        }

        private void ProxyEnabled_ck_CheckedChanged(object sender, EventArgs e)
        {
           ProxySettings_gp.Enabled = ProxyEnabled_ck.Checked;
        }

        internal ArtifactoryConfiguration GetArtifactoryConfiguration()
        {
            var artifactoryConfiguration = new ArtifactoryConfiguration
            {
                ArtifactoryUrl = ArtifactoryUrl_txt.Text,
                ExcludePatterns = ExcludePatterns_txt.Text,
                FolderToDeploy = FolderToDeploy_txt.Text,
                IncludeBuildInfo = BuildInfo_ck.Checked,
                IncludePatterns = IncludePatterns_txt.Text,
                IsFlatDeploy = !NotFlatDeploy_ck.Checked,
                Password = ArtifactoryPassword_txt.Text,
                TargetRepository = TargetRepo_txt.Text,
                TimeOut = (int) TimeOut_txt.Value,
                User = ArtifactoryUser_txt.Text
            };
            if (ProxyEnabled_ck.Checked)
            {
                artifactoryConfiguration.ProxyConfiguration = new ProxyConfiguration(ProxyHost_txt.Text, int.Parse(ProxyPort_txt.Text), ProxyUser_txt.Text, ProxyPassword_txt.Text) ;
            }
            else
            {
                artifactoryConfiguration.ProxyConfiguration = new ProxyConfiguration {Bypass = true};
            }

            return artifactoryConfiguration;
        }

        private void ProxyPort_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        internal void SetArtifactoryConfiguration(ArtifactoryConfiguration artifactoryConfiguration)
        {
            ArtifactoryUrl_txt.Text = artifactoryConfiguration.ArtifactoryUrl;
            ExcludePatterns_txt.Text = artifactoryConfiguration.ExcludePatterns;
            FolderToDeploy_txt.Text = artifactoryConfiguration.FolderToDeploy;
            BuildInfo_ck.Checked = artifactoryConfiguration.IncludeBuildInfo;
            IncludePatterns_txt.Text = artifactoryConfiguration.IncludePatterns;
            NotFlatDeploy_ck.Checked = !artifactoryConfiguration.IsFlatDeploy;
            ArtifactoryPassword_txt.Text = artifactoryConfiguration.Password;
            TargetRepo_txt.Text = artifactoryConfiguration.TargetRepository;
            TimeOut_txt.Value = (artifactoryConfiguration.TimeOut >= TimeOut_txt.Minimum && artifactoryConfiguration.TimeOut <= TimeOut_txt.Maximum) ? artifactoryConfiguration.TimeOut : 300;
            ArtifactoryUser_txt.Text = artifactoryConfiguration.User;

            if (artifactoryConfiguration.ProxyConfiguration != null &&
                !artifactoryConfiguration.ProxyConfiguration.Bypass)
            {
                ProxyEnabled_ck.Checked = true;
                ProxyHost_txt.Text = artifactoryConfiguration.ProxyConfiguration.Host;
                ProxyPort_txt.Text = artifactoryConfiguration.ProxyConfiguration.Port.ToString();
                ProxyPassword_txt.Text = artifactoryConfiguration.ProxyConfiguration.Password;
                ProxyUser_txt.Text = artifactoryConfiguration.ProxyConfiguration.Username;
                ProxySettings_gp.Enabled = true;
            }
            else
            {
                ProxyEnabled_ck.Checked = false;
                ProxySettings_gp.Enabled = false;
            }

        }
    }
}

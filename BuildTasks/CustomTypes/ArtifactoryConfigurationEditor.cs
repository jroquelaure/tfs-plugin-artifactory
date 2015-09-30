using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using JFrogTFSPlugin.Library.Artifactory;

namespace JFrogTFSPlugin.CustomTypes
{
    public class ArtifactoryConfigurationEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ArtifactoryConfiguration artifactoryConfiguration = new ArtifactoryConfiguration();
            if (provider != null)
            {
                IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (editorService != null)
                {
                    artifactoryConfiguration = value as ArtifactoryConfiguration;

                    using (ArtifactoryConfigurationDialog dialog = new ArtifactoryConfigurationDialog())
                    {
                        if(artifactoryConfiguration != null) dialog.SetArtifactoryConfiguration(artifactoryConfiguration);

                        if (editorService.ShowDialog(dialog) == DialogResult.OK)
                        {
                            artifactoryConfiguration = dialog.GetArtifactoryConfiguration();
                        }
                    }
                }

            }

            return artifactoryConfiguration;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
}

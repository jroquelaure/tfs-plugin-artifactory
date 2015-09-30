# tfs-plugin-artifactory
Custom activity project for TFS to interact with JFrog Artifactory

###This solution is compose by 3 differents projects (please note this project is under construction and is actually more a POC than a plugin)

JFrogTFSPlugin is the main project. It generate a dll JFrogTFSPlugin.dll which provide a custom activity named JFrogAcrtifactoryDeployer and can be used in TFS custom templates.

Templates project provide a custom template example, based on TFS' default template, using JFrogAcrtifactoryDeployer activity.

JFrogTFSPluginTest is a test project which needs to be improved.

###How to use the custom activity
- Build the JFrogTFSPlugin project (preferred in release mode).
- Create a custom template for TFS and open it in visual studio (follow this excellent guide if not familiar with this process : http://www.ewaldhofman.nl/post/2010/04/20/customize-team-build-2010-e28093-part-1-introduction.aspx)
- Add a reference to the JFrogTFSPlugin.dll
- Open your custom template xaml file
- You should be able to add the JFrogAcrtifactoryDeployer from the toolbox 
- In "Arguments" tab add a new line named "ArtifactoryConfiguration" (this is an example you can name it as you want)
- In the Argument Type choose for the “Browse for Types …” option 
- In the Browse dialog, navigate to the JFrogTFSPlugin->CustomTypes reference and choose the ArtifactoryConfiguration class
- Find the Arguments named "Metadata" and click on the ellipsis button
- Add the new "ArtifactoryConfiguration" parameter and set the others value as you want to display them in your build definition. Just the Editor field must be filled with this exact value (to ensure that your build definition will find the correct editor dialog to change your ArtifactoryConfiguration parameter) : JFrogTFSPlugin.CustomTypes.ArtifactoryConfigurationEditor,JFrogTFSPlugin
- Save the project and push/copy depending on what you are using, your xaml file to  your TeamProject where you want to use your new template.
- You also need to push the JFrogTFSPlugin.dll to your TFS server version control custom assemblies folder (if you didn't set this yet go to manage build controller -> select your controller -> properties -> add the path to the corresponding field)
- Now open in build definition, in process tab you can choose your custom template by clicking on "New...", browsing to your xaml file and then configure your plugin to deploy to Artifactory.

###WIP / TODO
- add tooltips in editor
- browse folder instead of setting manually
- allowing relative path
- allow use of env variables as $TFS_BINARIES_DIR, $TFS_BUILD_DIR, drop folder,...
-...
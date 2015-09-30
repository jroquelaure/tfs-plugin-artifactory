using System.Collections.Generic;
using System.IO;
using System.Linq;
using JFrogTFSPlugin.Library.ArtefactsHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JFrogTFSPluginTests.Library.ArtefactsHelpers
{
    [TestClass()]
    public class MatchArtifactHelperTests
    {
        private const string folderDefault = @"..\default";
        private const string fileTxtName = "newFile.txt";
        private const string txtPattern = "*.txt";
        


        [TestMethod()]
        public void GetMatchingArtifcatsFromTest()
        {
            //arrange
            Directory.CreateDirectory(folderDefault);
            File.Create(folderDefault + @"\" + fileTxtName);
            File.Create(folderDefault + @"\" + "file.doc");
            //act
            var matchingArtifactsFrom = MatchArtifactHelper.GetMatchingArtifactsFrom(folderDefault, fileTxtName + ",file.*", string.Empty);
            //assert
            Assert.IsNotNull(matchingArtifactsFrom);
            Assert.AreEqual(2, matchingArtifactsFrom.Count);
            Assert.AreEqual(1,matchingArtifactsFrom.Count(x=>x.Name == fileTxtName));

            //with exclude pattern
            Directory.CreateDirectory(folderDefault + @"\" + "test");
            Directory.CreateDirectory(folderDefault + @"\" + "sub");
            File.Create(folderDefault + @"\" + "test.txt");
            File.Create(folderDefault + @"\sub\" + "test.txt");
            File.Create(folderDefault + @"\test\" + "toExclude.doc");

            //act
            matchingArtifactsFrom = MatchArtifactHelper.GetMatchingArtifactsFrom(folderDefault, "*.*", @"test.*,*\test\*");
            //assert
            Assert.IsNotNull(matchingArtifactsFrom);
            Assert.AreEqual(2, matchingArtifactsFrom.Count);
            Assert.AreEqual(1, matchingArtifactsFrom.Count(x => x.Name == fileTxtName));
        }
      
    }
}
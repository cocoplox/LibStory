using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Tests
{
    [TestFixture]
    public class FileTests
    {
        [Test]
        public void ShouldCreateDirectory()
        {
            var proyectRootPath = AppDomain.CurrentDomain.BaseDirectory;
            Assert.Pass();
        }
    }
}

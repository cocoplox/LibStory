using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.Helpers
{
    public static class PathHelper
    {
        public static string GetDbPath()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folder = Path.Combine(appData, "LibStory");
            if(!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            return Path.Combine(folder, "LibStory.db");

        }
    }
}

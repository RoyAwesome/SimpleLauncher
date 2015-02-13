using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUpdater
{
    class LauncherManifest
    {
        public LauncherManifest()
        {
            ProjectRoot = "";
            Files = new Dictionary<string, string>();
        }

        public string ProjectRoot
        {
            get;
            set;
        }
        
        public int Build
        {
            get;
            set;
        }

        public Dictionary<string, string> Files
        {
            get;
            set;
        }

        public string Executable
        {
            get;
            set;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleUpdater
{
    class ManifestBuilder
    {

        public static void BuildManifest(string directory, int build, string executable, string gameURL)
        {
            LauncherManifest manifest = new LauncherManifest();
            manifest.Build = build;
            manifest.Executable = executable;
            manifest.ProjectRoot = gameURL;



            md5 = MD5.Create();

            RecursiveBuildManifest(directory, "", manifest);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment.CurrentDirectory;
            dialog.FileName = "Manifest.txt";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(manifest, Formatting.Indented));
            }

            Properties.Settings.Default.Builder_LastBuildNumber = build + 1;
            Properties.Settings.Default.Builder_LastDirectory = directory;
            Properties.Settings.Default.Builder_LastExecutable = executable;
            Properties.Settings.Default.Builder_LastURL = gameURL;
            

        }

        private static MD5 md5;
        private static void RecursiveBuildManifest(string projectRoot, string dir, LauncherManifest manifest)
        {
            string path = projectRoot + dir;

            foreach(string file in Directory.GetFiles(path))
            {
                string localPath = ToLocalPath(projectRoot, file);
                string hash = Util.ComputeMD5(file);

                manifest.Files[localPath] = hash;
            }

            foreach(string nextDir in Directory.GetDirectories(path))
            {
                RecursiveBuildManifest(projectRoot, ToLocalPath(projectRoot, nextDir), manifest);
            }
        }

        private static string ToLocalPath(string root, string dir)
        {
            return dir.Replace(root, "").Replace("\\", "/");
        }
    }
}

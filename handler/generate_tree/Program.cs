using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace generate_tree
{
    class Program
    {
        private static readonly string[] DirsInRoot = {
            "os",
            "programming",
            "software",
            "style",
            "uav"
        };

        private class IndexFile
        {
            public IndexFile(string fileName, int level)
            {
                SW = new StreamWriter(fileName);
                Level = level;
            }
            public IndexFile(StreamWriter sw, int level)
            {
                SW = sw;
                Level = level;
            }
            public void Close()
            {
                SW.Close();
            }
            public void WriteTitle(string title)
            {
                SW.WriteLine("# " + title);
                SW.WriteLine();
            }
            public void Write(string s)
            {
                SW.Write(s);
            }
            public void WriteLine(string s)
            {
                SW.WriteLine(s);
                SW.Flush();
            }
            public StreamWriter SW { get; }
            public int Level { get; }
        }

        private static string RootDir;
        private static int RootDirLength;

        private static string IndexString;
        private static List<IndexFile> IndexFiles;

        static void Main(string[] args)
        {
            RootDir = Path.GetFullPath(@"..\..\..\..");
            RootDirLength = RootDir.Length;


            IndexFiles = new List<IndexFile>();
            IndexFiles.Add(new IndexFile(RootDir + @"\_sidebar.md", 0));

            foreach (string dirInRoot in DirsInRoot)
                GoThroughDir(RootDir + @"\" + dirInRoot, 1);

            foreach (IndexFile index in IndexFiles)
                index.Close();

            GenerateIndexFile(RootDir + @"\_sidebar.md", RootDir + @"\index.md");
        }

        static void GoThroughDir(string path, int level)
        {
            List<string> dirs = Directory.EnumerateDirectories(path).ToList();
            for (int i = dirs.Count - 1; i >= 0; i--)
                if (dirs[i].EndsWith(@"\img"))
                    dirs.RemoveAt(i);

            List<string> files = Directory.EnumerateFiles(path).ToList();
            for (int i = files.Count - 1; i >= 0; i--)
                if (files[i].EndsWith(@"_main.md") ||
                    files[i].EndsWith(@"_sidebar.md"))
                    files.RemoveAt(i);

            // 获得和写入标题
            string title;
            using (StreamReader sr = new StreamReader(path + @"\_main.md"))
                title = sr.ReadLine().Substring(2);

            // 将标题写入所有 index 文件中
            for (int i = 0; i < IndexFiles.Count; i++) {
                string line = "";
                for (int j = 0; j < level - IndexFiles[i].Level - 1; j++)
                    line += "  ";
                line += string.Format("- [**{0}**]({1}/_main.md)", title,
                    path.Substring(RootDirLength).Replace('\\', '/'));
                IndexFiles[i].WriteLine(line);

                if (i == 0)
                    IndexString += line + "\r\n";
            }

            // 在子目录写入 sidebar
            IndexFile localSideBar = null;
            if (files.Count > 0) {
                localSideBar = new IndexFile(path + @"\_sidebar.md", 0);
                localSideBar.Write(IndexString);
                IndexFiles.Add(localSideBar);
            }

            // 写入 main
            IndexFile localIndex = new IndexFile(path + @"\_main.md", level);
            int localIndexIndex = IndexFiles.Count;
            localIndex.WriteTitle(title);
            IndexFiles.Add(localIndex);

            // 子目录遍历
            foreach (string dir in dirs) {
                GoThroughDir(dir, level + 1);
            }

            // 写入文件列表
            foreach (string file in files) {
                string fileTitle;
                using (StreamReader sr = new StreamReader(file))
                    fileTitle = sr.ReadLine().Substring(2);

                string s = string.Format("- [{0}]({1})", fileTitle,
                    file.Substring(RootDirLength).Replace('\\', '/'));
                localIndex.WriteLine(s);

                if (localSideBar == null)
                    continue;
                for (int i = 0; i < level; i++)
                    localSideBar.Write("  ");
                localSideBar.WriteLine(s);
            }

            // 关闭和移除 main
            localIndex.Close();
            IndexFiles.RemoveAt(localIndexIndex);
        }

        static void GenerateIndexFile(string sidebarFileName, string indexFileName)
        {
            using (StreamReader sr = new StreamReader(sidebarFileName))
            using (StreamWriter sw = new StreamWriter(indexFileName)) {
                while (!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    if (line.StartsWith("- ")) {
                        sw.WriteLine();
                        line = "## " + line.Substring(3, line.IndexOf(']') - 3);
                    } else {
                        line = line.Substring(2);
                    }

                    sw.WriteLine(line.Replace("**", ""));
                }
            }
        }
    }
}

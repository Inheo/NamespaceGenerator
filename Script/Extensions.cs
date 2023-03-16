using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Inheo.GenerateNamaspace
{
    public static class Extensions
    {
        public static string GenerateNamespace(this string path)
        {
            path = path[(path.IndexOf(Path.DirectorySeparatorChar) + 1)..];

            var index = path.LastIndexOf(Path.DirectorySeparatorChar);
            path = index == -1 ? string.Empty : path.Substring(0, index);

            index = path.LastIndexOf("Scripts");

            if (index != -1)
            {
                foreach (var folder in GetDontIncludeFolders())
                {
                    if ((index == 0 || path[index - 1] == Path.DirectorySeparatorChar) && (index + folder.Length == path.Length || path[index + folder.Length] == Path.DirectorySeparatorChar))
                        path = index + folder.Length == path.Length ? string.Empty : path.Substring(index + folder.Length + 1);
                }
            }

            path = path.Replace(Path.DirectorySeparatorChar, '.');
            var @namespace = (path == string.Empty ? Application.productName : $"{Application.productName}.{path}").Replace(" ", "");

            return @namespace;
        }

        public static string[] GetDontIncludeFolders() => GetSettings().DontIncludeFolders;

        public static Settings GetSettings()
        {
            var settingsDirectory = GetConfigDirectoryPath();
            var settingsFilePath = GetSettingsAssetPath(settingsDirectory);
            var asset = AssetDatabase.LoadAssetAtPath<Settings>(settingsFilePath);

            return asset;
        }

        public static string CallerDirectory([System.Runtime.CompilerServices.CallerFilePath] string fileName = null) => Directory.GetParent(Path.GetDirectoryName(fileName)).FullName;
        public static string CallerRelativePath() => "Assets" + CallerDirectory().Substring(Application.dataPath.Length);

        private static string GetConfigDirectoryPath()
        {
            var path = Path.Combine(CallerRelativePath(), "Config");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        private static string GetSettingsAssetPath(string directoryPath)
        {
            var path = Path.Combine(directoryPath, "Settings.asset");

            if (!File.Exists(path))
            {
                Settings settongs = ScriptableObject.CreateInstance<Settings>();
                AssetDatabase.CreateAsset(settongs, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            return path;
        }

        public static bool IsDirectory(this string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
        }

        public static bool IsCSharpFile(this string path) =>
            Path.GetExtension(path) == ".cs";


        public static List<string> GetFilePaths(this string path)
        {
            var files = new List<string>();
            var dirs = new Queue<string>();
            dirs.Enqueue(path);

            while (dirs.Count > 0)
            {
                int size = dirs.Count;

                for (int i = 0; i < size; i++)
                {
                    var node = dirs.Dequeue();
                    var dirPaths = Directory.GetDirectories(node);
                    files.AddRange(Directory.GetFiles(node));

                    foreach (var pathToDir in dirPaths)
                        dirs.Enqueue(pathToDir);
                }
            }

            return files;
        }
    }
}
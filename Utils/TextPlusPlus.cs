using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BananaModManager.Utils
{
    public class TextPlusPlus
    {
        private static bool LineContainsCharacters(string line)
        {
            string validChars = "abcdefghijklmnopqrstuvwxyz123456789$";

            foreach (char c in line)
            {
                if (!validChars.ToLower().Contains(c))
                    return false; break;
            }

            return true;
        }

        private static Dictionary<string, string> Variables = new();

        public static void DefineVariable(string name, string value)
        {
            Variables.Add(name, value);
        }

        public static string ParseLineForVariables(string line)
        {
            string nl = line;

            if (line.Contains("$"))
            {
                string thisVarName = "";

                for (int idx = line.IndexOf("$") + 1 /* skips the $ */; idx < line.Length; idx++)
                {
                    // remember your raw C syntax folks!
                    // "" = string
                    // '' = char

                    if (line[idx] != ' ')
                        thisVarName += line[idx];
                    else
                        break;
                }

                if (Variables.ContainsKey(thisVarName))
                    nl.Replace($"${thisVarName}", Variables[thisVarName]);
                else
                    throw new Exception($"Variable {thisVarName} does not exist. Check docs.");
            }

            return nl;
        }

        public static List<string> ParseSourceFile(string path)
        {
            List<string> fileLiteral = new List<string>(File.ReadAllLines(path));
            List<string> literalContents = new();

            foreach (string line in fileLiteral)
            {
                if (LineContainsCharacters(line) &&
                    (line.StartsWith("http://") || line.StartsWith("https://"))
                )
                {
                    literalContents.Add(line);
                }
            }

            return literalContents;
        }
    }

    // thanks StackOverflow

    public class FileAssociation
    {
        public string Extension { get; set; }
        public string ProgId { get; set; }
        public string FileTypeDescription { get; set; }
        public string ExecutableFilePath { get; set; }
    }

    public class FileAssociations
    {
        // needed so that Explorer windows get refreshed after the registry is updated
        [DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, nint item1, nint item2);

        private const int SHCNE_ASSOCCHANGED = 0x8000000;
        private const int SHCNF_FLUSH = 0x1000;

        public static void EnsureAssociationsSet()
        {
            var filePath = Process.GetCurrentProcess().MainModule.FileName;
            EnsureAssociationsSet(
                new FileAssociation
                {
                    Extension = ".ucs",
                    ProgId = "UCS_Editor_File",
                    FileTypeDescription = "UCS File",
                    ExecutableFilePath = filePath
                });
        }

        public static void EnsureAssociationsSet(params FileAssociation[] associations)
        {
            bool madeChanges = false;
            foreach (var association in associations)
            {
                madeChanges |= SetAssociation(
                    association.Extension,
                    association.ProgId,
                    association.FileTypeDescription,
                    association.ExecutableFilePath);
            }

            if (madeChanges)
            {
                SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, nint.Zero, nint.Zero);
            }
        }

        public static bool SetAssociation(string extension, string progId, string fileTypeDescription, string applicationFilePath)
        {
            bool madeChanges = false;
            madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + extension, progId);
            madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + progId, fileTypeDescription);
            madeChanges |= SetKeyDefaultValue($@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\" \"%1\"");
            return madeChanges;
        }

        private static bool SetKeyDefaultValue(string keyPath, string value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key.GetValue(null) as string != value)
                {
                    key.SetValue(null, value);
                    return true;
                }
            }

            return false;
        }
    }
}
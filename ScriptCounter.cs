using UnityEngine;
using UnityEditor;
using System.IO;


/// <summary>
/// Just a quick script to check how many scripts my project has. 
/// Just for fun :D
/// </summary>
public class ScriptCounter : MonoBehaviour
{
    [MenuItem("Tools/Rushed/Script Counter")]
    static void CountScripts()
    {
        string scriptFolder = "Assets/Scripts";
        string[] scriptFiles = Directory.GetFiles(scriptFolder, "*.cs", SearchOption.AllDirectories);
        int scriptCount = scriptFiles.Length;
        int totalLines = 0;

        foreach (var scriptFile in scriptFiles)
        {
            int linesInFile = CountLinesInFile(scriptFile);
            totalLines += linesInFile;
        }

        Debug.Log("Number of scripts in the '" + scriptFolder + "' folder: " + scriptCount);
        Debug.Log("Total number of lines in all scripts: " + totalLines);
    }

    static int CountLinesInFile(string filePath)
    {
        int lineCount = 0;
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    lineCount++;
                }
            }
        }
        return lineCount;
    }

}

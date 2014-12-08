using UnityEngine;
using UnityEditor;
using System.IO;

// Create a Sublime Text 3 project from a Unity project to use with Omnisharp
// Includes folders and file types of your choosing
public class SyncSublimeText : Editor
{
	// Put all Assets subfolders you want to include here
	private static readonly string[] includeFolders = new[] { "/" };
	// Put all extensions you want to include here
	private static readonly string[] includeExtensions = new[] { "cs", "js", "txt", "shader", "cginc", "xml", "json", "h", "m", "mm", "c", "cpp", "java" };

	[MenuItem("Assets/Sync SublimeText Project")]
	static void SyncSTProject()
	{
		// Output file string
		string outFile;

		// Output file location
		string outFolder = Application.dataPath.Substring(0, Application.dataPath.Length - 7);

		// Get folder name for current project
		string projectFolderName = outFolder.Substring(outFolder.LastIndexOf("/") + 1);

		// Add project folders
		outFile = "{\n";
		outFile += "\t\"folders\":\n";
		outFile += "\t[\n";

		for (int n = 0; n < includeFolders.Length; n++)
		{
			string cFolder = includeFolders[n];

			outFile += "\t\t{\n";
			outFile += "\t\t\t\"file_include_patterns\":\n";
			outFile += "\t\t\t[\n";

			for (int i = 0; i < includeExtensions.Length; i++)
			{
				string cExtension = includeExtensions[i];

				outFile += "\t\t\t\t\"*." + cExtension + "\"";

				if (i != includeExtensions.Length - 1)
				{
					outFile += ",";
				}
				outFile += "\n";
			}

			outFile += "\t\t\t],\n";
			outFile += "\t\t\t\"path\": \"" + Application.dataPath + cFolder + "\",\n";
			outFile += "\t\t\t\"follow_symlinks\": true\n";
			outFile += "\t\t}";

			if (n != includeFolders.Length - 1)
			{
				outFile += ",";
			}

			outFile += "\n";
		}

		outFile += "\t],\n";
		outFile += "\n";

		// Add link to solution file
		string[] slnFiles = Directory.GetFiles(Application.dataPath + "/../", "*.sln", SearchOption.TopDirectoryOnly);
		if(slnFiles.Length > 0)
			outFile += "\t\"solution_file\":" + "\"" + slnFiles[0] + "\"";

		// Close file
		outFile += "}\n";

		// Write the file to disk
		var sw = new StreamWriter(outFolder + "/" + projectFolderName + ".sublime-project");

		sw.Write(outFile);

		sw.Close();

	}
}
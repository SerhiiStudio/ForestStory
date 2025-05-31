using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SanctumCorp
{
	public static class SaveToFolder
	{
		private const string PREFAB = ".prefab";

		public static void SavePrefabsToSubfolder(string path, string folderName, List<GameObject> gameObjects)
		{
			if (
				!string.IsNullOrEmpty(path) &&
				!string.IsNullOrEmpty(folderName) &&
				(gameObjects != null && gameObjects.Count != 0)
				)
			{
				string folderToSave = path + "/" + folderName;

				if (!AssetDatabase.IsValidFolder(folderToSave))
					AssetDatabase.CreateFolder(path, folderName);

				Debug.Log("Prefab saved to " + folderToSave);

				foreach (GameObject gameObject in gameObjects)
				{
					string fullPath = folderToSave + "/" + gameObject.name + PREFAB;
					PrefabUtility.SaveAsPrefabAsset(gameObject, fullPath);
				}
			}
		}


		public static void Save(DefaultAsset folder, string targetFolderName, List<GameObject> objects)
		{
			string baseFolderPath = AssetDatabase.GetAssetPath(folder);
			if (AssetDatabase.IsValidFolder(baseFolderPath))
			{
				Debug.Log("Destination folder is valid");

				if (string.IsNullOrWhiteSpace(targetFolderName)) // Protect from empty string or space-misclick
				{
					Debug.LogError("Target folder name wasn't filled");
					return;
				}
				SavePrefabsToSubfolder(baseFolderPath, targetFolderName, objects);
			}
			else
			{
				Debug.LogError("Folder is invalid");
			}
		}
	}
}

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SerhiiStudio
{
	public static class SaveToFolder
	{
		private const string PREFAB = ".prefab";

		private static void SavePrefabsToSubfolder(string path, string folderName, List<GameObject> gameObjects)
		{
			if (
				!string.IsNullOrWhiteSpace(path) &&
				!string.IsNullOrWhiteSpace(folderName)
				)
			{
				if (gameObjects != null && gameObjects.Count != 0)
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
				else
					Debug.LogError("The array of GameObjects to save is null or empty");
			}
			else
				Debug.LogError("The path to the folder doesn't exist or the target folder name is null or invalid");
		}

		/// <summary>
		/// Saves a GameObject as .prefab to folder
		/// </summary>
		/// <param name="folder"></param>
		/// <param name="targetFolderName"></param>
		/// <param name="objects"></param>
		public static void Save(DefaultAsset folder, string targetFolderName, List<GameObject> objects)
		{
			string baseFolderPath = DeterminePath(folder);
			SavePrefabsToSubfolder(baseFolderPath, targetFolderName, objects);
		}

		private static string DeterminePath(DefaultAsset folder)
		{
			string baseFolderPath = AssetDatabase.GetAssetPath(folder);
			if (AssetDatabase.IsValidFolder(baseFolderPath))
			{
				Debug.Log("Destination folder is valid");
				return baseFolderPath;
			}
			else
			{
				Debug.LogError("Folder is invalid");
				return null;
			}
		}
	}
}

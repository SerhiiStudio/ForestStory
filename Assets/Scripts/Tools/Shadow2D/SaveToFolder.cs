using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SanctumCorp
{
	public static class SaveToFolder
	{
		public static void Save(string path, string folderName, List<GameObject> gameObjects)
		{
			if (
				!string.IsNullOrEmpty(path) &&
				!string.IsNullOrEmpty(folderName) &&
				(gameObjects != null && gameObjects.Count != 0)
				)
			{
				AssetDatabase.CreateFolder(path, folderName);
				string folderToSave = path + "/" + folderName;

				Debug.Log("Prefab saved to " + folderToSave);

				foreach (GameObject gameObject in gameObjects)
				{
					PrefabUtility.SaveAsPrefabAsset(gameObject, folderToSave);
				}
			}
		}
	}
}

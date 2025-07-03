using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public static class Serializator
{
    public static string FolderName => "Serialized Data";
    private const string JSON_EXTENSION = ".json";



    public static void SaveToFolder<T>(T data, string fileName)
    {
        try
        {
            string converted = JsonConvert.SerializeObject(data, Formatting.Indented);

            string dataPath = Application.persistentDataPath;

            string folderPath = Path.Combine(dataPath, FolderName);

            if(!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName + JSON_EXTENSION);

            using(StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(converted);
            }
        }

        catch(Exception ex)
        {
            Debug.LogError($"Error while creating a folder: {ex.Message}");
            return;
        }
    }

    public static (T obj, bool result) LoadFromFolder<T>(string fileName)
    {
        try
        {
            string pathToFolder = Path.Combine(Application.persistentDataPath, FolderName);
            string path = Path.Combine(pathToFolder, fileName + JSON_EXTENSION);

            using(StreamReader reader = new StreamReader(path))
            {
                string objectInJson = reader.ReadToEnd();
                T obj = JsonConvert.DeserializeObject<T>(objectInJson);
                return (obj, true);
            }
        }
        catch(Exception ex)
        {
            Debug.LogWarning($"Error while loading data: {ex.Message}");
            return (default, false);
        }
    }
}

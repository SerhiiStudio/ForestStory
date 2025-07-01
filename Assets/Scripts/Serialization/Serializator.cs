using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public static class Serializator
{
    private static string folderName = "Serialized Data";
    private const string JSON_EXTENSION = ".json";



    public static void SaveToFolder<T>(T data, string fileName)
    {
        string converted = JsonConvert.SerializeObject(data, Formatting.Indented);

        string dataPath = Application.persistentDataPath;

        string folderPath = Path.Combine(dataPath, folderName);

        if(!Directory.Exists(folderPath))
        {
            try
            {
                Directory.CreateDirectory(folderPath);
            }
            catch(Exception ex)
            {
                Debug.LogError($"Error while creating a folder: {ex.Message}");
                return;
            }
        }

        string filePath = Path.Combine(folderPath, fileName + JSON_EXTENSION);

        using(StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(converted);
        }
    }
}

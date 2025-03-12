using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Data = GoogleSheetsAPI.Data;

public class SaveLoadData
{
    private static readonly string filePath = Path.Combine(Application.persistentDataPath, "saveData.json");

    public static void SaveData(List<Data> data)
    {
        string json = JsonUtility.ToJson(new DataList(data), true);
        File.WriteAllText(filePath, json);
        Debug.Log("Data saved: " + json);
    }

    public static List<Data> LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            List<Data> data = JsonUtility.FromJson<DataList>(json).data;
            Debug.Log("Data loaded: " + data + "JSON: " + json);
            return data;
        }
        else
        {
            Debug.LogWarning("No save file found.");
            return null;
        }
    }

    [Serializable]
    public class DataList
    {
        public List<Data> data;
        public DataList(List<Data> data) {  this.data = data; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class SaveLoadData
{
    private static readonly string filePath = Path.Combine(Application.persistentDataPath, "saveData.json");

    public static void SaveData(List<TaskData> data)
    {
        string json = JsonUtility.ToJson(new DataList(data), true);
        File.WriteAllText(filePath, json);
        Debug.Log("Data saved: " + json);
    }

    public static List<TaskData> LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            List<TaskData> data = JsonUtility.FromJson<DataList>(json).data;
            //Debug.Log("Data loaded: " + data + "JSON: " + json);
            return data;
        }
        else
        {
            //Debug.LogWarning("No save file found.");
            return new List<TaskData>();
        }
    }

    [Serializable]
    public class DataList
    {
        public List<TaskData> data;
        public DataList(List<TaskData> data) {  this.data = data; }
    }
}

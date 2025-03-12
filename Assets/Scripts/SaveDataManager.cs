using UnityEngine;
using Game.Util;
using System.Collections;
using System.Collections.Generic;
using Data = GoogleSheetsAPI.Data;

public class SaveDataManager : Singleton<SaveDataManager>
{
    private List<Data> notSentDataList = new();
    private void Start()
    {
        GoogleSheetsAPI.SendSuccessful += AutoSave;

        LoadData();
        TrySendData();
    }

    private void TrySendData()
    {

    }

    private IEnumerator TrySendLoop()
    {
        yield return null;
    }

    private void AutoSave(bool value, Data data)
    {
        if (value)
        {
            if (notSentDataList.Contains(data))
                notSentDataList.Remove(data);
            return;
        }
        notSentDataList.Add(data);
    }

    private void LoadData()
    {
        notSentDataList = SaveLoadData.LoadData();
    }

    private void SaveData()
    {
        SaveLoadData.SaveData(notSentDataList);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void OnDestroy()
    {
        GoogleSheetsAPI.SendSuccessful -= AutoSave;
    }
}

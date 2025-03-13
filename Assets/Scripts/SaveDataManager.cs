using UnityEngine;
using Game.Util;
using System.Collections;
using System.Collections.Generic;

public class SaveDataManager : Singleton<SaveDataManager>
{
    [SerializeField]
    private float trySendDataDelay = 60f;

    private Coroutine activeLoop = null;
    private List<TaskData> notSentDataList = new();
    private void Start()
    {
        notSentDataList = new();
        GoogleSheetsAPI.SendSuccessful += AutoSave;

        LoadData();
        TrySendData();
    }

    private void TrySendData()
    {
        if (activeLoop == null)
            activeLoop = StartCoroutine(TrySendLoop());
    }

    private IEnumerator TrySendLoop()
    {
        while (notSentDataList.Count > 0)
        {
            for (int i = 0; i < notSentDataList.Count; i++)
            {
                GoogleSheetsAPI.SendData(notSentDataList[i]);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(trySendDataDelay);
        }
        activeLoop = null;
    }

    private void AutoSave(bool value, TaskData data)
    {
        if (value)
        {
            if (notSentDataList.Contains(data))
                notSentDataList.Remove(data);
            return;
        }
        if (!notSentDataList.Contains(data))
        {
            notSentDataList.Add(data);
            TrySendData();
        }
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

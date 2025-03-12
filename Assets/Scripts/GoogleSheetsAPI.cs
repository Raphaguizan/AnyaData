using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using Game.Util;

public class GoogleSheetsAPI : Singleton<GoogleSheetsAPI>
{
    [SerializeField]
    private string url;

    public static void SendData(string task, string eat = "", string suckle = "")
    {
        Instance.StartCoroutine(Instance.SendDataCoroutine(DateTime.Now, task, eat, suckle));
    }

    IEnumerator SendDataCoroutine(DateTime dateTime, string task, string eat, string suckle)
    {
        string dateTimeStr = dateTime.ToString("yyyy-MM-dd HH:mm:ss"); // Formato padr?o de data/hora
        string jsonData = JsonUtility.ToJson(new Data(dateTimeStr, task, eat, suckle));

        Debug.Log("Enviando JSON: " + jsonData);
        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(url, jsonData))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
                Debug.Log("Dados enviados com sucesso!");
            else
                Debug.LogError("Erro ao enviar: " + www.error);
        }
    }

    [Serializable]
    private class Data
    {
        public string date_time;
        public string task;
        public string eat;
        public string suckle;

        public Data(string date_time, string task, string eat, string suckle)
        {
            this.date_time = date_time;
            this.task = task;
            this.eat = eat;
            this.suckle = suckle;
        }
    }
}
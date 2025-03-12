using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using Game.Util;

public class GoogleSheetsAPI : Singleton<GoogleSheetsAPI>
{
    [SerializeField]
    private string url;

    public static Action<bool, Data> SendSuccessful;

    public static void SendData(string task, string eat = "", string suckle = "")
    {
        SendData(new Data(task, eat, suckle));
    }
    public static void SendData(DateTime dateTime, string task, string eat = "", string suckle = "")
    {
        SendData(new Data(dateTime, task, eat, suckle));
    }
    public static void SendData(Data data)
    {
        Instance.StartCoroutine(Instance.SendDataCoroutine(data));
    }

    IEnumerator SendDataCoroutine(Data data)
    {
        string jsonData = JsonUtility.ToJson(data);

        Debug.Log("Enviando JSON: " + jsonData);
        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(url, jsonData))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            SendSuccessful.Invoke(www.result == UnityWebRequest.Result.Success, data);
            
            if (www.result == UnityWebRequest.Result.Success)
                Debug.Log("Dados enviados com sucesso!");
            else
                Debug.LogError("Erro ao enviar: " + www.error);
        }
    }

    [Serializable]
    public class Data
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
        public Data(DateTime dateTime, string task, string eat, string suckle)
        {
            this.date_time = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.task = task;
            this.eat = eat;
            this.suckle = suckle;
        }
        public Data(string task, string eat, string suckle)
        {
            this.date_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.task = task;
            this.eat = eat;
            this.suckle = suckle;
        }
    }
}
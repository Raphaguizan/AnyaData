using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using Game.Util;

public class GoogleSheetsAPI : Singleton<GoogleSheetsAPI>
{
    [SerializeField]
    private string url;

    [SerializeField]
    private GameObject sendScreen;

    public static Action<bool, TaskData> SendSuccessful;


    private void Start()
    {
        sendScreen.SetActive(false);
    }

    public static void SendData(TaskData data)
    {
        Instance.StartCoroutine(Instance.SendDataCoroutine(data));
    }

    IEnumerator SendDataCoroutine(TaskData data)
    {
        sendScreen.SetActive(true);
        string jsonData = JsonUtility.ToJson(data);

        Debug.Log("Enviando JSON: " + jsonData);
        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(url, jsonData))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            sendScreen.SetActive(false);
            SendSuccessful.Invoke(www.result == UnityWebRequest.Result.Success, data);
            
            if (www.result == UnityWebRequest.Result.Success)
                Debug.Log("Dados enviados com sucesso!");
            else
                Debug.LogError("Erro ao enviar: " + www.error);
        }
    }
}
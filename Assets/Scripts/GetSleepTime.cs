using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Game.Util;

public class GetSleepTime : Singleton<GetSleepTime>
{
    private string apiUrl = "https://script.google.com/macros/s/AKfycbzkLgVnAopWEq-fRGNRTj7amTtKPa2F6hZTGu5evT5grLuwQithaDyaP4Khkv78Zmid/exec?action=lastSleep";

    //public TMP_Text sleepTimeText; // Arraste um TextMeshPro UI para exibir o resultado

    public static Action<string> ResponseAction;

    public static void TimeRequest()
    {
        Instance.StartCoroutine(Instance.GetLastSleepTime());
    }

    IEnumerator GetLastSleepTime()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text.Trim();

            if (response == "null")
            {
                ResponseAction.Invoke("Sem sono ativo no momento.");//sleepTimeText.text = "Nenhum sono ativo no momento.";
            }
            else
            {
                //Debug.Log(response);
                double sleepDurationInSeconds;
                if (double.TryParse(response, out sleepDurationInSeconds))
                {
                    ResponseAction.Invoke($"Dormiu por {FormatTimeSpan(sleepDurationInSeconds)}");
                    //sleepTimeText.text = $"Dormiu por {FormatTimeSpan(sleepDurationInSeconds)}";
                }
                else
                {
                    ResponseAction.Invoke("Erro ao calcular o tempo de sono.");
                    //sleepTimeText.text = "Erro ao converter o tempo.";
                }
            }
        }
        else
        {
            ResponseAction.Invoke("Erro ao comunicar com o servidor.");
            //sleepTimeText.text = "Erro ao conectar à API.";
        }
    }

    string FormatTimeSpan(double seconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
        return $"{timeSpan.Hours}h {timeSpan.Minutes}m {timeSpan.Seconds}s";
    }
}

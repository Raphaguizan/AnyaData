using UnityEngine;
using TMPro;
using System;
public class SendDataFeedBack : MonoBehaviour
{
    [SerializeField]
    private GameObject popUp;

    [SerializeField]
    private string successText;
    [SerializeField]
    private string errorText;
    [SerializeField]
    private TextMeshProUGUI title_TMP;
    [SerializeField]
    private TextMeshProUGUI dataField_TMP;
    [SerializeField]
    private TextMeshProUGUI sleepTimeField_TMP;

    void Start()
    {
        GoogleSheetsAPI.SendSuccessful += FeedBack;
        popUp.SetActive(false);
    }

    private void FeedBack(bool val, TaskData data)
    {
        OpenPopup();
        
        dataField_TMP.text = data.ToString();
        title_TMP.color = val ? Color.green : Color.red;
        title_TMP.text = val ? successText : errorText;
        AwakeUpCheck(data);
    }

    private void AwakeUpCheck(TaskData data)
    {
        if (data == null || !data.task.Equals("Acordou"))
            return;

        sleepTimeField_TMP.gameObject.SetActive(true);
        UpdateSleepTimeField("calculando tempo de sono ... ");
        GetSleepTime.TimeRequest();
        GetSleepTime.ResponseAction += UpdateSleepTimeField;
    }

    private void UpdateSleepTimeField(string newText)
    {
        sleepTimeField_TMP.text = newText;
    }

    public void OpenPopup(bool val = true)
    {
        sleepTimeField_TMP.gameObject.SetActive(false);
        GetSleepTime.ResponseAction -= UpdateSleepTimeField;
        popUp.SetActive(val);
    }
    private void OnDestroy()
    {
        GoogleSheetsAPI.SendSuccessful -= FeedBack;
    }
}

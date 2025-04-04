using UnityEngine;
using TMPro;
using Game.Util;
using System;

public class ConfirmPopUp : Singleton<ConfirmPopUp>
{
    [SerializeField]
    private GameObject popup;

    [SerializeField]
    private TextMeshProUGUI data_tmp;

    [SerializeField]
    private DateUIInput uiInput;

    private TaskData _taskData;

    private void Start()
    {
        Close();
    }

    public static void ShowPopUp(TaskData data)
    {
        Instance._taskData = data;
        Instance.data_tmp.text = data.ToStringNoDate();
        Instance.uiInput.SetDate(data.date_time);
        Instance.popup.SetActive(true);
    }

    public void Confim()
    {
        _taskData.date_time = uiInput.GetDate();
        //Debug.Log(_taskData.ToString());
        GoogleSheetsAPI.SendData(_taskData);
        Close();
    }

    public void Close()
    {
        popup?.SetActive(false);
    }
}

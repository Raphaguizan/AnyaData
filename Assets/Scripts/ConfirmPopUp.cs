using UnityEngine;
using TMPro;
using Game.Util;

public class ConfirmPopUp : Singleton<ConfirmPopUp>
{
    [SerializeField]
    private GameObject popup;

    [SerializeField]
    private TextMeshProUGUI data_tmp;

    private TaskData _taskData;

    private void Start()
    {
        Close();
    }

    public static void ShowPopUp(TaskData data)
    {
        Instance.data_tmp.text = data.ToString();
        Instance._taskData = data;
        Instance.popup.SetActive(true);
    }

    public void Confim()
    {
        GoogleSheetsAPI.SendData(_taskData);
        Close();
    }

    public void Close()
    {
        popup?.SetActive(false);
    }
}

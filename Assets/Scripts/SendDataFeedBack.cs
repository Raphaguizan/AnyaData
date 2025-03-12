using UnityEngine;
using TMPro;
using Data = GoogleSheetsAPI.Data;

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

    void Start()
    {
        GoogleSheetsAPI.SendSuccessful += FeedBack;
        popUp.SetActive(false);
    }

    private void FeedBack(bool val, Data data)
    {
        OpenPopup();
        
        dataField_TMP.text = data.ToString();
        title_TMP.color = val ? Color.green : Color.red;
        title_TMP.text = val ? successText : errorText;
    }

    public void OpenPopup(bool val = true)
    {
        popUp.SetActive(val);
    }
    private void OnDestroy()
    {
        GoogleSheetsAPI.SendSuccessful -= FeedBack;
    }
}

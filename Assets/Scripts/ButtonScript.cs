using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private bool needConfirm = true;
    [SerializeField]
    protected string task = "";
    [SerializeField]
    protected string eat = "";
    [SerializeField]
    protected string suckle = "";

    public string Task => task;
    public string Eat => eat;
    public string Suckle => suckle;

    public virtual void ButtonCLick()
    {
        TaskData myData = new(task, eat, suckle);
        if (needConfirm)
            ConfirmPopUp.ShowPopUp(myData);
        else
            GoogleSheetsAPI.SendData(myData);
    }

}

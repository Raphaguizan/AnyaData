using UnityEngine;

public class ButtonScript : MonoBehaviour
{
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
        //Debug.Log(buttonKey);
        GoogleSheetsAPI.SendData(task, eat, suckle);
    }

}

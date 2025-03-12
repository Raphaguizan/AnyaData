using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    protected string buttonKey = "";

    public string Key => buttonKey;

    public virtual void ButtonCLick()
    {
        //Debug.Log(buttonKey);
        GoogleSheetsAPI.SendData(buttonKey);
    }

}

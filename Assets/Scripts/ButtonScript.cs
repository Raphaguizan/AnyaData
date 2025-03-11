using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private string buttonKey = "";

    public string Key => buttonKey;
    void Start()
    {
        
    }

    public void ButtonCLick()
    {
        Debug.Log(buttonKey);
    }

}

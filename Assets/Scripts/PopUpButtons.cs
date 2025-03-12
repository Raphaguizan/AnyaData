using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopUpButtons : MonoBehaviour
{
    [SerializeField]
    private List<Button> buttons;
    
    void Start()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button.gameObject));
        }
        gameObject.SetActive(false);
    }

    private void OnButtonClick(GameObject button)
    {
        ButtonScript mybutton = button.GetComponent<ButtonScript>();
        GoogleSheetsAPI.SendData(mybutton.Task, "", mybutton.Suckle);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}

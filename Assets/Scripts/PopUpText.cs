using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class PopUpText : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputfield;
    [SerializeField]
    private GameObject errorText;
    [SerializeField]
    private string task;
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        inputfield.text = "";
        errorText.SetActive(false);
    }

    public void ButtonConfirm()
    {
        errorText.SetActive(false);
        if (inputfield.text.NullIfEmpty() == null) 
        {
            errorText.SetActive(true);
            return;
        }


        //Debug.Log($"Enviando a chave que é : {inputfield.text}");

        GoogleSheetsAPI.SendData(task, inputfield.text);

        gameObject.SetActive(false);
    }
}

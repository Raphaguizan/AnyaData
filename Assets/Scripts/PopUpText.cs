using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UIElements;

public class PopUpText : MonoBehaviour
{
    [SerializeField]
    private bool needConfirm;
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


        //Debug.Log($"Enviando a chave que � : {inputfield.text}");
        TaskData myData = new TaskData(task, inputfield.text);
        if (needConfirm)
            ConfirmPopUp.ShowPopUp(myData);
        else
            GoogleSheetsAPI.SendData(myData);

        gameObject.SetActive(false);
    }
}

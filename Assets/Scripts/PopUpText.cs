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
    void Start()
    {
        errorText.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ButtonConfirm()
    {
        errorText.SetActive(false);
        if (inputfield.text.NullIfEmpty() == null) 
        {
            errorText.SetActive(true);
            return;
        }


        Debug.Log($"Enviando a chave que é : {inputfield.text}");

        // sendInformation

        gameObject.SetActive(false);
    }
}

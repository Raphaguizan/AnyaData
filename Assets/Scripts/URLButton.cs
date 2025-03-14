using UnityEngine;

public class URLButton : MonoBehaviour
{
    [SerializeField]
    private string url;
    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}

using TMPro;
using UnityEngine;

public class PromptUIController : MonoBehaviour
{
    [SerializeField] GameObject promptWindow;
    [SerializeField] TextMeshProUGUI promptText;

    public void SetPromptText(string text)
    {
        promptText.text = text;
    }

    public void ShowPromptWindow()
    {
        promptWindow.SetActive(true);
    }

    public void HidePromptWindow()
    {
        promptWindow.SetActive(false);
    }
    
    //assign event on the button
}

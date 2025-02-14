using TMPro;
using UnityEngine;

public class PromptUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI promptText;

    public void SetPromptText(string text)
    {
        promptText.text = text;
    }
    
    //assign event on the button
}

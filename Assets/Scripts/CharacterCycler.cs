using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Text))]
public class CharacterCycler : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private Button incrementButton;
    [SerializeField] private Button decrementButton;

    private const string characters = "abcdefghijklmnopqrstuvwxyz0123456789 ";
    private int currentIndex = 0;

    private void Start()
    {
        InitializeDisplay();
        AddButtonListeners();
    }

    private void InitializeDisplay()
    {
        // Set initial character
        if (string.IsNullOrEmpty(displayText.text))
        {
            currentIndex = 0;
            UpdateDisplay();
        }
        else
        {
            currentIndex = characters.IndexOf(displayText.text[0]);
            if (currentIndex < 0) currentIndex = 0;
        }
        
        UpdateDisplay();
    }

    private void AddButtonListeners()
    {
        incrementButton.onClick.AddListener(IncrementCharacter);
        decrementButton.onClick.AddListener(DecrementCharacter);
    }

    public void IncrementCharacter()
    {
        currentIndex = (currentIndex + 1) % characters.Length;
        UpdateDisplay();
    }

    public void DecrementCharacter()
    {
        currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayText.text = characters[currentIndex].ToString();
    }

    // Public property to access current character
    public char CurrentCharacter => characters[currentIndex];

    private void OnDestroy()
    {
        incrementButton.onClick.RemoveListener(IncrementCharacter);
        decrementButton.onClick.RemoveListener(DecrementCharacter);
    }
}
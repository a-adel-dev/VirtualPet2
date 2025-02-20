using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameConfigManager : MonoBehaviour
{
    /// <summary>
    /// This script takes values from UI and use them to set the GameConfig scripts with values
    /// </summary>
    [SerializeField] private TMP_Text letterOne;
    [SerializeField] private TMP_Text letterTwo;
    [SerializeField] private TMP_Text letterThree;
    [SerializeField] private TMP_Text letterFour;
    [SerializeField] private TMP_Text letterFive;
    [SerializeField] private TMP_Text letterSix;
    [SerializeField] private Toggle leftHandedToggle;
    [SerializeField] private Toggle activeHapticsToggle;
    [SerializeField] private Toggle passiveHapticsToggle;

    public void PopulateGameConfig()
    {
        GameConfig.Instance.Username = $"{letterOne.text}{letterTwo.text}{letterThree.text}{letterFour.text}{letterFive.text}{letterSix.text}";
        GameConfig.Instance.IsLeftHanded = leftHandedToggle.isOn;
        GameConfig.Instance.IsUsingActiveHaptics = activeHapticsToggle.isOn;
        GameConfig.Instance.IsUsingPassiveHaptics = passiveHapticsToggle.isOn;
    }
}

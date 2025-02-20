
using UnityEngine;


public class Testing : MonoBehaviour
{
    
    [SerializeField] private TMPro.TMP_Text text;

    private void Start()
    {
        text.text = GameConfig.Instance.Username;
    }
}
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    // Singleton instance
    private static GameConfig _instance;

    // Public properties to access the configuration data
    public string Username { get; set; } = "Player";
    public bool IsLeftHanded { get; set; } = false;
    public bool IsUsingActiveHaptics { get; set; } = true;
    public bool IsUsingPassiveHaptics { get; set; } = false;

    // Public static property to access the singleton instance
    public static GameConfig Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameConfig>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<GameConfig>();
                    singletonObject.name = typeof(GameConfig).ToString();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    // Ensure the instance is not destroyed when loading a new scene
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Example method to initialize default values
    public void InitializeDefaultValues()
    {
        Username = "Player";
        IsLeftHanded = false;
    }
}
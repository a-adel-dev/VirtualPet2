using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Recommended build index structure:
    // 0 - MainMenu
    // 1 - Pet Interaction
    // 2 - Tutorial

    public void LoadTutorial()
    {
        if (SceneManager.sceneCountInBuildSettings > 2)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.LogError("Scene1 not found in build settings!");
        }
    }

    public void LoadInteraction()
    {
        if (SceneManager.sceneCountInBuildSettings > 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogError("Scene2 not found in build settings!");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        
        // For testing in editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
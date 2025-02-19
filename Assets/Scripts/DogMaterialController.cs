using UnityEngine;

public class DogMaterialController : MonoBehaviour
{
    // Reference to the dog's renderer component
    public Renderer dogRenderer;

    // Materials for different haptic conditions
    public Material activeHapticsMaterial;
    public Material passiveHapticsMaterial;
    public Material bothHapticsMaterial;
    public Material noHapticsMaterial;

    private void Start()
    {
        // Ensure the dogRenderer is assigned
        if (dogRenderer == null)
        {
            Debug.LogError("Dog Renderer is not assigned!");
            return;
        }

        // Determine the material based on haptic conditions
        DetermineDogMaterial();
    }

    private void DetermineDogMaterial()
    {
        // Get the haptic conditions from the GameConfig singleton
        bool useActiveHaptics = GameConfig.Instance.IsUsingActiveHaptics;
        bool usePassiveHaptics = GameConfig.Instance.IsUsingPassiveHaptics;

        // Determine the material based on the conditions
        if (useActiveHaptics && usePassiveHaptics)
        {
            dogRenderer.material = bothHapticsMaterial;
            // Debug.Log("Both active and passive haptics are enabled. Applying Both Haptics Material.");
        }
        else if (useActiveHaptics)
        {
            dogRenderer.material = activeHapticsMaterial;
            // Debug.Log("Active haptics are enabled. Applying Active Haptics Material.");
        }
        else if (usePassiveHaptics)
        {
            dogRenderer.material = passiveHapticsMaterial;
            // Debug.Log("Passive haptics are enabled. Applying Passive Haptics Material.");
        }
        else
        {
            dogRenderer.material = noHapticsMaterial;
            // Debug.Log("No haptics are enabled. Applying No Haptics Material.");
        }
    }
}
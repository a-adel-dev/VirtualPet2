using UnityEngine;
/*
    This script is attached to XROrigin > Right Hand > Right Hand Interaction Visual > R_Wrist > ColliderBox
    For now I only set up the Right hand with the assumption that the participant will follow the rule & always touch the dog with both hands
    Follow the documentation in Documentation/hand_interaction.md to set up the other hand if you want
*/
public class HandControl : MonoBehaviour
{
    [SerializeField] private HandIdentifier handIdentifier;
    [SerializeField] GloveController gloveController;
    [SerializeField] SequenceHandler sequenceHandler;
    private Animator _animator;

    
    

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("dog"))
        {
            DataLogger.Instance.LogData($"Petting with {gameObject.name} at {collider.gameObject.name}");
        }
    }

    void OnTriggerStay(Collider collider)
    {  
        if (!GameConfig.Instance.IsUsingActiveHaptics) return;
        if(collider.gameObject.CompareTag("dog"))
        {
            gloveController.PlayHapticFeedback(handIdentifier);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.CompareTag("dog"))
        {
            gloveController.StopHapticFeedback();
            _animator.SetBool("idle", false);
            DataLogger.Instance.LogData($"Stopped petting with {gameObject.name} at {collider.gameObject.name}");
        }
    }
}

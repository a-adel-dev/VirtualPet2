using UnityEngine;
using Bhaptics.SDK2;
// namespace Bhaptics.SDK2

/*
    This script is attached to [bhaptics] object
*/
public class GloveController : MonoBehaviour
{
    public bool clicked = false;
    public bool rightHand = true;   // change to false if left hand dominance
    [SerializeField] SequenceHandler sequenceHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked){
            BhapticsLibrary.Play("game_start");
            clicked = false;
        }
    }

    public void PlayHapticFeedback(HandIdentifier hand)
    {
        if (sequenceHandler.GetIsWaitingForPetting())
        {
            if (hand == HandIdentifier.Right)
            {
                BhapticsLibrary.Play("pet_r");
            }
            else
            {
                BhapticsLibrary.Play("pet_l");
            }
        }
    }

    public void StopHapticFeedback(){
        BhapticsLibrary.StopAll();
    }
}

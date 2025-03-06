using UnityEngine;
using System.Collections;

/*
    This script is attached to Snap Socket > SnapSocketTitle > SimpleSocket
*/
public class FeedInteractors : MonoBehaviour
{
    [SerializeField] GameObject dog;
    [SerializeField] GameObject bowl;
    [SerializeField] GameObject bone;
    [SerializeField] Transform attachPoint;
    [SerializeField] AudioSource pantingAudio;
    private SequenceHandler sequenceHandler;
    private int firstTime = 0;
    private int firstTimeBone = 0;
    private Animator animator;
    
    void Start()
    {
        sequenceHandler = dog.GetComponent<SequenceHandler>();
        animator = dog.GetComponent<Animator>();
    }
    
    void Update()
    {
        if(bowl.transform.position == attachPoint.position && firstTime == 0){
            // back to sitting 
            animator.SetBool("sleep", false);

            StartCoroutine(WaitABitBeforePrompt());
            firstTime = 1;
        }
        if(bone.transform.position == attachPoint.position){
            // Debug.Log($"First time bone {firstTimeBone}");
            if(firstTimeBone == 0){
                // back to sitting 
                animator.SetBool("idle", true);
                ReplayPanting();
                // prompt petting
                firstTimeBone = 1;
                StartCoroutine(WaitABitBeforePrompt());
            }else if(firstTimeBone == 2){
                // Debug.Log("Second time bone");
            }
        }
        
    }

    private void OnTriggerExit(Collider other) {
        // Debug.Log($"Exited trigger at {Time.time} pos: {bowl.transform.position}");
        if(other.gameObject == bowl){
            if(firstTime == 1){
                animator.SetBool("eating", false);
                pantingAudio.Stop();
                firstTime = 2;
                StartCoroutine(StopAttack());
            }
        }
        if(other.gameObject == bone){
            if(firstTimeBone == 1){
                // Debug.Log("picked up bone");
                firstTimeBone = 2;
            }
        }
    }

    IEnumerator StartEating(){
        yield return new WaitForSeconds(7);
        animator.SetBool("eating", true);
    }

    // DEMO only
    IEnumerator StopAttack(){
        yield return new WaitForSeconds(5);

        // prompt
        sequenceHandler.SetStateIndex(4);
    }

    IEnumerator WaitABitBeforePrompt(){

        yield return new WaitForSeconds(3);

        // prompt petting
        sequenceHandler.PromptPetting();
    }

    public void ReplayPanting(){
        if(!pantingAudio.isPlaying){
            pantingAudio.Play();
        }
    }


}

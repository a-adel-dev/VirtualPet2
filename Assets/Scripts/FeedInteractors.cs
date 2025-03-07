using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/*
    This script is attached to Snap Socket > SnapSocketTitle > SimpleSocket
*/
public class FeedInteractors : MonoBehaviour
{
    [SerializeField] GameObject dog;
    [SerializeField] AudioSource pantingAudio;
    private SequenceHandler sequenceHandler;
    private Animator animator;
    private XRSocketInteractor _interactor;
    private bool _readytoTakeBowl;
    private bool _bowlPlaced;
    
    void Start()
    {
        sequenceHandler = dog.GetComponent<SequenceHandler>();
        animator = dog.GetComponent<Animator>();
        _interactor = GetComponent<XRSocketInteractor>();
        _interactor.selectEntered.AddListener(OnObjectPlaced);
        _interactor.selectExited.AddListener(OnObjectRemoved);
    }
    
    
    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        GameObject placedObject = args.interactableObject.transform.gameObject;
        // Debug.Log($"Object placed: {placedObject}");

        if (placedObject.CompareTag("bowl") && !_bowlPlaced)
        {
            animator.SetBool("sleep", false);
            _bowlPlaced = true;
            StartCoroutine(WaitABitBeforePrompt());
        }
        else if (placedObject.CompareTag("bone"))
        {
            animator.SetBool("idle", true);
            ReplayPanting();
            StartCoroutine(WaitABitBeforePrompt());
        }
    }

    public void SetReadytoTakeBowl()
    {
        _readytoTakeBowl = true;
    }
    
    private void OnObjectRemoved(SelectExitEventArgs args)
    {
        GameObject removedObject = args.interactableObject.transform.gameObject;
        // Debug.Log($"Object removed: {removedObject.name}");

        if (removedObject.CompareTag("bowl") && _readytoTakeBowl)
        {
            animator.SetBool("eating", false);
            pantingAudio.Stop();
            StartCoroutine(StopAttack());
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

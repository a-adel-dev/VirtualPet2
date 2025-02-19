using System;
using UnityEngine;
using System.Collections;

/*
    This script is attached to Beagle_c1
    To get more details about the meaning of currentStateIndex, review Documentation/detailed_scenario.md and Documentation/sequence_handler.md
*/
public class SequenceHandler : MonoBehaviour
{
    public int currentStateIndex = 0;   // 0: start state
    public bool waitingForPetting = false;
    [SerializeField] GameObject fetchingUI;
    [SerializeField] GameObject pettingUI;
    [SerializeField] GameObject feedingUI;
    [SerializeField] GameObject takeAwayUI;
    [SerializeField] GameObject finishUI;
    [SerializeField] GameObject boneUI;
    [SerializeField] GameObject bowl;
    [SerializeField] GameObject socket;
    private Animator _dogAnimator;
    
    private Stopwatch _stopwatch;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _dogAnimator = GetComponent<Animator>();
        DataLogger.Instance.LogData("=============starting new session===============");
        DataLogger.Instance.LogData($"User name: {GameConfig.Instance.Username}");
        DataLogger.Instance.LogData($"{(GameConfig.Instance.IsLeftHanded ? "user is left handed" : "user is right handed")}");
        DataLogger.Instance.LogData($"{(GameConfig.Instance.IsUsingActiveHaptics ? "Active haptics is in use" : "No Active Haptics in use")}");
        DataLogger.Instance.LogData($"{(GameConfig.Instance.IsUsingPassiveHaptics ? "Passive haptics is in use" : "No Passive Haptics in use")}");
        DataLogger.Instance.LogData($"Session start Time: {DateTime.Now}");        
    }

    public void SetStateIndex(int num){
        currentStateIndex = num;
        PerformCurrentState();
    }

    public void IncrementStateIndex(){
        currentStateIndex += 1;
        DataLogger.Instance.LogData($"Current state: {currentStateIndex}");
        if (waitingForPetting){
            waitingForPetting = false;
        }
        PerformCurrentState();
    }

    private void PerformCurrentState(){
        if(currentStateIndex == 1){
            fetchingUI.SetActive(true);
        }else if(currentStateIndex == 2){
            _dogAnimator.SetBool("sleep", true);
            // bowl.SetActive(true);
            StartCoroutine(PromptFeeding());
        }else if(currentStateIndex == 3){
            _dogAnimator.SetBool("eating", true);
            StartCoroutine(PromptTakeAway());
        }else if(currentStateIndex == 4){
            boneUI.SetActive(true);
        }else if(currentStateIndex == 5){
            _dogAnimator.SetBool("bone", true);
            StartCoroutine(PickupBone());
        }else if(currentStateIndex == 6){
            finishUI.SetActive(true);
        }
    }

    public void PromptPetting(){
        pettingUI.SetActive(true);
    }

    IEnumerator PromptFeeding(){
        yield return new WaitForSeconds(2);
        socket.SetActive(true);
        feedingUI.SetActive(true);
    }

    IEnumerator PickupBone(){
        yield return new WaitForSeconds(2);
        _dogAnimator.SetBool("bone", false);
        // Debug.Log($"BONED {currentStateIndex}");
    }

    IEnumerator PromptTakeAway(){
        yield return new WaitForSeconds(5);
        takeAwayUI.SetActive(true);
    }

    public void SetWaitingForPetting(){
        waitingForPetting = true;
    }

    public bool GetIsWaitingForPetting(){
        return waitingForPetting;
    }

    public int GetCurrentStateIndex(){
        return currentStateIndex;
    }

    public void StartPetting()
    {
        _stopwatch = new Stopwatch();
        _stopwatch.Start();
        DataLogger.Instance.LogData("Starting Petting StopWatch");
    }

    public void StopPetting()
    {
        if (_stopwatch.IsRunning())
        {
            DataLogger.Instance.LogData($"Petting time: {_stopwatch.GetElapsedTime()}");
            _stopwatch.Stop();
            _stopwatch.Reset();
            DataLogger.Instance.LogData("Stopping Petting StopWatch");
        }
    }
}

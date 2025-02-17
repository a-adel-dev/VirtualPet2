using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DogAnimator : MonoBehaviour
{
    Animator _animator;
    DogAnimationState _currentDogAnimationState = DogAnimationState.Default;
    public float velocityX { get; set; }
    public float velocityZ { get; set; }
    
    private readonly Dictionary<DogAnimationState, string> AnimationMappings = new()
    {
        { DogAnimationState.Idle, "Idle" },
        { DogAnimationState.Bark, "Attack" },
        { DogAnimationState.TurnAround, "TurnAround" },
        { DogAnimationState.Jump, "Jump" },
        { DogAnimationState.Move, "Move" },
        { DogAnimationState.Sit, "Sit"},
        // Add more mappings here
    };

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
       
        

        // StartCoroutine(TestMethod());
    }

    private void Update()
    {
        _animator.SetFloat("Velocity X", velocityX);
        _animator.SetFloat("Velocity Z", velocityZ);
    }

    private IEnumerator TestMethod()
    {
        ChangeAnimationState(DogAnimationState.TurnAround);
        yield return new WaitForSeconds(6f);
        Debug.Log("start");
        _animator.SetFloat("Velocity X", 0f);
        _animator.SetFloat("Velocity Z", 0f);
        ChangeAnimationState(DogAnimationState.Bark);
        yield return new WaitForSeconds(2f);
        ChangeAnimationState(DogAnimationState.Move);
        _animator.SetFloat("Velocity X", .5f);
        _animator.SetFloat("Velocity Z", 2f);
        yield return new WaitForSeconds(2f);
        ChangeAnimationState(DogAnimationState.Jump);
    }

    public void ChangeAnimationState(DogAnimationState newState)
    {
        if (_currentDogAnimationState != newState)
        {
            _currentDogAnimationState = newState;
            Debug.Log("Changing animation state to " + AnimationMappings[newState]);
            _animator.Play(AnimationMappings[newState]);
        }
    }

    public void EaseIntoAnimation(DogAnimationState newState, float crossFade = 0.2f)
    {
        if (_currentDogAnimationState != newState)
        {
            _currentDogAnimationState = newState;
            _animator.CrossFade(AnimationMappings[newState], crossFade);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionStateMachine : MonoBehaviour
{
    public PromptUIController promptUIController;
    public DogAnimator dogAnimator;
    public Transform ball;
    
    private  Dictionary<InteractableObjects, Transform> Interactables = new(); 
    
    InteractionSMBase _currentState ;

    private InteractionSMBase _startState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        PopulateInteractablesDict();
        _startState = new InteractionSMStart(dogAnimator, promptUIController, Interactables);
        
    }

    private void PopulateInteractablesDict()
    {
        Interactables[InteractableObjects.Ball] = ball;
    }

    void Start()
    {
        ClearInteractableObjects();
        _currentState = _startState;
        _currentState.EnterState();
    }

    private void ClearInteractableObjects()
    {
        foreach (var interactable in Interactables)
        {
            interactable.Value.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PressButton()
    {
        _currentState.PressButton();
    }
    
    public void ExitState()
    {
        ClearInteractableObjects();
        _currentState = _currentState.ExitState();
        if (_currentState == null) return;
        _currentState.EnterState();
    }
}

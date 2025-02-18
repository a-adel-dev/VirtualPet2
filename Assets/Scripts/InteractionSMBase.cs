using System.Collections.Generic;
using UnityEngine;


public abstract class InteractionSMBase
{
    protected DogAnimator _animator;
    protected PromptUIController _promptUIController;
    protected Dictionary<InteractableObjects, Transform> _interactables;
    
    protected InteractionSMBase(DogAnimator animator, PromptUIController promptUIController, Dictionary<InteractableObjects, Transform> interactables)
    {
        _animator = animator;
        _promptUIController = promptUIController;
        _interactables = interactables;
    }

    public abstract void EnterState();
    public abstract InteractionSMBase ExitState();
    public abstract void UpdateState();
    
    public abstract void PressButton();
    


}


using System.Collections.Generic;
using UnityEngine;

public class InteractionSMFetchBall : InteractionSMBase
{
    public InteractionSMFetchBall(DogAnimator animator, PromptUIController promptUIController, 
        Dictionary<InteractableObjects, Transform> interactables) : base(animator, promptUIController, interactables )
    {
    }

    public override void EnterState()
    {
        _interactables[InteractableObjects.Ball].gameObject.SetActive(true);
    }

    public override InteractionSMBase ExitState()
    {
        return null;
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override void PressButton()
    {
        throw new System.NotImplementedException();
    }
}

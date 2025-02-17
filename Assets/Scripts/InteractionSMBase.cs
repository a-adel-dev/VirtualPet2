using UnityEngine;


public abstract class InteractionSMBase
{
    protected DogAnimator _animator;
    protected PromptUIController _promptUIController;
    
    public InteractionSMBase(DogAnimator animator, PromptUIController promptUIController)
    {
        _animator = animator;
        _promptUIController = promptUIController;
    }
    public abstract void EnterState();
    public abstract InteractionSMBase ExitState();
    public abstract void UpdateState();
    
    public abstract void PressButton();
    


}

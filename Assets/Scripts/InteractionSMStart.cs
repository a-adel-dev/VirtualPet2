
using UnityEngine;

public class InteractionSMStart : InteractionSMBase
{
    int _statePhase = 0;
    public InteractionSMStart(DogAnimator animator, PromptUIController promptUIController) : base(animator, promptUIController)
    {
        _animator = animator;
        _promptUIController = promptUIController;
    }

    public override void EnterState()
    {
        Debug.Log(_animator.gameObject.name + " is entering the start state");
        SetNextPhase();
    }

    public override InteractionSMBase ExitState()
    {
        return new InteractionSMFetchBall(_animator, _promptUIController);
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    public void SetNextPrompt()
    {
        switch (_statePhase)
        {
            case 0:
                _promptUIController.ShowPromptWindow();
                _promptUIController.SetPromptText("You have just welcomed a new virtual pet!");
                _statePhase++;
                break;
            case 1:
                _promptUIController.ShowPromptWindow();
                _promptUIController.SetPromptText("Pet the dog with both hands. Press the wrist button when you’re ready to move on");
                _statePhase++;
                break;
        }
    }

    public override void PressButton()
    {
        Debug.Log("button pressed");
        _promptUIController.HidePromptWindow();
        Debug.Log(_statePhase);
        SetNextPhase();
    }

    private void SetNextPhase()
    {
        switch (_statePhase)
        {
            case 0:
                Debug.Log("Start state phase 0");
                _animator.ChangeAnimationState(DogAnimationState.Sit);
                SetNextPrompt();
                break;
            case 1:
                Debug.Log("Start state phase 1");
                _animator.ChangeAnimationState(DogAnimationState.Sit);
                SetNextPrompt();
                break;
            case 2:
                Debug.Log("Start state phase 2");
                //Listen for petting
                break;
        }
    }
}

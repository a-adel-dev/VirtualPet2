
public class InteractionSMFetchBall : InteractionSMBase
{
    public InteractionSMFetchBall(DogAnimator animator, PromptUIController promptUIController) : base(animator, promptUIController)
    {
        _animator = animator;
        _promptUIController = promptUIController;
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
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

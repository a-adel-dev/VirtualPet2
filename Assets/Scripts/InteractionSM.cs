using UnityEngine;

public class InteractionSM : MonoBehaviour
{
    public PromptUIController promptUIController;
    public DogAnimator dogAnimator;

    
    InteractionSMBase _currentState ;

    private InteractionSMBase _startState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        _startState = new InteractionSMStart(dogAnimator, promptUIController);
    }

    void Start()
    {
        _currentState = _startState;
        _currentState.EnterState();
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
        _currentState = _currentState.ExitState();
        if (_currentState == null) return;
        _currentState.EnterState();
    }
    

    
}

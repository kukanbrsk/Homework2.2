using UnityEngine.InputSystem;

public abstract class GroundedState : MovementState
{
    private readonly GroundChecker _groundChecker;

    protected GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartGrounded();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches == false)
            StateSwitcher.SwitchState<FallingState>();

        if (IsFastKeyPressed())
            StateSwitcher.SwitchState<FastRunningState>();

        if (IsSlowRunPressed())
            StateSwitcher.SwitchState<SlowRunningState>();
    }

    protected override void AddInputActionsCallback()
    {
        base.AddInputActionsCallback();

        Input.Movement.Jump.started += OnJumpKeyPressed;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.Jump.started -= OnJumpKeyPressed;
    }
    

    private void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpingState>();
}

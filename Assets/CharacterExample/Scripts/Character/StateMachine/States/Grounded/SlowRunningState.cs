using UnityEngine;

public class SlowRunningState : GroundedState
{
    private readonly RunningStateConfig _config;
    
    public SlowRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;
    
    public override void Enter()
    {
        base.Enter();

        View.StartRunning();

        Data.Speed = _config.SlowSpeed;
    }
    
    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (!IsSlowRunPressed())
            StateSwitcher.SwitchState<RunningState>();
    }
}
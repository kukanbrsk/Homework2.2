using UnityEngine;

public class FastRunningState : GroundedState
{
    private readonly RunningStateConfig _config;
    
    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;
    
    public override void Enter()
    {
        base.Enter();

        View.StartRunning();

        Data.Speed = _config.FastSpeed;
    }
    
    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (!IsFastKeyPressed())
            StateSwitcher.SwitchState<RunningState>();
    }
}
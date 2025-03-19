using Cinemachine;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        
        AudioManager.instance.PlaySFX(11, null);
        GameObject.Find("Canvas").GetComponent<UI>().SwitchOnEndScreen();
    }

    public override void Update()
    {
        base.Update();
        
        player.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}

using UnityEngine;

public class DeathBringerTeleportState : EnemyState
{
    private Enemy_DeathBringer enemy;
    
    public DeathBringerTeleportState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_DeathBringer _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        
        enemy.stats.MakeInvincible(true);
        AudioManager.instance.PlaySFX(39, null);
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            if (enemy.CanDoSpellCast())
            {
                stateMachine.ChangeState(enemy.spellCastState);
                AudioManager.instance.PlaySFX(19, null);
            }
            else
               stateMachine.ChangeState(enemy.battleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        
        enemy.stats.MakeInvincible(false);
    }
}

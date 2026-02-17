using UnityEngine;

public class StageOne : State
{
    private BossStateMachine bossContext;
    public StageOne(BossStateMachine currentContext) : base(currentContext)
    {
        
        bossContext = currentContext;
        isBaseState = true;
        InitializeSubStates();
    }
    public override void InitializeSubStates()
    {
        float randomChance = Random.Range(0f, 1f);
        if (bossContext.canDashAttack())
        {
            SetSubState(new BossDashWindupState(bossContext));
        } else if (randomChance < 0.5f )
        {   
            SetSubState(new BossLaserAttackState(bossContext));
        } else if (bossContext.InRange())
        {
            SetSubState(new BossMeleeAttackState(bossContext));
        } else 
        {
            SetSubState(new BossIdleState(bossContext));
        }
    }
    public override void EnterState()
    {
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
    }

    public override void CheckSwitchStates()
    {
        if (bossContext.IsTransitioning)
        {
            SwitchState(new BossTransitionState(bossContext));
        }
        
    }
}

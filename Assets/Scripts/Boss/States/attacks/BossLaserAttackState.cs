using UnityEngine;
public class BossLaserAttackState : State
{
    private BossStateMachine bossContext;

    public BossLaserAttackState(BossStateMachine currentContext) : base(currentContext)
    {
        bossContext = currentContext;
    }

    public override void EnterState()
    {
        Debug.Log("laser attack");
        bossContext.Anim.SetTrigger("lasers");
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        bossContext.Anim.ResetTrigger("lasers");
    }

    public override void CheckSwitchStates()
    {
        if (bossContext.LasersFinished == 1)
        {
            SwitchState(new BossIdleState(bossContext));
        }
    }

}
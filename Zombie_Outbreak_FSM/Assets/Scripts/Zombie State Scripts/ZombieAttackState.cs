using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class ZombieAttackState : ZombieBaseState
{
    public override void EnterState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent)
    {
         
         npc.transform.Find("Canvas").transform.Find("Debug Text").GetComponent<TextMeshProUGUI>().text = "Atttack";
    }
    public override void UpdateState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent)
    {

        if (npc.transform.position.magnitude - player.transform.position.magnitude < 0.75f && npc.transform.position.magnitude - player.transform.position.magnitude > -0.75f && !player.GetComponent<Health>().isDead)
        {
            npcAnimator.SetBool("Attack", true);
        }
        else
        {
            npcSM.currentState.ExitState(npcSM, npcAnimator, player, npc, agent);
           // npcAnimator.SetBool("Attack", false);
           // npcSM.SwtitchState(npcSM.FollowState);
        }
    }


public override void ExitState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent)
{
    if (!player.GetComponent<Health>().isDead)
    {
        npcAnimator.SetBool("Attack", false);
        npcSM.SwtitchState(npcSM.FollowState);
    }
    else
    {
        npcAnimator.SetBool("Attack", false);
        npcSM.SwtitchState(npcSM.IdleState);
        
    }
}
}


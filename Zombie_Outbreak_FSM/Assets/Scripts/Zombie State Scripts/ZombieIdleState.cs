using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class ZombieIdleState : ZombieBaseState
{
    public override void EnterState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent)
    {
        npc.transform.Find("Canvas").transform.Find("Debug Text").GetComponent<TextMeshProUGUI>().text = "Idle";

        npcAnimator.SetFloat("Y", 0.0f);

        npcSM.StartCoroutine(npcSM.RotateObject());

    }
    public override void UpdateState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent)
    {
        if (npcSM.CanSeePlayer() && !player.GetComponent<Health>().isDead)
        {
            npcSM.currentState.ExitState(npcSM, npcAnimator, player, npc, agent);
        }
    }
    public override void ExitState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent)
    {
        npcSM.StopAllCoroutines();
        npcAnimator.SetFloat("X", 0.0f);
        npcSM.SwtitchState(npcSM.FollowState);
    }




}


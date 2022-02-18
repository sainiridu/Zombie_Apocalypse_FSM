using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class ZombieFollowState : ZombieBaseState
{
    public override void EnterState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent)
    {
        npc.transform.Find("Canvas").transform.Find("Debug Text").GetComponent<TextMeshProUGUI>().text = "Follow";
    
        agent.speed = 1.0f;
    }
    public override void UpdateState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent)
    {

        npcAnimator.SetFloat("Y", 0.5f);
        agent.SetDestination(player.transform.position);

        if (npc.transform.position.magnitude - player.transform.position.magnitude > 0.0f && npc.transform.position.magnitude - player.transform.position.magnitude <= 0.5f || npc.transform.position.magnitude - player.transform.position.magnitude < 0.0f && npc.transform.position.magnitude - player.transform.position.magnitude >= -0.5f)
        {
            npcSM.currentState.ExitState(npcSM, npcAnimator, player, npc, agent);
        }



    }
    public override void ExitState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent)
    {
        npcSM.SwtitchState(npcSM.AttackState);
    }
}

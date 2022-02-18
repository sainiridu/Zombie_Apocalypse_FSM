using UnityEngine;
using UnityEngine.AI;
public abstract class ZombieBaseState
{
    public abstract void EnterState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent);
    public abstract void UpdateState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent);
    public abstract void ExitState(ZombieStateManager npcSM, Animator npcAnimator, GameObject player, GameObject npc, NavMeshAgent agent);


}

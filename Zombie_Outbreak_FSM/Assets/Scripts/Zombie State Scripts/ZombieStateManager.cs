using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStateManager : MonoBehaviour
{

    Transform playerTF;
    Transform npcTF;

    NavMeshAgent agent;
    private Animator npcAnimator;

    private GameObject player;
    float seeDist = 5.0f;
    float seeAngle = 30.0f;



    public ZombieBaseState currentState;
    public ZombieIdleState IdleState = new ZombieIdleState();
    public ZombieFollowState FollowState = new ZombieFollowState();
    public ZombieAttackState AttackState = new ZombieAttackState();
    void Start()
    {
        npcAnimator = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");

        playerTF = player.transform;

        npcTF = this.gameObject.transform;

        currentState = IdleState;
        currentState.EnterState(this, npcAnimator, player, this.gameObject, agent);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this, npcAnimator, player, this.gameObject, agent);
    }

    public void SwtitchState(ZombieBaseState state)
    {
        currentState = state;
        currentState.EnterState(this, npcAnimator, player, this.gameObject, agent);
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = playerTF.position - npcTF.position;
        float angle = Vector3.Angle(direction, npcTF.forward);

        if (direction.magnitude < seeDist && angle < seeAngle)
        {
            return true;
        }

        return false;
    }


    public IEnumerator RotateObject()
    {
        bool pos = true;
        bool neg = false;

        while (true)
        {
            pos = !pos;
            neg = !neg;

            if (pos & !neg)
            {
                npcAnimator.SetFloat("X", 1);
            }

            else if (!pos & neg)
            {
                npcAnimator.SetFloat("X", -1);
            }

            yield return new WaitForSeconds(Random.Range(2.0f,5.0f));
            npcAnimator.SetFloat("X", 0); 

            // delay here
            yield return new WaitForSeconds(Random.Range(3.0f,10.0f));


        }

    }
}

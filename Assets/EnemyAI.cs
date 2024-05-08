using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent myNavMeshAgent;

    public Transform player;
    public LayerMask playerLayer;
    public float timer, distanceToHunt, wanderDuration;
    public float attackRange, timeBetweenAttacks;
    public bool playerInAttackRange;
    bool alreadyAttacked;

    private enum State
    {
        Wander,
        HuntForPlayer,
        Attack
    }

    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        currentState = State.Wander;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Wander:
                timer += Time.deltaTime;
                Wander();

                break;

            case State.HuntForPlayer:
                myNavMeshAgent.SetDestination(player.position);
                if (myNavMeshAgent.remainingDistance > distanceToHunt)
                {
                    currentState = State.Wander;
                }

                break;

            case State.Attack:
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
                Attack();

                break;
        }

    }

    private void Wander()
    {
        if (timer >= wanderDuration)
        {
            Vector2 wanderTarget = Random.insideUnitCircle * 100;
            Vector3 wanderPos3DPlane = new Vector3(transform.position.x + wanderTarget.x, transform.position.y,
                transform.position.z + wanderTarget.y);
            myNavMeshAgent.SetDestination(wanderPos3DPlane);
            timer = 0;
        }

        if (Vector3.Distance(transform.position, player.position) < distanceToHunt)
        {
            currentState = State.HuntForPlayer;
        }
    }

    private void Attack()
    {
        myNavMeshAgent.SetDestination(transform.position);
        transform.LookAt(player);
    }
}

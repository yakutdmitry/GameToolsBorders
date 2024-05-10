using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent myNavMeshAgent;
    private Animator animator;

    public Transform player;
    public LayerMask playerLayer;
    public float timer, distanceToHunt, wanderDuration;
    public float attackRange, timeBetweenAttacks;
    public bool playerInAttackRange;
    bool alreadyAttacked;
    private float attackCount = 0;


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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.Wander)
        {
            animator.SetBool("Patrol", true);
            animator.SetBool("Hunt", false);
        }

        if (currentState == State.HuntForPlayer)
        {
            animator.SetBool("Hunt", true);
            animator.SetBool("Patrol", false);
        }
        

        if (attackCount == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        switch (currentState)
        {
            case State.Wander:
                timer += Time.deltaTime;
                // animator.SetTrigger("Patrolling");

                Wander();
                break;

            case State.HuntForPlayer:
                myNavMeshAgent.SetDestination(player.position);
                // animator.SetTrigger("Chasing");
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

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Punch", true);
            StartCoroutine(attack());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Punch", false);
        }
        
    }

    private IEnumerator attack()
    {
        yield return new WaitForSeconds(1.5f);
        attackCount += 1;
    }
}

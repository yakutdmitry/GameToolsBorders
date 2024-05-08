using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIFollow : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.position);
    }

}

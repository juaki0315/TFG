using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform objetivo;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(objetivo.position);
    }    
}

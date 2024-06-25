using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; 
    public Collider2D detectionZone; 
    private NavMeshAgent agent;
    public bool playerInZone = false; 
    private bool isCollidingWithPlayer = false; 
    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerInZone && target != null && !isCollidingWithPlayer)
        {
            agent.SetDestination(target.position);
            FlipSprite();
        }
        else if (playerInZone && target != null && isCollidingWithPlayer)
        {
            agent.ResetPath();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Se ha pisdao");
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }

    void FlipSprite()
    {
        Vector3 direction = target.position - transform.position;

        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}

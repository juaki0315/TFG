using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float health = 1;

    public float Health {
        set 
        { 
            health = value;
            if (health < 1) 
            {
                EnemyDefeated();
            }
        }
        get
        {
            return health;
        }
    }

    public void TakeDamage(float damage) 
    {
        Health -= damage;
    }

    public void EnemyDefeated() 
    {
        Destroy(gameObject);
    }
}

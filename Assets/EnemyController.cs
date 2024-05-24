using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int health = 1;

    public int Health {
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

    public void EnemyDefeated() 
    {
        Destroy(gameObject);
    }
}

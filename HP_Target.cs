using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Target : MonoBehaviour
{
    //set up HP for target
    public float health = 70f;

    //void damage
    public void TakeDamage(float amouth)
    {
        //HP - Damage
        health -= amouth;
        if (health <= 0)
        {
            //Run method Die
            Die();
        }
    }
    void Die()
    {
        //Destory target
        Destroy(gameObject);
    }
}

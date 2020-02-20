using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public string unitName;

    public float damage;

    public FloatValue health;

    public Animator animator;

    public FloatValue totalHeals;
   
    public bool TakeDamage(float damage)
    {
        health.runtimeValue -= damage;

        if(health.runtimeValue <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(float amount)
    {
        if(totalHeals.runtimeValue > 0)
        {
            health.runtimeValue += amount;
            totalHeals.runtimeValue--;
        }
        else if(totalHeals.runtimeValue == 0)
        {
            return;
        }


        if(health.runtimeValue > health.initialValue)
        {
            health.runtimeValue = health.initialValue;
        }
    }



    void Start()
    {
        animator = GetComponent<Animator>();
    }

}

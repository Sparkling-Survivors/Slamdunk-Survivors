using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soyeon : MonoBehaviour
{
    Animator animator;
    float health = 100.0f;
    float damage = 10.0f;
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Ouch");
        if ((col.gameObject.CompareTag("Player")))
        {
            health -= damage;
            changAnimation();
        }
    }

    void changAnimation()
    {
        if (health < 25)
        {
            animator.Play("soyeon4");
        }
        else if (health < 50)
        {
            animator.Play("soyeon3");
        }
        else if (health < 75)
        {
            animator.Play("soyeon2");
        }
        else
        {
            animator.Play("soyeon1");
        }
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("health", health);
    }
}

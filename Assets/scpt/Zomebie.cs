using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zomebie : Character
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 1.0f;
    public Rigidbody2D rb;
    private ZombieHandler mHandler;
    void Move()
    {
        rb.velocity = Vector3.left * speed;
    }

    void Start()
    {
        //cooldown = damageRate;
        mHandler = new ZombieHandler(this);
        mHandler.Init();
    }

    void Update()
    {
        mHandler.Process();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Log.Debug(collision.gameObject);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            mHandler.TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("Plant"))
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                mHandler.MetPlant(damageable);
            }
        }
    }

    private void SetState(bool isMove = false, bool isEat = false, bool isDie = false)
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("walk", isMove);
        animator.SetBool("eat", isEat);
        // animator.SetBool("die", isDie);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            mHandler.ExitPlant();
        }
    }

    internal void OnIdle()
    {
        SetState();
    }

    internal void OnMove()
    {
        SetState(isMove: true);
        Move();
    }

    internal void OnAttack()
    {
        SetState(isEat: true);
        rb.velocity = Vector3.zero;
    }

    internal void OnDie()
    {
        Destroy(gameObject);
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieHandler
{
    Zomebie mZombie;
    State mState;
    private int mHp = 10;
    private float mCooldown = 0;
    private readonly float mDamageRate = 1;
    private IDamageable mDamageable;

    public ZombieHandler(Zomebie zombie)
    {
        mZombie = zombie;
    }

    internal void ExitPlant()
    {
        mDamageable = null;
        OnStateChange(State.Move);
    }

    internal void Init()
    {
        mState = State.Move;
    }

    internal void MetPlant(IDamageable damageable)
    {
        mDamageable = damageable;
        OnStateChange(State.Attack);
    }

    internal void Process()
    {
        switch (mState)
        {
            case State.Idle:
                {
                    mZombie.OnIdle();
                    break;
                }
            case State.Move:
                {

                    mZombie.OnMove();
                    break;
                }
            case State.Attack:
                {
                    mCooldown -= Time.deltaTime;
                    if (mCooldown <= 0)
                    {
                        mCooldown = mDamageRate;
                        //deal damage to plant
                        mDamageable.TakeDamage(1);
                    }
                    mZombie.OnAttack();
                    break;
                }
            case State.Die:
                {
                    mZombie.OnDie();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    internal void TakeDamage(int v)
    {
        mHp -= v;
        if (mHp <= 0)
        {
            OnStateChange(State.Die);
        }
    }

    private void OnStateChange(State die)
    {
        mState = die;
        Process();
    }

    internal enum State
    {
        Idle = 0,
        Move,
        Attack,
        Die
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerHandler
{
    private readonly SunFlower mSunflower;
    private float mSunTime;
    private float mMaxSunTime;
    private float mHp;

    public SunFlowerHandler(SunFlower sunflower)
    {
        mSunflower = sunflower;
    }

    public void Config(float sunTime, float hp)
    {
        mMaxSunTime = sunTime;
        mHp = hp;
    }

    public void Init()
    {
        mSunTime = mMaxSunTime;
    }

    public void Process()
    {
        mSunTime -= Time.deltaTime;
        if (mSunTime < 0)
        {
            mSunflower.GennerateSun();
            mSunTime = mMaxSunTime;
        }
    }

    public void TakeDamage(int amount)
    {
        mHp -= amount;
        if (mHp <= 0) mSunflower.OnDie();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : Character, SunGenerator, IDamageable
{
    private SunFlowerHandler mHandler;
    public GameObject sunPrefab;
    private ShopHandler mShopHandler;

    internal void GennerateSun()
    {
        var sun = Instantiate(sunPrefab, transform.position + Vector3.back, Quaternion.identity);
        sun.GetComponent<Sun>().SetShopHandler(mShopHandler);
    }

    internal void OnDie()
    {
        Log.Debug(nameof(OnDie));
        Destroy(gameObject);
    }

    void Start()
    {
        mHandler = new SunFlowerHandler(this);
        mHandler.Config(sunTime: 20, hp: 5);
        mHandler.Init();
    }

    void Update()
    {
        mHandler.Process();
    }

    public void SetShopHandler(ShopHandler shopHandler)
    {
        mShopHandler = shopHandler;
    }

    public void TakeDamage(int damage)
    {
        mHandler.TakeDamage(damage);
    }
}

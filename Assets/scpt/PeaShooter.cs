using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PeaShooter : Character, IDamageable
{
    private GameObject head;
    public GameObject bulletPref;
    [SerializeField]
    private PeaShooterConfig mConfig = new PeaShooterConfig { idleTime = 3.0f, shootingTime = 2.0f, hp = 10 };
    private PeaShooterHandler mHandler;
    void Start()
    {
        head = transform.Find("head").gameObject;
        mHandler = new PeaShooterHandler(this);
        mHandler.Config(mConfig);
        mHandler.Init();
    }

    void state(bool isShooting)
    {
        head.GetComponent<Animator>().SetBool("shooting", isShooting);
    }

    void Update()
    {
        mHandler.Process();
    }

    public void TakeDamage(int damage)
    {
        Log.Debug(nameof(TakeDamage));
        mHandler.TakeDamage(damage);
    }

    internal void OnIdle()
    {
        Log.Debug(nameof(OnIdle));
        state(false);
    }

    internal void OnShooting()
    {
        Log.Debug(nameof(OnShooting));
        state(true);
    }

    internal void OnShoot()
    {
        Log.Debug(nameof(OnShoot));
        var firePoint = head.transform.Find("Fire point").gameObject.transform;
        Instantiate(bulletPref, firePoint.position, firePoint.rotation);
    }

    internal void OnDie()
    {
        Log.Debug(nameof(OnDie));
        Destroy(gameObject);
    }
}

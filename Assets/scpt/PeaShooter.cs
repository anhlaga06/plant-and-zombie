using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PeaShooter : MonoBehaviour 
{
    private GameObject head;
    public GameObject bulletPref;
    [SerializeField]
    private PeaShooterConfig mConfig = new PeaShooterConfig {idleTime = 3.0f, shootingTime = 2.0f, hp = 10 };
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

    public void takeDamage(int damage)
    {
        Debug.Log(nameof(takeDamage));
        mHandler.TakeDamage(damage);
    }

    internal void OnIdle()
    {
        Debug.Log(nameof(OnIdle));
        state(false);
    }

    internal void OnShooting()
    {
        Debug.Log(nameof(OnShooting));
        state(true);
    }

    internal void OnShoot()
    {
        Debug.Log(nameof(OnShoot));
        var firePoint = head.transform.Find("Fire point").gameObject.transform;
        Instantiate(bulletPref, firePoint.position, firePoint.rotation);
    }

    internal void OnDie()
    {
        Debug.Log(nameof(OnDie));
        Destroy(gameObject);
    }
}

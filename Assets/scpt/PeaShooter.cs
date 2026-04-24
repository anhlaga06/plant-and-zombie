using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PeaShooter : MonoBehaviour 
{
    // Start is called before the first frame update
    [SerializeField]
    private float shootRate = 5.0f;
    [SerializeField]
    private float readyRate = 3.0f;
    private float cooldown = 0;
    private GameObject head;
    public GameObject bulletPref;
    private int hp = 10;
    public GameObject _shop;
    void Start()
    {
        head = transform.Find("head").gameObject;
    }

    void state(bool isShooting)
    {
        head.GetComponent<Animator>().SetBool("shooting", isShooting);
    }

    void shoot()
    {
        var firePoint = head.transform.Find("Fire point").gameObject.transform;
        Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        state(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool isReady = false;
        if (cooldown < shootRate)
        {
            cooldown += Time.deltaTime;
            if (cooldown > readyRate && !isReady)
            {
                state(isShooting: true);
                isReady = true;
            }
        } else
        {
            shoot();
            cooldown = 0;
            isReady = false;
        }

    }

    public void takeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("hit: " + damage);
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }
}

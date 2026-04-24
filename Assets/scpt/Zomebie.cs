using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zomebie : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 1.0f;
    public Rigidbody2D rb;
    private int hp = 10;
    private float cooldown = 0;
    private float damageRate = 1;
    void move()
    {
        rb.velocity = Vector3.left * speed;
    }

    void Start()
    {
        //cooldown = damageRate;
        move();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("plant_bullet"))
        {
            Destroy(collision.gameObject);
            if (--hp == 0)
            {
                Destroy(gameObject);
            }
        } else
        {
            rb.velocity = Vector3.left * 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var plant = collision.GetComponent<PeaShooter>();
        if (plant != null) 
        {
            cooldown -= Time.deltaTime;
            if (cooldown < 0) 
            {
                cooldown = damageRate;
                plant.takeDamage(1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        move();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peaBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 2.0f;
    public Rigidbody2D rg;

    private float h, w;
    void Start()
    {
        rg.velocity = Vector3.right * speed;
        var camSize = Camera.main.orthographicSize;
        h = camSize;
        w = h * Screen.width / Screen.height;
        //Debug.Log("H: " + h + ", W: " + w);
    }

    bool isOutScreen(Vector3 positon)
    {
        return (Math.Abs(positon.x) > w || Math.Abs(positon.y) > h);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOutScreen(transform.position))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit something");
        Destroy(this.gameObject);
    }

}

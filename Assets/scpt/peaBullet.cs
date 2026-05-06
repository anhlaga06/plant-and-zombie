using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peaBullet : Bullet
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 2.0f;
    public Rigidbody2D rg;

    private float h, w;
    void Start()
    {
        rg.velocity = Vector3.right * speed;
        Log.Debug(rg.velocity);
        var camSize = Camera.main.orthographicSize;
        h = camSize;
        w = h * Screen.width / Screen.height;
        Log.Debug("H: " + h + ", W: " + w);
    }

    bool isOutScreen(Vector3 positon)
    {
        return (Math.Abs(positon.x) > w || Math.Abs(positon.y) > h);
    }

    // Update is called once per frame
    void Update()
    {
        Log.Debug(rg.velocity);
        if (isOutScreen(transform.position))
        {
            Destroy(this.gameObject);
        }
    }
}

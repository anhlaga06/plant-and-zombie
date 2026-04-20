using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerDownHandler
{
    public GameObject shop;
    public void OnPointerDown(PointerEventData eventData)
    {
        //call shop to plant
        var plantPos = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z);
        shop.GetComponent<Shop>().Plant(plantPos);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

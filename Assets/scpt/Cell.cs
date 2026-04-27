using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerDownHandler
{
    private ShopHandler mShopHandler;

    public void SetShopHandler(ShopHandler shopHandler)
    {
        mShopHandler = shopHandler;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //call shop to plant
        Debug.Log("clicked!");
        var plantPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        mShopHandler.Plant(plantPos);
    }

}

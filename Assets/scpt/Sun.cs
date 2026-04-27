using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sun : Bullet, IPointerDownHandler
{
    private ShopHandler mShopHandler;

    public void SetShopHandler(ShopHandler handler)
    {
        mShopHandler = handler;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(nameof(OnPointerDown));
        mShopHandler.AddSun(50);
        Destroy(gameObject);
    }

}

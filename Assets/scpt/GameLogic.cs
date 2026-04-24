using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject shop;
    public GameObject garden;
    void Start()
    {
        var shopSc = shop.GetComponent<Shop>();
        var shopHandler = new ShopHandler(shopSc);
        shopSc.SetShopHandler(shopHandler);
        shopHandler.LoadItem();
        var gardenSc = garden.GetComponent<Garden>();
        gardenSc.SetShopHandler(shopHandler);
        gardenSc.GenerateCells();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

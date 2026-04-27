using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject shop;
    public GameObject garden;
    public GameObject zombiePrefab;
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

    [ContextMenu("spawn zombie")]
    void SpawnZomebie()
    {
        //Screen
        var h = Camera.main.orthographicSize;
        var w = h * Screen.width / Screen.height;
        Instantiate(zombiePrefab, new Vector3(w / 2, 0, 0), Quaternion.identity);
    }
    void Update()
    {
        
    }
}

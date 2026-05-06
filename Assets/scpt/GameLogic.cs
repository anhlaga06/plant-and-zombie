using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance { get; private set; }

    public GameObject shop;
    public GameObject garden;
    public GameObject zombiePrefab;

    [SerializeField]
    private Vector3 GardensPos = new(4.35f, -0.34f, 0);
    [SerializeField]
    private Vector3 CellSize = new(1.25f, 1.4f, 1);

    private void Awake()
    {
        Log.level = Log.Level.Error;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Log.Info("GameLogic initialized.");
    }

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

    public Vector3 GetGardensPos()
    {
        return GardensPos;
    }

    public Vector2 GetCellSize()
    {
        return CellSize;
    }
}

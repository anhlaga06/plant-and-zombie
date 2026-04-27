using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class PlantItem
{
    public string id;
    public GameObject plant;
    public int cost;
    public float cooldown;

    public string ImgPath()
    {
        return "shop/" + id;
    }

    public PlantItem Clone()
    {
        return (PlantItem)this.MemberwiseClone();
    }
}
public class Shop : MonoBehaviour
{
    public List<PlantItem> mItems;
    public GameObject mItemSamplePrefab;
    public GameObject mPreviewPrefab;
    private GameObject mCurrentPreview;

    public GameObject mBankPrefab;
    private Bank mBankHandler;
    private ShopHandler mShopHandler;

    public void SetShopHandler(ShopHandler shopHandler)
    {
        mShopHandler = shopHandler;
    }

    public void LoadItem()
    {
        var start = (gameObject.GetComponent<SpriteRenderer>().bounds.min);
        var startPos = new Vector3(start.x, start.y, transform.position.z - 1);
        var bank = Instantiate(mBankPrefab, startPos + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
        bank.transform.SetParent(transform);
        mBankHandler = bank.GetComponent<Bank>();
        for (int i = 0; i < mItems.Count; i++) {
            var item = mItems[i];
            var cell = Instantiate(mItemSamplePrefab);
            cell.transform.SetParent(transform);
            cell.transform.position = startPos + new Vector3(1.5f + i, 0.5f, 0);
            cell.GetComponent <Item>().Init(item, mShopHandler);
        }
    }

    public void OnPreview(PlantItem item)
    {
        Debug.Log(nameof(OnPreview));
        var sr = mPreviewPrefab.GetComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(item.ImgPath());
        mCurrentPreview = Instantiate(mPreviewPrefab, transform.position + Vector3.back, transform.rotation);
    }

    public void SetBank(int amount)
    {
        Debug.Log(nameof(SetBank));
        mBankHandler.SetNumber(amount);
    }

    public void OnStopPreview()
    {
        Debug.Log(nameof(OnStopPreview));
        Destroy(mCurrentPreview);
    }

    public void OnPlant(ShopEventData even, Vector3 position)
    {
        Debug.Log(nameof(OnPlant));
        var plant = Instantiate(even.item.plant, position, Quaternion.identity);
        if (plant.TryGetComponent<SunGenerator>(out var p))
        {
            p.SetShopHandler(mShopHandler);
        }
        even.caller.GetComponent<Item>().Deactivate();
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class PlantItem
{
    public string id;
    public GameObject plant;

    public string ImgPath()
    {
        return "shop/" + id;
    }

    public PlantItem(PlantItem item)
    {
        this.id = item.id;
        this.plant = item.plant;
    }
    public PlantItem() {}
}
public class Shop : MonoBehaviour
{
    private ShopHandler mShopHandler;
    private PlantItem mLastBuy = null;
    public List<PlantItem> mItems;
    public GameObject mItemSample;
    public GameObject mItemPreview;
    private GameObject mCurrentPreview;

    private void LoadItem()
    {
        var start = (gameObject.GetComponent<SpriteRenderer>().bounds.min);
        for (int i = 0; i < mItems.Count; i++) {
            var item = mItems[i];
            var cell = Instantiate(mItemSample);
            cell.transform.SetParent(transform);
            cell.transform.position = new Vector3(start.x + i + 0.5f, start.y + 0.5f, transform.position.z - 1);
            cell.GetComponent <Item>().Init(item, mShopHandler);
        }
    }

    private void Start()
    {
        mShopHandler = new ShopHandler(this);
        LoadItem();
    }

    public void Buy(PlantItem item)
    {
        mLastBuy = item;
        var sr = mItemPreview.GetComponent<SpriteRenderer>();
        mItemPreview.transform.localScale = Vector3.one;
        sr.sprite = Resources.Load<Sprite>(item.ImgPath());
        Debug.Log("before "+sr.bounds.size);
        mItemPreview.transform.localScale = new Vector3(1f / sr.bounds.size.x, 1f / sr.bounds.size.y, 1);
        mCurrentPreview = Instantiate(mItemPreview);
        Debug.Log("buy item " + item.id);
        Debug.Log("after "+sr.bounds.size);
    }

    public void Refund()
    {
        Debug.Log("refund lastBuy: " + mLastBuy.id);
        if (mLastBuy == null) return;
        Destroy(mCurrentPreview);
        mLastBuy = null;
    }

    public void Plant(Vector3 position)
    {
        Debug.Log("plant at: "+ position);
        if (!IsBuying()) return;
        Destroy(mCurrentPreview);
        Instantiate(mLastBuy.plant, position, Quaternion.identity);
        mLastBuy = null;
    }

    public bool IsBuying()
    {
        return mLastBuy != null;
    }
}

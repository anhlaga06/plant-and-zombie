using UnityEngine;
using UnityEngine.EventSystems;

public class ShopEventData
{
    public KeyCode key;
    public PointerEventData pointer;
    public Item caller;
    public PlantItem item;
}
public class ShopHandler
{
    private Shop mShop;
    private int mBankAccount = 150;
    private ShopEventData mLastBuy;

    public ShopHandler(Shop shop)
    {
        mShop = shop;
    }

    public void LoadItem()
    {
        mShop.LoadItem();
        mShop.SetBank(mBankAccount);
    }

    public void SetBank(int amount)
    {
        mBankAccount = amount;
        mShop.SetBank(mBankAccount);
    }

    public void handle(ShopEventData eventData)
    {
        if (eventData.key == KeyCode.Mouse0)
        {
            if (IsBuying())
            {
                RefundLastBuy();
            } else
            {
                if (Buy(eventData.item))
                {
                    mLastBuy = eventData;
                    Preview(eventData.item);
                }
            }
        } else if (eventData.key == KeyCode.Escape)
        {
            RefundLastBuy();
        }
    }

    private void RefundLastBuy()
    {
        mBankAccount += mLastBuy.item.cost;
        mLastBuy = null;
        mShop.SetBank(mBankAccount);
        mShop.OnStopPreview();
    }

    private bool IsBuying()
    {
        return mLastBuy != null;
    }

    private bool Buy(PlantItem item)
    {
        if(item.cost >  mBankAccount)
        {
            return false;
        }
        mBankAccount -= item.cost;
        mShop.SetBank(mBankAccount);
        return true;
    }

    private void Preview(PlantItem item)
    {
        mShop.OnPreview(item);
    }

    public void Plant(Vector3 position)
    {
        if (!IsBuying()) return;
        mShop.OnStopPreview();
        mShop.OnPlant(mLastBuy.item, position);
        mLastBuy = null;
    }
}

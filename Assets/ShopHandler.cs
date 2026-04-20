using UnityEngine;
using UnityEngine.EventSystems;

public class ShopEventData
{
    public KeyCode key;
    public PointerEventData pointer;
}
public class ShopHandler
{
    private Shop mShop;

    public ShopHandler(Shop shop)
    {
        mShop = shop;
    }

    public void handle(ShopEventData eventData, PlantItem item)
    {
        if (eventData.key == KeyCode.Mouse0)
        {
            if (mShop.IsBuying())
            {
                mShop.Refund();
            } else
            {
                mShop.Buy(item);
            }
        } else if (eventData.key == KeyCode.Escape)
        {
            mShop.Refund();
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler
{
    private ShopHandler mShopHandler;
    private PlantItem mItem;
    
    public void Init(PlantItem item, ShopHandler shop)
    {
        this.mItem = item;
        this.mShopHandler = shop;
    }
    private void LoadAvatar()
    {
        Debug.Log("Load " + mItem.ImgPath());
        var sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(mItem.ImgPath());
        
        var spriteSize = sr.bounds.size;
        Debug.Log(spriteSize);
        transform.localScale = new Vector3(1f / spriteSize.x, 1f / spriteSize.y, 1);
    }

    private void Start()
    {
        LoadAvatar();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mShopHandler.handle(new ShopEventData { key = KeyCode.Mouse0, pointer = eventData }, new PlantItem(mItem));
        Debug.Log(mItem.id + " clicked!");
    }

}

using UnityEngine;
using UnityEngine.EventSystems;

public class Item : Background, IPointerDownHandler
{
    private ShopHandler mShopHandler;
    private PlantItem mItem;
  
    Material material;
    private float timer = 0;
    private bool deactivate;

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
    }

    private void Start()
    {
        LoadAvatar();
        var sr = GetComponent<SpriteRenderer>();

        material = new Material(sr.material);
        sr.material = material;

        material.SetFloat("_Progress", 1);
    }

    private void onCoolDown()
    {
        timer += Time.deltaTime;
        var progress = timer / mItem.cooldown;
        Debug.Log("on cooDown" + progress);
        if ( progress >= 1)
        {
            progress = 1;
            timer = 0;
            deactivate = false;
        }
        material.SetFloat("_Progress", progress);
    }

    public void Deactivate()
    {
        deactivate = true;
    }

    public PlantItem GetInfo()
    {
        return mItem.Clone();
    }

    private void Update()
    {
        if ( deactivate )
        {
            onCoolDown();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if ( deactivate )
        {
            return;
        }
        mShopHandler.handle(new ShopEventData { key = KeyCode.Mouse0, pointer = eventData, caller = this , item = GetInfo()});
        Debug.Log(mItem.id + " clicked!");
    }

}

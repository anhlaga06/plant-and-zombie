using UnityEngine;
using UnityEngine.EventSystems;

public class Sun : Bullet, IPointerDownHandler
{
    private ShopHandler mShopHandler;
    private bool mMoveToBank = false;
    private Vector3 mBankPos;

    public void SetShopHandler(ShopHandler handler)
    {
        mShopHandler = handler;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(nameof(OnPointerDown));
        mMoveToBank = true;
        mBankPos = mShopHandler.GetBankPos();
    }

    void Update()
    {
        if (!mMoveToBank) return;
        MoveToBank();
        if (Vector3.Distance(mBankPos, transform.position) < 0.3f)
        {
            mShopHandler.AddSun(50);
            Destroy(gameObject);
        }
    }

    void MoveToBank()
    {
        var v = 5.0f;
        var dir = (mBankPos - transform.position);
        transform.position += Time.deltaTime * v * dir;
    }

}

using UnityEngine;

public class Garden : MonoBehaviour
{
    public GameObject cellPrefab;
    private ShopHandler mShopHandler;

    public void SetShopHandler(ShopHandler shopHandler)
    {
        mShopHandler = shopHandler;
    }

    public void GenerateCells()
    {
        Debug.Log(nameof(GenerateCells));
        for (int i = 0; i < 7; i++)
        {
            Vector2 pos = new Vector2(-7 + i, 0);
            var cell = Instantiate(cellPrefab, pos, Quaternion.identity);
            cell.transform.SetParent(transform);
            cell.GetComponent<Cell>().SetShopHandler(mShopHandler);
        }
    }
}

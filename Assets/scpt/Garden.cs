using UnityEngine;

public class Garden : MonoBehaviour
{
    public GameObject cellPrefab;
    private ShopHandler mShopHandler;

    public void SetShopHandler(ShopHandler shopHandler)
    {
        mShopHandler = shopHandler;
    }

    private void  GenerateLine(int lineTh)
    {
        bool dark = lineTh % 2 == 0;
        for (int i = 0; i < 7; i++)
        {
            Vector2 pos = new Vector2(-7 + i, lineTh);
            var cell = Instantiate(cellPrefab, pos, Quaternion.identity);
            cell.transform.SetParent(transform);
            cell.GetComponent<Cell>().SetShopHandler(mShopHandler);
            cell.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("garden/cell_" + (dark ? "d" : "l"));
        }
    }

    public void GenerateCells()
    {
        Debug.Log(nameof(GenerateCells));
        GenerateLine(0);
        GenerateLine(-1);
        GenerateLine(1);
    }
}

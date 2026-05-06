using UnityEngine;

public class Garden : Background
{
    public GameObject cellPrefab;
    private ShopHandler mShopHandler;

    public void SetShopHandler(ShopHandler shopHandler)
    {
        mShopHandler = shopHandler;
    }

    private void GenerateLine(int lineTh)
    {
        var cellSize = GameLogic.Instance.GetCellSize();
        for (int i = 0; i < 9; i++)
        {
            bool dark = (lineTh + i) % 2 == 0;
            var pos = Vector3.Scale(cellSize, new Vector3(-7 + i, lineTh, 0));
            var cell = Instantiate(cellPrefab, pos, Quaternion.identity);
            cell.transform.SetParent(transform);
            cell.transform.localScale = cellSize;
            cell.GetComponent<Cell>().SetShopHandler(mShopHandler);
            cell.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("garden/cell_" + (dark ? "d" : "l"));
        }
    }

    public void GenerateCells()
    {
        Log.Debug(nameof(GenerateCells));
        GenerateLine(0);
        GenerateLine(-1);
        GenerateLine(1);
        GenerateLine(2);
        GenerateLine(-2);
    }

    private void Start()
    {
        transform.position = GameLogic.Instance.GetGardensPos();
    }
}

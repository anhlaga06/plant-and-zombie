using UnityEngine;

public class Garden : MonoBehaviour
{
    public GameObject cellPre;
    public GameObject shop;

    void Start()
    {
        GenerateCells();
    }

    private void GenerateCells()
    {
        for (int i = 0; i < 7; i++)
        {
            Vector2 pos = new Vector2(-7 + i, 0);
            var cell = Instantiate(cellPre, pos, Quaternion.identity);
            cell.transform.SetParent(transform);
            cell.GetComponent<Cell>().shop = shop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

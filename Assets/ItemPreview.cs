using UnityEngine;

public class ItemPreview : MonoBehaviour
{
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var cell = OverlapGardenCell(mousePos);
        if (cell != null)
        {
            var pos = cell.transform.position;
            var size = cell.bounds.size;
            var center = new Vector2(pos.x + size.x / 2, pos.y + size.y / 2);
            MoveTo(center);
        } else
        {
            MoveTo(mousePos);
        }
    }

    private Collider2D OverlapGardenCell(Vector3 point)
    {
        Collider2D[] results = new Collider2D[1];

        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Garden cell"));
        int count = Physics2D.OverlapPoint(point, filter, results);
        if (count > 0) return results[0];
        return null;
    }

    private void MoveTo(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

}

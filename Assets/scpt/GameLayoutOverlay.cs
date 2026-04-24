using UnityEngine;

public class PixelGridGuide : MonoBehaviour
{
    [Header("Pixel Settings")]
    public int pixelsPerUnit = 128;
    public int gridWidth = 20;
    public int gridHeight = 20;

    [Header("Visual")]
    public Color lineColor = new Color(0f, 1f, 0f, 0.4f);
    public Color textColor = Color.white;
    int _draw = 0;

    void OnDrawGizmos()
    {
        //if (_draw > 10) return;
        //_draw++;
        DrawGrid();
    }

    void DrawGrid()
    {
        float cellSize = 1f; // 1 unit = 128px nếu PPU = 128

        for (int x = -gridWidth/2; x <= gridWidth/2; x++)
        {
            for (int y = -gridHeight/2; y <= gridHeight/2; y++)
            {
                Vector3 pos = new Vector3(x * cellSize, y * cellSize, 0);

                // draw cell corner
                DrawCell(pos, x, y);
            }
        }

        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector3(0, 0, 0), new Vector3(0.2f, 0.2f, 0));
        DrawLines(cellSize);
    }

    void DrawLines(float cellSize)
    {
        Gizmos.color = lineColor;
        int minY = -gridHeight / 2;
        int maxY = gridHeight / 2;
        int maxX = gridWidth / 2;
        int minX = -gridWidth / 2;
        // vertical lines
        for (int x = minX; x <= maxX; x++)
        {
            Vector3 start = new Vector3(x * cellSize, minY * cellSize, 0);
            Vector3 end = new Vector3(x * cellSize, maxY * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }

        // horizontal lines
        for (int y = minY; y <= maxY; y++)
        {
            Vector3 start = new Vector3(minX * cellSize, y * cellSize, 0);
            Vector3 end = new Vector3(maxX * cellSize, y * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }
    }

    void DrawCell(Vector3 pos, int x, int y)
    {
#if UNITY_EDITOR
        //UnityEditor.Handles.color = textColor;
        //UnityEditor.Handles.Label(
        //    pos + new Vector3(0.05f, 0.05f, 0),
        //    $"({x},{y})"
        //);
#endif
    }
}
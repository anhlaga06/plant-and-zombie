using UnityEngine;

public class Background : LayerMonoBehaviour
{
    void Awake()
    {
        InitLayer("Background");
        InitSortingOrder(1);
    }
}
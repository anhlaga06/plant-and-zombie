using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMonoBehaviour : MonoBehaviour
{
    protected void InitLayer(string layer)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingLayerName = layer;
        }
        foreach (var child in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            child.sortingLayerName = layer;
        }

        var canvas = GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.sortingLayerName = layer;
        }
        // foreach (var child in gameObject.GetComponentsInChildren<Canvas>())
        // {
        // child.sortingLayerName = canvas.sortingLayerName;
        // }
    }

    protected void InitSortingOrder(int order)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingOrder = order;
        }
        // foreach (var child in gameObject.GetComponentsInChildren<SpriteRenderer>())
        // {
        // child.sortingOrder = order;
        // }

        var canvas = GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.sortingOrder = order;
        }
    }
}

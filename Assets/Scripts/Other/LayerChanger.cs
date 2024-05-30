using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LayerChanger : MonoBehaviour
{
    public float layer;

    // Update is called once per frame
    void Update()
    {
        var sprite = GetComponent<SpriteRenderer>();
        if (transform.parent != null)
        {
            sprite.sortingOrder = Mathf.RoundToInt(transform.parent.localPosition.y * -10f + layer);
        }
        else
        {
            sprite.sortingOrder = Mathf.RoundToInt(transform.localPosition.y * -10f + layer);
        }
    }
}

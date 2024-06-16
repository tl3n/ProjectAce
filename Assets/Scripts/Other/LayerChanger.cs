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
        sprite.sortingOrder = Mathf.RoundToInt(transform.position.y * -10f + layer);
    }
}

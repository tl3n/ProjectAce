using UnityEngine;

public class LayerChanger : MonoBehaviour
{
    /// <summary>
    /// Number of the layer
    /// </summary>
    public float layer;
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if(GetComponent<SpriteRenderer>())
        {
            var sprite = GetComponent<SpriteRenderer>();
            if (transform.parent != null) sprite.sortingOrder = 
                Mathf.RoundToInt(transform.parent.localPosition.y * -10f + layer);
            else sprite.sortingOrder = Mathf.RoundToInt(transform.localPosition.y * -10f + layer);
        } 
    }
}

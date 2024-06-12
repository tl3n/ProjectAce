using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{    
    /// <summary>
    /// 
    /// </summary>
    private Slider slider;
    
    /// <summary>
    /// 
    /// </summary>
    public Health healthSript;
    /// <summary>
    /// 
    /// </summary>
    public Image fillImage;


    /// <summary>
    /// Awake is called when an enabled script instance is being loaded
    /// </summary>
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if(slider.value <= slider.minValue) fillImage.enabled = false;
        if (slider.value > slider.minValue && !fillImage.enabled) fillImage.enabled = true;
        
        int fillValue = healthSript.currentHealth;

        if(fillValue <= slider.maxValue / 3) fillImage.color = Color.red;
        else if(fillValue > slider.maxValue / 3) fillImage.color = Color.red; //TODO: It was white

        slider.value = fillValue;
    }
}

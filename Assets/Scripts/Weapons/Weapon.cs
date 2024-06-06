using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] protected string weaponName = "Weapon";
    
    public string WeaponName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] protected float interactionDistance = 2f;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] protected GameObject rotatePointGameObject;
    
    /// <summary>
    /// 
    /// </summary>
    protected ParticleSystem particleSystem;
    
    /// <summary>
    /// 
    /// </summary>
    protected Text interactionText;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] protected bool isEquipped;
    
    /// <summary>
    /// 
    /// </summary>
    private bool pickUpAllowed;

    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    protected void Start()
    {
        FindRotatePoint();
        if (!isEquipped) CreateInteractionText();
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    protected void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
            Debug.Log(gameObject.name + " was picked up");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void Initialize()
    {
        gameObject.name = weaponName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play(); 
    }

    /// <summary>
    /// 
    /// </summary>
    private void CreateInteractionText()
    {
        // Create a new Canvas
        GameObject canvasObject = new GameObject("InteractionCanvas");
        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.transform.SetParent(transform);
        canvas.transform.localPosition = Vector3.zero;
        canvas.transform.localScale = Vector3.one * 0.025f; // Reduced text scale

        // Set the Canvas to be in front of other objects
        canvas.sortingOrder = 1;

        // Create a new UI Text element for interaction text
        GameObject interactionTextObject = new GameObject("InteractionText");
        interactionTextObject.transform.SetParent(canvas.transform);
        interactionTextObject.transform.localPosition = Vector3.up * 25f;
        interactionTextObject.transform.localScale = Vector3.one; // Reduced text scale
        interactionText = interactionTextObject.AddComponent<Text>();
        interactionText.text = "'E' to pick up";
        interactionText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        interactionText.fontSize = 16;
        interactionText.color = Color.white;
        interactionText.alignment = TextAnchor.MiddleCenter;
        interactionText.gameObject.SetActive(false);

        // Adjust the size of the text
        RectTransform textRect = interactionText.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(200, 50);
    }

    /// <summary>
    /// 
    /// </summary>
    private void DestroyInteractionText()
    {
        if (interactionText != null)
        {
            // Destroy the canvas GameObject
            Destroy(interactionText.canvas.gameObject);

            // Remove the reference to avoid memory leaks
            interactionText = null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void FindRotatePoint()
    {
        rotatePointGameObject = GameObject.FindGameObjectWithTag("PlayerRP");
        if (rotatePointGameObject == null)
        {
            Debug.LogError("Player GameObject with tag 'PlayerRP' not found.");
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (interactionText != null) interactionText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (interactionText != null) interactionText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void PickUp()
    {
        DestroyInteractionText();
        
        Shooting rotatePointShooting = rotatePointGameObject.GetComponent<Shooting>();
        Weapon weapon = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/WeaponsEquipped/" + gameObject.name + "Equipped.prefab").GetComponent<Weapon>();
        rotatePointShooting.bullet = weapon;
        
        Destroy(gameObject);
    }
}
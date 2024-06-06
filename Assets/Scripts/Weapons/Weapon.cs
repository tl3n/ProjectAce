using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string weaponName = "Weapon";
    public string WeaponName { get; set; }

    protected ParticleSystem particleSystem;

    //public float distance;

    [SerializeField] protected float interactionDistance = 2f;
    protected Text interactionText;

    public bool isEquipped = false;
    [SerializeField] protected GameObject player;

    private bool pickUpAllowed;

    protected void Start()
    {
        //isEquipped = false;
        FindPlayer();
        if (!isEquipped) CreateInteractionText();
        
    }

    public virtual void Initialize()
    {
        gameObject.name = weaponName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play(); 
    }

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

    private void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("PlayerRP");
        if (player == null)
        {
            Debug.LogError("Player GameObject with tag 'PlayerRP' not found.");
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
            Debug.Log(gameObject.name + " was picked up");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (interactionText != null) interactionText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (interactionText != null) interactionText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

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

    private void PickUp()
    {
        DestroyInteractionText();
        Shooting rotatePoint = player.GetComponent<Shooting>();
        //rotatePoint.bullet = gameObject.GetComponent<Weapon>();

   

        Weapon weapon = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/" + gameObject.name + "Equipped.prefab").GetComponent<Weapon>();
        //weapon.isEquipped = true;
        rotatePoint.bullet = weapon;

        //isEquipped = true;
        Destroy(gameObject);
    }
}
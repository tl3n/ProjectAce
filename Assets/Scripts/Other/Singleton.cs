using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    /// <summary>
    /// 
    /// </summary>
    private static T instance;
    
    
    /// <summary>
    /// 
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null) SetupInstance();
            }
            
            return instance;
        }
    }
    
    /// <summary>
    /// Awake is called when an enabled script instance is being loaded
    /// </summary>
    public virtual void Awake()
    {
        RemoveDuplicates();
    }
    
    /// <summary>
    /// 
    /// </summary>
    private static void SetupInstance()
    {
        instance = (T)FindObjectOfType(typeof(T));
        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(T).Name;
            instance = gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void RemoveDuplicates()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}

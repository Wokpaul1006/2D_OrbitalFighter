using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    [SerializeField] bool isDestroyOnLoad;

    protected virtual void Awake()
    {
        if (!Instance)
        {
            Instance = GetComponent<T>();
            if (!isDestroyOnLoad)
            {
                DontDestroyOnLoad(Instance);
            }
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
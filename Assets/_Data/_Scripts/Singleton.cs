using UnityEngine;

public class Singleton<T> : MyMonoBehaviour where T : MyMonoBehaviour
{
    private static T _instance;
    private static readonly object _lock = new object();
    

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    Debug.LogError("Singleton instance has not been created yet!");
                }
                
                return _instance;
            }
        }
    }
    
    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (_instance == null)
        {
            _instance = this as T;
            if(transform.parent == null) DontDestroyOnLoad(gameObject);
            return;
        }
        
        if (_instance != this)
        {
            Debug.LogError($"[Singleton] already has instance of {typeof(T).Name} exist! " +
                           $"Existing: {_instance.gameObject.name}, Duplicate: {gameObject.name}");
        }
    }
    
}

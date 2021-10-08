using UnityEngine;


/// <summary>
/// Синглетон MonoBehaviour. Не автосоздаётся при обращении.
/// </summary>
/// <typeparam name="T">Тип синглетона</typeparam>
public abstract class ASingleton_MBLazy<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("ASingleton_MBLazy<" + typeof(T) + ">: Duplicate singleton!", gameObject);
        }
        Instance = this as T;
    }

    protected virtual void OnDestroy()
    {
        Instance = null;
    }
}


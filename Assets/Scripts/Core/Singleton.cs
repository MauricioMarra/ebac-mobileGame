using System.Collections;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T instance;

    virtual public void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<T>(); //instance = this as T; --> seems to be the same
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

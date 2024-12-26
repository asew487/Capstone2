using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindAnyObjectByType<T>();

                if(_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent(typeof(T)) as T;
                }
            }
            
            return _instance;
        }
    }
}

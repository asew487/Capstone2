using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    private List<GameObject> mapPool = new List<GameObject>();

    public GameObject GetMap(Map mapData)
    {
        foreach(GameObject map in mapPool)
        {
            if(map.CompareTag(mapData.id))
            {
                map.SetActive(true);
                map.transform.parent = null;
                return map;
            }
        }

        return Instantiate(mapData.map);
    }

    public void SetMap(GameObject map)
    {
        mapPool.Add(map);
        map.SetActive(false);
        map.transform.parent = gameObject.transform;
    }
}

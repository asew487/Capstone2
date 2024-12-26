using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MapRoadManager : MonoSingleton<MapRoadManager>
{
    
    public MapData mapData;

    [SerializeField]
    private Vector3 mapInterval;

    private Queue<Map> mapQueue = new Queue<Map>();
    public List<Map> shuffleList = new List<Map>();
    private Random rand = new Random();
    private GameObject previousMapObj;
    private GameObject currentMapObj;

    void Awake()
    {
        foreach(Map map in mapData.maps)
        {
            shuffleList.Add(map);
        }
    }

    void Start()
    {
        MapShuffle();
        int count = mapQueue.Count;

        for(int i = 0; i < count; i++)
        {
            MapRoad();
        }
    }

    public void MapRoad()
    {
        if(mapQueue.Count == 0)
        {
            MapShuffle();
        }

        GameObject mapObj = PoolManager.Instance.GetMap(mapQueue.Dequeue());

        if(currentMapObj != null)
        {
            previousMapObj = currentMapObj;
            currentMapObj = mapObj;
        }
        else
        {
            currentMapObj = mapObj;
        }

        if(previousMapObj != null)
        {
            foreach(Transform child in previousMapObj.transform)
            {
                if(child.CompareTag("End"))
                {
                    currentMapObj.transform.position = child.transform.position + mapInterval;
                    break;
                }
            }
        }
    }

    void MapShuffle()
    {
        for(int i = shuffleList.Count - 1; i > 0; i--)
        {
            int index = rand.Next(i + 1);
            var value = shuffleList[i];
            shuffleList[i] = shuffleList[index];
            shuffleList[index] = value;
        }

        foreach(Map map in shuffleList)
        {
            mapQueue.Enqueue(map);
        }
    }
}

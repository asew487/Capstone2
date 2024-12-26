using UnityEngine;

public class End : MonoBehaviour, IContact
{
    public void Contact()
    {
        MapRoadManager.Instance.MapRoad();
    }
}

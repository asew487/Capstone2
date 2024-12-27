using UnityEngine;

public class End : MonoBehaviour, IContact
{
    public bool isContact = false;

    void OnEnable()
    {
        isContact = false;
    }

    public void Contact()
    {
        if(!isContact)
        {
            isContact = true;
            MapRoadManager.Instance.MapRoad();
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class PlayerContact : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("dfdf");
        IContact contact = collider.GetComponent<IContact>();
        contact?.Contact();
    }

    void OnCollisionEnter(Collision collision)
    {

    }
}

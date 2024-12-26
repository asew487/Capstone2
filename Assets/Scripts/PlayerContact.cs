using Unity.VisualScripting;
using UnityEngine;

public class PlayerContact : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        IContact contact = collider.GetComponent<IContact>();
        contact?.Contact();
    }

    void OnCollisionEnter(Collision collision)
    {

    }
}

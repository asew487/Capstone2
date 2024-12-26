using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairRotate : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || PlayerInputSystem.Instance.Rotate < -0.4)
        {
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + -rotateSpeed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.RightArrow) || PlayerInputSystem.Instance.Rotate > 0.4)
        {
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + rotateSpeed * Time.deltaTime, 0);
        }

    }

    
}

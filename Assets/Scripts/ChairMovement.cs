using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 _moveDirection;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = PlayerInputSystem.Instance.Movement.x;
        float moveZ = PlayerInputSystem.Instance.Movement.y;

        _moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        transform.Translate(_moveDirection * speed * Time.deltaTime);
    }
}
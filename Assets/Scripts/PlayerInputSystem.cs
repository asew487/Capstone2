using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem : MonoSingleton<PlayerInputSystem>
{
    private PlayerControls _playerControls;

    public Vector2 Movement { get; private set; }
    public Vector2 Look { get; private set; }
    public float Rotate { get; private set; }

    void Awake()
    {
        _playerControls = new PlayerControls();
    }

    void OnEnable()
    {
        _playerControls.Enable();
    }

    void OnDisable()
    {
        _playerControls.Disable();
    }
    void Update()
    {
        Movement = _playerControls.Chair.Movement.ReadValue<Vector2>();
        Look =  _playerControls.Chair.Look.ReadValue<Vector2>();
        Rotate = _playerControls.Chair.Rotate.ReadValue<Vector2>().x;

        Debug.Log(Rotate);
    }
}

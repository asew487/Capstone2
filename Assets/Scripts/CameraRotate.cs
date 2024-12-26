using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float angleMax;
    [SerializeField]
    private float angleMin;

    private float _yawAngle = 0;
    private float _pitchAngle = 0;
    private bool _isLock = true;

    void Start()
    {
        _yawAngle = Camera.main.transform.rotation.x;
        _pitchAngle = Camera.main.transform.rotation.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Rotate();

        if(Input.GetKeyDown(KeyCode.L))
        {
            _isLock = !_isLock;
        }

        if(_isLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if(!_isLock)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Rotate()
    {
        float lookX = PlayerInputSystem.Instance.Look.x;
        float lookY = -PlayerInputSystem.Instance.Look.y;

        _yawAngle += lookX * rotateSpeed * Time.deltaTime;
        _pitchAngle += lookY * rotateSpeed * Time.deltaTime;

        Camera.main.transform.rotation = Quaternion.Euler(ClampAngle(_pitchAngle), _yawAngle, 0);
    }

    float ClampAngle(float angle)
    {
        return Mathf.Clamp(angle, angleMin, angleMax);
    }
}

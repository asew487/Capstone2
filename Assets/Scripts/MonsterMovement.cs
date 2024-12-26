using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float smoothTime;
    [SerializeField]
    private float rotateSpeed;

    public Queue<Vector3> _targetPosQueue = new Queue<Vector3>(); 
    public Vector3 _targetPos;
    public Vector3 _targetObjPos;

    private float _currentVelocity;

    void Start()
    {
        _targetObjPos = targetObj.transform.position;
        _targetPosQueue.Enqueue(_targetObjPos);
        _targetPos = targetObj.transform.position;
    }

    void Update()
    {
        float targetObjDistance = Vector3.Distance(_targetObjPos, targetObj.transform.position);

        if(targetObjDistance > 0)
        {
            _targetObjPos = targetObj.transform.position;
            _targetPosQueue.Enqueue(_targetObjPos);
        }

        float distance = Vector3.Distance(transform.position, _targetPos);

        if(distance == 0)
        {
            if(_targetPosQueue.Count != 0)
            {
                _targetPos = _targetPosQueue.Dequeue();
            }
            if(_targetPosQueue.Count == 0) 
            {
                _targetPos = transform.position;
            }
        }

        float smoothRotate = Mathf.SmoothDampAngle(transform.eulerAngles.y, Quaternion.Euler(_targetPos).eulerAngles.y, ref _currentVelocity, smoothTime, rotateSpeed);
        // transform.rotation = Quaternion.Euler(0, smoothRotate, 0);
        transform.LookAt(_targetPos);
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, Time.deltaTime * speed);
    }


}

using UnityEngine;

public class MapDeactivation : MonoBehaviour
{
    [SerializeField]
    private float deactivationDistance = 200f;
    private GameObject _player;
    private float _ditance;

    void Start()
    {
        _player = FindAnyObjectByType<PlayerInputSystem>().gameObject;
    }

    void OnEnable()
    {
        _ditance = 0;
    }

    void Update()
    {
        _ditance = Vector3.Distance(transform.position, _player.transform.position);

        if(_ditance >= deactivationDistance)
        {
            
            Debug.Log(_ditance);
            PoolManager.Instance.SetMap(gameObject);
        }
    }
}

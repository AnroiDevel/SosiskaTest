using UnityEngine;


public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _position;

    private void Start()
    {
        _position = transform.position - _player.position;
    }

    private void FixedUpdate()
    {
        transform.position = _player.position + _position;
    }
}

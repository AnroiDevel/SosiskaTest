using UnityEngine;


public class Sosiska : MonoBehaviour
{
    private const int YScalePower = 3;
    private const int XScalePower = 10;
    public float Power = 100;
    public TrajectoryRenderer Trajectory;
    private Rigidbody _rigit;
    private Vector3 _speed;
    private Camera mainCamera;
    private Transform _transform;

    private void Start()
    {
        mainCamera = Camera.main;
        _rigit = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        Trajectory.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (IsOnGround())
        {
            float enter;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            new Plane(-Vector3.forward, transform.position).Raycast(ray, out enter);
            Vector3 mouseInWorld = ray.GetPoint(enter);

            if (mouseInWorld.y > transform.position.y)
                Trajectory.gameObject.SetActive(false);

            else
            {
                mouseInWorld.y = (_transform.position.y + (_transform.position.y - mouseInWorld.y) * YScalePower);
                mouseInWorld.x = _transform.position.x + (_transform.position.x - mouseInWorld.x) * XScalePower;
            }

            _speed = (mouseInWorld - _transform.position) * Power;
            Trajectory.ShowTrajectory(_transform.position, _speed);
        }
        else
        {
            Trajectory.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonUp(0) && IsOnGround())
        {
            _rigit.AddForce(_speed, ForceMode.VelocityChange);
        }
    }

    private bool IsOnGround()
    {
        var isGround = false;
        RaycastHit hit;
        Ray ray = new Ray(_transform.position, -Vector3.up);
        Physics.Raycast(ray, out hit, 1f);

        if (hit.collider != null && hit.collider.tag == "Ground")
        {
            if (Input.GetMouseButton(0))
                Trajectory.gameObject.SetActive(true);
            else
                Trajectory.gameObject.SetActive(false);
            isGround = true;
        }
        return isGround;
    }
}

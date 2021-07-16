using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick _joystick;
    [SerializeField] float _speed;

    Vector3 _distance;

    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) && _joystick.Direction == Vector2.zero)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                _distance = hit.point;
            }
        }
    }

    void FixedUpdate()
    {
        if (_joystick.Direction != Vector2.zero)
        {
            transform.position += new Vector3(_joystick.Horizontal, 0, _joystick.Vertical) * _speed * Time.fixedDeltaTime;
            _distance = Vector3.zero;
        }
        else if(_distance != Vector3.zero && (_distance - transform.position).magnitude > .7f)
        {
            transform.position += (_distance - transform.position).normalized * _speed * Time.fixedDeltaTime;
        }

    }
}

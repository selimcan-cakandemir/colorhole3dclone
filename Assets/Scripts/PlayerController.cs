using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    public MeshCollider ground;

    private void FixedUpdate() {
        //Kontroller
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        //Delik sinirlari, bounds her zaman collider'dan iki kati daha buyuk oldugu icin 2'ye boluyoruz
        transform.position = Vector3.ClampMagnitude(transform.position, ground.bounds.size.x/2.3f);
    }
}

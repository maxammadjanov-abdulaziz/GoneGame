using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private bool _lookingRight;
    private Rigidbody2D _rigidbody;

    public float InputHorizontal { get; private set; }
    public IInputSystem InputSystem { get; private set; }

    private void Start()
    {
        InitializationInput();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (InputSystem == null) return;

        InputHorizontal = InputSystem.GetHorizontal();
        IInputSystem.EventDownSpace += Jumping;
        Move();
        Flipping();
    }

    private void Move()
    {
        SetVelocity(InputHorizontal * Acceleration(), _rigidbody.velocity.y);
    }

    private void Jumping()
    {
        if(Ground�hecker() == false) return;

        SetVelocity(_rigidbody.velocity.x, _jumpForce);
    }

    private void SetVelocity(float x, float y, float z = 0)
    {
        _rigidbody.velocity = new Vector3(x, y, z);
    }

    private float Acceleration()
    {
        return _speedMove * Time.deltaTime; 
    }

    private void Flipping()
    {
        if(InputHorizontal > 0 && !_lookingRight)          FlipScale();
        else if (InputHorizontal < 0 && _lookingRight) FlipScale();
    }

    private void FlipScale()
    {
        var scale = transform.localScale;
        transform.localScale = new Vector3(scale.x *= -1, scale.y);
        _lookingRight = !_lookingRight;
    }

    private bool Ground�hecker()
    {
        if (Physics2D.Raycast(transform.position, -Vector3.up, transform.localScale.y + 0.1f, _groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void InitializationInput()
    {
        if (TryGetComponent(out IInputSystem input)) InputSystem = input;
        else Debug.LogError("The object does not have a script responsible for managing");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, -Vector3.up * (transform.localScale.y + 0.1f));
    }


}

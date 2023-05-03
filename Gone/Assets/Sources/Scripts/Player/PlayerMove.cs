using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speedMove;

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
        Move();
        Flipping();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(InputHorizontal * Acceleration(), _rigidbody.velocity.y);
    }

    private float Jumpint()
    {
        return 0;
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

    private void InitializationInput()
    {
        if (TryGetComponent(out IInputSystem input)) InputSystem = input;
        else Debug.LogError("The object does not have a script responsible for managing");
    }


}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
//        Inheritance in C# ^ same as 'extends' in Java
{
    // lambda expression
    private bool isGrounded => Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckDistance, _groundLayer);

    // Unity-specific attribute; similar to '@' in Java (@Override)
    [Header("Movement Parameters")]
    [SerializeField] private float _moveSpeed = 5f;

    [Header("Jump Parameters")]
    [SerializeField] private float _jumpForce = 6f;

    [Header("Ground Check")]
    [SerializeField] private float _groundCheckDistance = .1f;
    [SerializeField] private LayerMask _groundLayer;

    // Component References
    private Rigidbody2D _rb;
    private Transform _groundCheck;
    
    void Awake()
    {
        // 'PlayerMovement' inherets 'GetComponent' from the 'MonoBehaviour' class 
        _rb = GetComponent<Rigidbody2D>();

        // 'MonoBehaviour' also contains a reference to the GameObject's transform
        _groundCheck = transform.GetChild(0); // Could also do 'transform.Find("{Ground Check Obj Name});'
    }

    void Update()
    {
        Move();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Move()
    {
        // Gets the A-D keyboard input, -1 if A, 1 if D, and 0 if neither (Vertical = W-S)
        float direction = Input.GetAxisRaw("Horizontal");
        float velocity = direction * _moveSpeed;

        // Assign velocity of rb to a new vector representing its velocity
        _rb.velocity = new Vector2(velocity, _rb.velocity.y);
    }

    private void Jump()
    {
        // _rb.AddForce(Vector2.up * _jumpForce) is also an option, but it can be a little inconsistent
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
    }
}

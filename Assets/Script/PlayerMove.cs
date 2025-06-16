using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private float speed = 1f;
    [SerializeField]private InputActionReference moveActionRef;
    Rigidbody2D rigidbody2D = null;
    [SerializeField] private float maxSpeed = 10;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rigidbody2D.linearVelocity.magnitude > maxSpeed)
        {
            if(rigidbody2D.linearVelocityX > maxSpeed)
            {
                rigidbody2D.linearVelocityX = maxSpeed;
            }
            if (rigidbody2D.linearVelocityY > maxSpeed)
            {
                rigidbody2D.linearVelocityY = maxSpeed;
            }
        }

    }

    private void FixedUpdate()
    {
        Vector2 moveInput = moveActionRef.action.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0);

        rigidbody2D.AddForce(movement * speed, ForceMode2D.Force);
    }

    private void OnEnable()
    {
        moveActionRef.action.Enable();
    }

    private void OnDisable()
    {
        moveActionRef.action.Disable();
    }
}

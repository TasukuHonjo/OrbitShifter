using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2D = null;
    Vector3 startPosition;
    Vector3 endPosition;
    public enum MoveVector
    {
        up, 
        down, 
        left, 
        right
    }

    public MoveVector moveVector = MoveVector.up;

    Vector2 direction = Vector2.up;

    float coolTime = 3;
    float defTime = 0;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition * -1;
        direction = endPosition - startPosition;

        defTime = coolTime;
        rigidbody2D.AddForce(direction.normalized * 3.0f, ForceMode2D.Impulse);
    }

    void Update()
    {
        coolTime -=Time.deltaTime;
        if(coolTime < 0)
        {
            coolTime = defTime;
            //rigidbody2D.linearVelocity = direction.normalized;
            rigidbody2D.AddForce(direction.normalized * 3.0f,ForceMode2D.Impulse);
            direction.x *= Random.Range(-1.5f, 1.5f);
            direction.y *= Random.Range(-1.5f, 1.5f);
        }
        
    }
}

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2D = null;
    Vector3 startPosition;
    Vector3 endPosition;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

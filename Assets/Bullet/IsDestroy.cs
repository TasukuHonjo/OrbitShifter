using UnityEngine;

public class IsDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime = 2;


    private void Start()
    {
        Destroy(this.gameObject,destroyTime);
    }
}

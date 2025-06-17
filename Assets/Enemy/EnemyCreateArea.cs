using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateArea : MonoBehaviour
{

    public Vector2 size = new Vector2(1, 1); // 四角形の幅と高さ
    public Color outSideGizmoColor = Color.green;

    public List<GameObject> enemyList = new List<GameObject>();

    [SerializeField] float coolTime = 1;
    float defTime = 0;

    private void Start()
    {
        defTime = coolTime;
    }


    private void Update()
    {
        coolTime -= Time.deltaTime;
        if (coolTime < 0)
        {
            coolTime = defTime;
            Vector3 spawnPos = Vector3.zero;
            switch (Random.Range(0, 4))
            {
                case 0:
                    //上に出現
                    spawnPos = new Vector3(Random.Range(size.x * -0.5f, size.x * 0.5f), size.y * 0.5f,0);
                    break;
                case 1:
                    //下に出現
                    spawnPos = new Vector3(Random.Range(size.x * -0.5f, size.x * 0.5f), size.y * -0.5f, 0);
                    break;
                case 2:
                    //左に出現
                    spawnPos = new Vector3(size.x * -0.5f,Random.Range(size.y * -0.5f, size.y * 0.5f), 0);
                    break;
                case 3:
                    //右に出現
                    spawnPos = new Vector3(size.x * 0.5f, Random.Range(size.y * -0.5f, size.y * 0.5f), 0);
                    break;
            }

            

            Instantiate(enemyList[0], spawnPos, Quaternion.identity);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = outSideGizmoColor;

        Vector3 pos = transform.position;
        float halfWidth = size.x / 2f;
        float halfHeight = size.y / 2f;

        Vector3 topLeft = new Vector3(pos.x - halfWidth, pos.y + halfHeight, pos.z);
        Vector3 topRight = new Vector3(pos.x + halfWidth, pos.y + halfHeight, pos.z);
        Vector3 bottomRight = new Vector3(pos.x + halfWidth, pos.y - halfHeight, pos.z);
        Vector3 bottomLeft = new Vector3(pos.x - halfWidth, pos.y - halfHeight, pos.z);

        // 四辺を描画
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}

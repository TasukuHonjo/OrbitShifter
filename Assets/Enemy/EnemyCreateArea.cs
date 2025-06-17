using UnityEngine;

public class EnemyCreateArea : MonoBehaviour
{

    public Vector2 size = new Vector2(1, 1); // éläpå`ÇÃïùÇ∆çÇÇ≥
    public Color outSideGizmoColor = Color.green;

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

        // élï”Çï`âÊ
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class OutLine : MonoBehaviour
{
    public Vector2 size = new Vector2(1, 1); // éläpå`ÇÃïùÇ∆çÇÇ≥
    public Color gizmoColor = Color.green;

    LineRenderer lineRenderer;
    EdgeCollider2D edgeCollider;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void Start()
    {

        Vector3 pos = transform.position;
        float halfWidth = size.x / 2f;
        float halfHeight = size.y / 2f;

        Vector3 topLeft = new Vector3(pos.x - halfWidth, pos.y + halfHeight, pos.z);
        Vector3 topRight = new Vector3(pos.x + halfWidth, pos.y + halfHeight, pos.z);
        Vector3 bottomRight = new Vector3(pos.x + halfWidth, pos.y - halfHeight, pos.z);
        Vector3 bottomLeft = new Vector3(pos.x - halfWidth, pos.y - halfHeight, pos.z);

        lineRenderer.positionCount = 4;
        lineRenderer.SetPosition(0, topLeft);
        lineRenderer.SetPosition(1, topRight);
        lineRenderer.SetPosition(2, bottomRight);
        lineRenderer.SetPosition(3, bottomLeft);

        List<Vector2> point = new List<Vector2>();
        point.Add(topLeft);
        point.Add(topRight);
        point.Add(bottomRight);
        point.Add(bottomLeft);
        point.Add(topLeft);

        edgeCollider.SetPoints(point);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}

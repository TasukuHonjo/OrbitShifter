using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D), typeof(SpringJoint2D), typeof(LineRenderer))]
public class GrapplingWire2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;
    private LineRenderer lineRenderer;

    private Camera mainCamera;
    private bool isConnected = false;

    Transform playerTra;
    Vector2 endPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();

        mainCamera = Camera.main;

        playerTra = transform;

        springJoint.enabled = false;
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        // 左クリックでワイヤー発射・接続
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f;
            endPos = mouseWorld;
            ConnectWire(mouseWorld);
        }

        // 右クリック押してる間、ワイヤー有効（引き寄せ）
        if (Input.GetMouseButton(1) && isConnected)
        {
            springJoint.enabled = true;
        }

        // 右クリック離したらワイヤー解除
        if (Input.GetMouseButtonUp(1) && isConnected)
        {
            DisconnectWire();
        }

        if(Vector2.Distance(transform.position, endPos)<0.5 && isConnected)
        {
            DisconnectWire();
        }

        // ワイヤー描画更新
        if (isConnected)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, springJoint.connectedAnchor);
        }
    }

    void ConnectWire(Vector3 target)
    {
        isConnected = true;

        // ワイヤー接続
        springJoint.connectedAnchor = target;
        springJoint.autoConfigureDistance = false;
        springJoint.distance = Vector2.Distance(transform.position, target);
        springJoint.distance = 0.1f;
        springJoint.dampingRatio = 0.95f;     // 揺れの減衰
        springJoint.frequency = 1.5f;        // 張力（ゴム感）
        springJoint.enabled = false;         // 最初はOFF、右クリックでON

        // LineRenderer更新
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, playerTra.position);
        lineRenderer.SetPosition(1, target);
    }

    void DisconnectWire()
    {
        isConnected = false;
        springJoint.enabled = false;
        lineRenderer.positionCount = 0;
    }
}
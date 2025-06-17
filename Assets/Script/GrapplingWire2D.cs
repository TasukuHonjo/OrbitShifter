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
        // ���N���b�N�Ń��C���[���ˁE�ڑ�
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f;
            endPos = mouseWorld;
            ConnectWire(mouseWorld);
        }

        // �E�N���b�N�����Ă�ԁA���C���[�L���i�����񂹁j
        if (Input.GetMouseButton(1) && isConnected)
        {
            springJoint.enabled = true;
        }

        // �E�N���b�N�������烏�C���[����
        if (Input.GetMouseButtonUp(1) && isConnected)
        {
            DisconnectWire();
        }

        if(Vector2.Distance(transform.position, endPos)<0.5 && isConnected)
        {
            DisconnectWire();
        }

        // ���C���[�`��X�V
        if (isConnected)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, springJoint.connectedAnchor);
        }
    }

    void ConnectWire(Vector3 target)
    {
        isConnected = true;

        // ���C���[�ڑ�
        springJoint.connectedAnchor = target;
        springJoint.autoConfigureDistance = false;
        springJoint.distance = Vector2.Distance(transform.position, target);
        springJoint.distance = 0.1f;
        springJoint.dampingRatio = 0.95f;     // �h��̌���
        springJoint.frequency = 1.5f;        // ���́i�S�����j
        springJoint.enabled = false;         // �ŏ���OFF�A�E�N���b�N��ON

        // LineRenderer�X�V
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
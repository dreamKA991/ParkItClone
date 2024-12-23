using UnityEngine.EventSystems;
using UnityEngine;

public class CameraFlying : MonoBehaviour, IDragHandler
{
    [SerializeField] public Transform target;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float minYPosition = 1f;
    [SerializeField] private float maxVerticalAngle = -30f;
    [SerializeField] private float minVerticalAngle = -100f;
    [SerializeField] private CarController carController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 initialOffset;
    private Vector3 savedInitialOffset;
    private float currentVerticalAngle = 0f;

    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        carController = target.GetComponent<CarController>();
        if (mainCamera.transform != null)
        {
            initialOffset = mainCamera.transform.position - target.position;
            savedInitialOffset = initialOffset;
        }
    }

    public void SetNewTarget(Transform _newTarget)
    {
        if(_newTarget == null) return;
        target = _newTarget;
        carController = target.gameObject.GetComponent<CarController>();
        mainCamera.transform.parent = target;
        mainCamera.transform.position = carController.cameraPlace.position;
        mainCamera.transform.LookAt(target);

    }

    void Update()
    {
        if (mainCamera != null && target != null)
        {
            initialOffset = mainCamera.transform.position - target.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (mainCamera == null || target == null) return;

        float horizontal = eventData.delta.x * rotationSpeed * Time.deltaTime;
        float vertical = -eventData.delta.y * rotationSpeed * Time.deltaTime;

        float newVerticalAngle = Mathf.Clamp(currentVerticalAngle + vertical, minVerticalAngle, maxVerticalAngle);
        float angleDifference = newVerticalAngle - currentVerticalAngle;
        currentVerticalAngle = newVerticalAngle;

        Quaternion horizontalRotation = Quaternion.AngleAxis(horizontal, Vector3.up);
        Quaternion verticalRotation = Quaternion.AngleAxis(angleDifference, mainCamera.transform.right);

        Vector3 newOffset = horizontalRotation * verticalRotation * initialOffset;

        if (target.position.y + newOffset.y >= minYPosition)
        {
            initialOffset = newOffset;
            mainCamera.transform.position = target.position + initialOffset;
            mainCamera.transform.LookAt(target);
        }
    }
}

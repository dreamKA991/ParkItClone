using UnityEngine;
using UnityEngine.EventSystems;

public class CameraFlying : MonoBehaviour, IDragHandler
{
    [SerializeField] public Transform target;                  
    [SerializeField] private float rotationSpeed = 15f;           
    [SerializeField] private float minYPosition = 1f;             
    [SerializeField] private float maxVerticalAngle = -30f;       
    [SerializeField] private float minVerticalAngle = -100f;      
    [SerializeField] private CarController carController;
    private Camera mainCamera;
    [SerializeField] private Vector3 initialOffset;
    private Vector3 savedInitialOffset;
    private float currentVerticalAngle = 0f;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Главная камера не найдена!");
            return;
        }
        carController = target.GetComponent<CarController>();
        initialOffset = mainCamera.transform.position - target.position;
        savedInitialOffset = initialOffset;
    }

    void Update()
    {
        initialOffset = mainCamera.transform.position - target.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
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
    public void SetNewTarget(Transform _newTarget)
    {
        target = _newTarget;
        carController = target.GetComponent<CarController>();
        mainCamera.transform.parent = _newTarget.transform;
        mainCamera.transform.position = carController.cameraPlace.position;
        mainCamera.transform.LookAt(target);
    }
}

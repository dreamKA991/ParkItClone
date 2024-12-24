using UnityEngine;
using DG.Tweening;

public class ForkliftController : MonoBehaviour, IRestartable
{
    [SerializeField] private float moveDistance = 1f;
    [SerializeField] private float moveDuration = 1f;
    [SerializeField] private int position = 1;
    private int maxPosition = 3;
    private bool isMoving = false;
    [SerializeField] private bool isDebuging;
    private Quaternion savedRotationBeforeForkUp;
    [SerializeField] private float maxAllowedAngleDifference = 15f;
    [SerializeField] private BlockTrigger blockTrigger;

    // Joint system
    private FixedJoint joint;
    [SerializeField] private GameObject triggerGameObject;
    [SerializeField] private float breakForce = 1000000f;

    // Restart
    private Vector3 initialPosition;

    private void Awake()
    {
        joint = GetComponent<FixedJoint>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) MoveForkUp();
        if (Input.GetKeyDown(KeyCode.Q)) MoveForkDown();
    }

    private void MoveFork(float _direction, bool _isHaveTriggerObject = false)
    {
        isMoving = true;

        transform.DOMoveY(transform.position.y + _direction, moveDuration)
            .SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                isMoving = false;

                if (position == 1)
                {
                    Destroy(joint);
                }
                else if (position == 2 && _isHaveTriggerObject)
                {
                    if (IsObjectCorrectlyPlaced())
                    {
                        SetNewJoint(triggerGameObject);
                    }
                    else if (isDebuging)
                    {
                        Debug.LogWarning("Object is not correctly placed on the forklift!");
                    }
                }
            });
    }

    public void MoveForkUp()
    {
        if (isMoving) return;
        bool isHaveTriggerObject = triggerGameObject != null;

        if (position < maxPosition)
        {
            position++;
            if (isHaveTriggerObject)
            {
                savedRotationBeforeForkUp = triggerGameObject.transform.rotation;
            }
            MoveFork(moveDistance, isHaveTriggerObject);
        }
    }

    public void MoveForkDown()
    {
        if (isMoving || blockTrigger.isBlocked) return;

        if (position > 1)
        {
            position--;
            MoveFork(-moveDistance);
        }
    }

    private bool IsObjectCorrectlyPlaced()
    {
        if (triggerGameObject == null) return false;

        float angleDifference = Quaternion.Angle(savedRotationBeforeForkUp, triggerGameObject.transform.rotation);
        if (angleDifference > maxAllowedAngleDifference)
        {
            if (isDebuging) Debug.Log("Rotation check failed: angle difference = " + angleDifference);
            return false;
        }

        if (isDebuging) Debug.Log("Object is correctly placed.");
        return true;
    }

    private void SetNewJoint(GameObject _obj)
    {
        if (joint == null) joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = _obj.GetComponent<Rigidbody>();
        joint.breakForce = breakForce;
        joint.breakTorque = breakForce;
        joint.enableCollision = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDebuging) Debug.Log($"OnTriggerEnter collider other is: {other.name}");
        ILiftable iLiftable = other.GetComponent<ILiftable>();

        if (iLiftable != null)
        {
            if (other.transform.parent != null)
            {
                triggerGameObject = other.transform.parent.gameObject;
            }
            else if (isDebuging)
            {
                Debug.Log($"Object {other.name} with ILiftable has no parent!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.gameObject == triggerGameObject)
        {
            triggerGameObject = null;
        }
    }

    public void Restart()
    {
        if (joint != null) Destroy(joint);
        transform.position = initialPosition;
        position = 1;
        isMoving = false;
        triggerGameObject = null;
        if (isDebuging) Debug.Log("Forklift reset to initial position.");
    }
}

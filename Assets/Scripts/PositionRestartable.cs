using System.Collections.Generic;
using UnityEngine;

public class Restartable : MonoBehaviour, IRestartable
{
    private List<ObjectInfo> objectInfos = new List<ObjectInfo>();
    private Rigidbody rb;
    private struct ObjectInfo
    {
        public GameObject gameObject;
        public Vector3 initialPosition;
        public Quaternion initialRotation;

        public ObjectInfo(GameObject obj, Vector3 pos, Quaternion rot)
        {
            gameObject = obj;
            initialPosition = pos;
            initialRotation = rot;
        }
    }

    private void Start()
    {
        foreach (Transform child in transform)
        {
            objectInfos.Add(new ObjectInfo(
                child.gameObject,
                child.position,
                child.rotation
            ));
        }
    }
    public void Restart()
    {
        foreach (var info in objectInfos)
        {
            if (info.gameObject != null)
            {
                info.gameObject.transform.position = info.initialPosition;
                info.gameObject.transform.rotation = info.initialRotation;
                rb = info.gameObject.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                } 
            }
            
        }
    }
}

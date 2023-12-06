using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public Vector3 lastPos;
    public Quaternion lastRot;

    public UnityEvent<GameObject> resetPortal;
   
    

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Portal"))
        {
            resetPortal.Invoke(gameObject);
        }
    }
}

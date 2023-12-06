using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 lastPos;
    public Quaternion lastRot;
   
    public void ResetPortal()
    {
        transform.position = lastPos;
        transform.rotation = lastRot;

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Portal"))
        {
            ResetPortal();
        }
    }
}

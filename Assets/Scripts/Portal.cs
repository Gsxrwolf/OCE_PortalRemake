using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public Vector3 lastPos;
    public Quaternion lastRot;

    public Collider leftCollider;
    public Collider topCollider;
    public Collider rightCollider;
    Collider wallCollider;


    public UnityEvent<GameObject> resetPortal;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Vector3.zero, transform.forward, out hit, 2f))
            {
                wallCollider = hit.collider;
                wallCollider.enabled = false;
            }


            leftCollider.enabled = true;
            topCollider.enabled = true;
            rightCollider.enabled = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            wallCollider.enabled = true;

            leftCollider.enabled = false;
            topCollider.enabled = false;
            rightCollider.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Portal"))
        {
            resetPortal.Invoke(gameObject);
        }
    }
}

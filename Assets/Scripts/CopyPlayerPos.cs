using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPlayerPos : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject portalRotation;
    [SerializeField] GameObject portalOutput;


    Vector3 vecPlayerToPortal;


    void Update()
    {

        vecPlayerToPortal = portalOutput.transform.position - player.transform.position;

        Debug.Log(vecPlayerToPortal + "");
        vecPlayerToPortal.Scale(portalRotation.transform.forward);
        transform.localPosition = vecPlayerToPortal;
    }
}

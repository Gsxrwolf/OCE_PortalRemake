using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPlayerPos : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject portalRotation;
    [SerializeField] GameObject portalOutput;

    Vector3 camRotation;


    Vector3 vecPlayerToPortal;

    Vector3 playerCamNormal;
    Vector3 outputPortalNormal;
    Vector3 rotationPortalNormal;

    void Update()
    {
        playerCamNormal = playerCam.transform.forward;
        outputPortalNormal = portalOutput.transform.forward;
        rotationPortalNormal = portalRotation.transform.forward;


        transform.localRotation = Quaternion.LookRotation(-playerCamNormal,-Vector3.Cross(outputPortalNormal,-playerCamNormal));
        






        //vecPlayerToPortal = portalOutput.transform.position - player.transform.position;
        //vecPlayerToPortal.Scale(portalRotation.transform.forward);
        //transform.localPosition = vecPlayerToPortal;
        //
        //
        //Debug.Log(player.transform.rotation.eulerAngles + "");
        //camRotation = portalRotation.transform.rotation.eulerAngles + player.transform.rotation.eulerAngles;
        //transform.rotation = Quaternion.Euler(camRotation);
    }
}

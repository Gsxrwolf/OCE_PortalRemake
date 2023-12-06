using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{

    [SerializeField] GameObject player;

    [SerializeField] GameObject portalO;
    [SerializeField] GameObject portalB;

    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;

    GameObject myCurPortal;
    GameObject pCurPortal;

    Vector3 vecPlayerToPortal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, portalO.transform.position) < Vector3.Distance(player.transform.position, portalB.transform.position))
        {
            pCurPortal = portalO;
            myCurPortal = portalB;
        }
        else
        {
            pCurPortal = portalB;
            myCurPortal = portalO;
        }

        vecPlayerToPortal = pCurPortal.transform.position - player.transform.position;
        vecPlayerToPortal.Scale(myCurPortal.transform.forward);
        cam1.transform.position = myCurPortal.transform.position + vecPlayerToPortal;
        Vector3 rotation = new Vector3(player.transform.rotation.eulerAngles.x, myCurPortal.transform.rotation.y + 180 + player.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z);
        cam1.transform.rotation = Quaternion.Euler(rotation);
    }
}

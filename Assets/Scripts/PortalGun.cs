using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PortalGun : MonoBehaviour
{
    [SerializeField] private LayerMask m_wallLayer;
    [SerializeField] private LayerMask m_portalLayer;
    [SerializeField] private GameObject m_bluePortal;
    [SerializeField] private GameObject m_orangePortal;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseClick(InputAction.CallbackContext _context)
    {
        if (!_context.performed)
        {
            return;
        }

        if (_context.control.name == "leftButton")
        {
            Shoot(m_bluePortal);

        }
        else if (_context.control.name == "rightButton")
        {
            Shoot(m_orangePortal);
        }
    }

    void Shoot(GameObject _gO)
    {
        RaycastHit hit;

        _gO.GetComponent<Portal>().lastPos = _gO.transform.position;
        _gO.GetComponent<Portal>().lastRot = _gO.transform.rotation;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10000f, m_wallLayer))
        {
            _gO.transform.SetPositionAndRotation(hit.point, Quaternion.LookRotation(-hit.normal));
            _gO.transform.position = _gO.transform.position - _gO.transform.forward * 0.01F;

            if (!CheckValidPosition(_gO))
            {
                _gO.GetComponent<Portal>().ResetPortal();
            }
        }

    }

    bool CheckValidPosition(GameObject _gO)
    {
        Vector3 topRight = new Vector3(_gO.transform.position.x + _gO.transform.localScale.x / 2f, _gO.transform.position.y + _gO.transform.localScale.y / 2f);
        Vector3 topLeft = new Vector3(_gO.transform.position.x - _gO.transform.localScale.x / 2f, _gO.transform.position.y + _gO.transform.localScale.y / 2f);
        Vector3 bottomRight = new Vector3(_gO.transform.position.x + _gO.transform.localScale.x / 2f, _gO.transform.position.y - _gO.transform.localScale.y / 2f);
        Vector3 bottomLeft = new Vector3(_gO.transform.position.x - _gO.transform.localScale.x / 2f, _gO.transform.position.y - _gO.transform.localScale.y / 2f);


        if (!Physics.Raycast(topRight, -_gO.transform.forward, 5f, m_wallLayer))
        {
            return false;
        }

        if (!Physics.Raycast(topLeft, -_gO.transform.forward, 5f, m_wallLayer))
        {
            return false;
        }

        if (!Physics.Raycast(bottomRight, -_gO.transform.forward, 5f, m_wallLayer))
        {
            return false;
        }

        if (!Physics.Raycast(bottomLeft, -_gO.transform.forward, 5f, m_wallLayer))
        {
            return false;
        }



        return true;
    }

}

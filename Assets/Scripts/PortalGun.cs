using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PortalGun : MonoBehaviour
{
    [SerializeField] private LayerMask m_wallLayer;
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
        GameObject portal;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10000f, m_wallLayer))
        {
            portal = Instantiate(_gO, hit.point, Quaternion.LookRotation(-hit.normal));
            portal.transform.position = portal.transform.position - portal.transform.forward * 0.01F;
        }
    }
}

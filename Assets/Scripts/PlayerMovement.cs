using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody m_rB;
    [SerializeField] private float m_moveSpeed = 1.0f;
    [SerializeField] private Vector2 m_rotation;

    // Start is called before the first frame update
    void Start()
    {
        m_rB = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, m_rotation.x, 0f);
    }

    public void Movement(InputAction.CallbackContext _context)
    {

    }

    public void PlayerRotation(InputAction.CallbackContext _context)
    {
        m_rotation += _context.ReadValue<Vector2>();
    }
}

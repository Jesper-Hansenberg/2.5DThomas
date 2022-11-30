using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpMultiplier = 10f;
    private Vector3 _movement = Vector3.zero;
    private Rigidbody _rb;
    private bool _grounded = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rb.AddForce(Vector3.up * JumpMultiplier, ForceMode.Impulse);
            _grounded = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector3.right);
        }
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Ground")
        {
            _grounded = true;
        }
    }
}

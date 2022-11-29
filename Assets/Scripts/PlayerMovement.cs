using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpMultiplier = 10f;
    private Vector3 _movement = Vector3.zero;
    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            _rb.AddForce(Vector3.left);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            _rb.AddForce(Vector3.up*JumpMultiplier, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.D)){
            _rb.AddForce(Vector3.right);
        }
    }
}

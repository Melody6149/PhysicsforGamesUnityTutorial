using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovementBehavior : MonoBehaviour
{
    private CharacterController _controller = null;
    private Animator _animator = null;

    public float speed = 80.0f;
    public float pushPower = 2.0f;
    public  bool tankControls = true;
    public float turnRate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (tankControls)
        {
            _controller.SimpleMove(transform.forward * movement.z);
            transform.Rotate(transform.up, movement.x * turnRate);
        }
        else
        {
            _controller.SimpleMove(movement);
            if (movement.magnitude > 0)
            {
                transform.forward = movement.normalized;
            }
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody otherRb = hit.rigidbody;
        if (otherRb == null || otherRb.isKinematic)
        {
            return;
        }
        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }

        Vector3 pushDirection = new Vector3(hit.moveDirection.x , 0 , hit.moveDirection.z);
        //otherRb.velocity = pushDirection * pushPower;
        otherRb.AddForceAtPosition(pushDirection * pushPower, hit.point); 
    }
}

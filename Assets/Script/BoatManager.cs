using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{

	private Vector3 velocity;
	private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

        private void FixedUpdate()
    {
        PerformMovement();
    }


    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    
    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }
}

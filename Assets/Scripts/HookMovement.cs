using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    [Header("Add these in Inspector")]
    public GameObject hook;
    //public BoxCollider movementSpace;
    public float forceModifier = 0.5f;
    public float forceTouchPointOffset = 0f;
    public float centerOfMassOffset = 0f;

    public float hookVelocityBeforeRealignment = 0.1f;
    public float hookRealignmentSpeed = 1f;

    //[Header("Assign these dynamically")]
    private Rigidbody hookRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        hookRigidbody = hook.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hookRigidbody.centerOfMass = new Vector3(transform.position.x, centerOfMassOffset, transform.position.z);

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        float forceX = inputX * forceModifier;
        float forceY = inputY * forceModifier;

        Vector3 forcePosition = hook.transform.position;
        forcePosition.y -= forceTouchPointOffset;

        Vector3 force = new Vector3(forceX,0,forceY);

        hookRigidbody.AddForceAtPosition(force,forcePosition);


        if(hookRigidbody.velocity.magnitude <= hookVelocityBeforeRealignment)
        {
            returnToUprightPosition();
        }


    }

    private void returnToUprightPosition()
    {
        hookRigidbody.angularVelocity = Vector3.zero;

        Quaternion currentRotation = hookRigidbody.rotation;
        Quaternion targetRotation = Quaternion.identity;

        hookRigidbody.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * hookRealignmentSpeed);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float rotationSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rotatingBody = GetComponent<Rigidbody>();

        Vector3 torque = Vector3.one * rotationSpeed;
        rotatingBody.AddTorque(torque);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

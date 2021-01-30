using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public bool descending = false;
    public float descentSpeed = 0.01f;
    

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (descending)
        {
            newPosition.y -= descentSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

    }

}

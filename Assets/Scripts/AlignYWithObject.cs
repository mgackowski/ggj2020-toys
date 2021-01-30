using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignYWithObject : MonoBehaviour
{
    public GameObject target;
    public float yOffset = 0f;


    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = target.transform.position.y + yOffset;
        transform.position = newPosition;
    }
}

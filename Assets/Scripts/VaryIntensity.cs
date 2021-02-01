using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaryIntensity : MonoBehaviour
{
    public Camera playerCamera;
    public Light thisLight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = playerCamera.transform.position;
        Vector3 lightPosition = transform.position;

        float diff = (cameraPosition - lightPosition).magnitude;

        if (diff > 150) { thisLight.intensity = 0f; }
        else if (diff > 100) { thisLight.intensity = 0.5f; }
        else if (diff > 70) { thisLight.intensity = 1f; }
        else if (diff > 50) { thisLight.intensity = 1.5f; }
        else { thisLight.intensity = 2f; }

    }
}

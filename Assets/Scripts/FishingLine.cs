using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 lineStart;
    private Vector3 lineEnd;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        lineStart = GameObject.FindGameObjectWithTag("LineOrigin").transform.position;
        lineEnd = GameObject.FindGameObjectWithTag("HookEye").transform.position;

        lineRenderer.SetPositions(new Vector3[] { lineStart, lineEnd });

    }
}

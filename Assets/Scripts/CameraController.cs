using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Animator anim;
    public GameObject followTarget;
    public CameraState state = CameraState.StaticTitle;
    public float adjustSpeed = 0.1f;
    public float adjustmentDelay = 2f;
    public float targetOffset = 4f;

    public Vector3 cameraTarget;

    public enum CameraState
    {
        StaticTitle,
        Animating,
        Adjusting,
        FollowingHook
    }

    public void Start()
    {
        cameraTarget.y = followTarget.transform.position.y + targetOffset;
    }

    public void Update()
    {

        cameraTarget.y = followTarget.transform.position.y + targetOffset;

        if (state == CameraState.Animating && !anim.GetCurrentAnimatorStateInfo(0).IsName("MoveCam"))
        {
            // more robust state that doesn't depend on static anim length
        }

        if (state == CameraState.FollowingHook)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = cameraTarget.y;
            transform.position = newPosition;
        }

    }

    public void StartGame()
    {
        state = CameraState.Animating;
        anim.Play("MoveCam");
        Invoke("StartCameraAdjustment", adjustmentDelay);
    }

    public void StartCameraAdjustment()
    {
        state = CameraState.Adjusting;
        anim.enabled = false;
        StartCoroutine("AdjustCamera");
    }

    public IEnumerator AdjustCamera()
    {
        while ((cameraTarget - transform.position).magnitude >= 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, cameraTarget, adjustSpeed * Time.deltaTime);
            yield return null;
        }
        state = CameraState.FollowingHook;  
    }


}
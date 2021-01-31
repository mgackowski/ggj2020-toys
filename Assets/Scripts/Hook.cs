using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public bool descending = false;
    public float descentSpeed = 0.01f;
    public float slowDownRate = 1f;
    public float liftSpeedMod = 0.5f;
    public AudioHandler audioHandler;

    public float actualDescentSpeed;

    private Rigidbody hookRigidbody;
    private AudioSource audioSource;
    private bool hitRockOnce = false;


    private void Start()
    {
        actualDescentSpeed = descentSpeed;
        hookRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if(Input.GetButton("Fire1"))
        {
            newPosition.y += actualDescentSpeed * Time.deltaTime * liftSpeedMod;
            transform.position = newPosition;
        }
        else if (descending)
        {
            newPosition.y -= actualDescentSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Toy")
        {
            Toy toy = collision.gameObject.GetComponent<Toy>();
            int memory = toy.collect();

            //StartCoroutine("SlowDown");
            //play memory

        }

        if (collision.gameObject.tag == "Rock")
        {
            descending = false;
            if(!audioSource.isPlaying) audioSource.Play();

            if (!hitRockOnce)
            {
                UIHandler.FadeOutBottomText("Press Ctrl to reel in",5f);
                hitRockOnce = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TriggerEnd")
        {
            descending = false;
            StartCoroutine("SlowDown");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            descending = true;
        }
    }

    private IEnumerator SlowDown()
    {
        while (actualDescentSpeed > 0.01f)
        {
            actualDescentSpeed = Mathf.Lerp(actualDescentSpeed, 0f, slowDownRate * Time.deltaTime);
            yield return null;
        }
        descending = false;

    }

    private IEnumerator Descend()
    {
        while (actualDescentSpeed < descentSpeed)
        {
            actualDescentSpeed = Mathf.Lerp(actualDescentSpeed, descentSpeed, slowDownRate * Time.deltaTime);
            yield return null;
        }
        descending = true;

    }

}

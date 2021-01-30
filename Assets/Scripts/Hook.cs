using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public bool descending = false;
    public float descentSpeed = 0.01f;
    public float slowDownRate = 1f;

    public float actualDescentSpeed;


    private void Start()
    {
        actualDescentSpeed = descentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (descending)
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

            StartCoroutine("SlowDown");

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {

            StartCoroutine("Descend");

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSounds : MonoBehaviour
{
    public AudioHandler audioHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TriggerUnderwater")
        {
            Debug.Log("Underwater");
            audioHandler.playSound("UnderwaterLoop", AudioHandler.SoundSource.Environment, true, false);
            audioHandler.playSound("Reel2Loop", AudioHandler.SoundSource.Reel, true, false);
        }
        if (other.gameObject.tag == "TriggerHospitalClean")
        {
            audioHandler.playSound("Hos1Clean", AudioHandler.SoundSource.Environment, true, false);
        }
        if (other.gameObject.tag == "TriggerHospitalDirty")
        {
            audioHandler.playSound("Hos1Dirty", AudioHandler.SoundSource.Environment, true, false);
        }
        if (other.gameObject.tag == "TriggerSilence")
        {
            // pause all
        }
    }

    }

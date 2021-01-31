using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toy : MonoBehaviour
{
    public int memoryNumber;
    public Image thisMemory;
    public AudioHandler audioHandler;
    public string memorySoundName;


    public int collect()
    {
        // change material
        // affect point light
        // fade out material

        Destroy(gameObject);

        return memoryNumber;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hook"))
        {
            thisMemory.enabled = true;
            Time.timeScale = 0f;
            audioHandler.playSound(memorySoundName, AudioHandler.SoundSource.Memory, true, false);

        }
    }


}

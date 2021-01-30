using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{
    public int memoryNumber;


    public int collect()
    {
        // change material
        // affect point light
        // fade out material

        Destroy(gameObject);

        return memoryNumber;
    }


}

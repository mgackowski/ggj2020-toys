﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public CameraController cameraController;
    public Hook hook;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        cameraController.StartGame();
        hook.GetComponent<Hook>().descending = true;

    }
}

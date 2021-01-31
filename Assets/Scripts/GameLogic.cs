using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public CameraController cameraController;
    public Hook hook;
    public GameState state = GameState.TitleScreen;

    public enum GameState
    {
        TitleScreen,
        Playing,
        Memory,
        Ending
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.TitleScreen && Input.anyKeyDown)
        {
            StartGame();
        }
        
    }

    public void StartGame()
    {
        cameraController.StartGame();
        hook.GetComponent<Hook>().descending = true;
        UIHandler.ChangeBottomText("");
        state = GameState.Playing;

    }
}

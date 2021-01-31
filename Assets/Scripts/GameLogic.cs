using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public CameraController cameraController;
    public AudioHandler audioHandler;
    public Hook hook;
    public GameState state = GameState.TitleScreen;
    public Image whiteFade;

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
        audioHandler.playSound("AtSeaLevel1", AudioHandler.SoundSource.Environment, true, false);
        audioHandler.playSound("Sea Song", AudioHandler.SoundSource.Music, true, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.TitleScreen && Input.anyKeyDown)
        {
            StartGame();
        }

        if (Time.timeScale == 0f && Input.GetButtonDown("Fire1"))
        {
            Time.timeScale = 1f;
            GameObject[] memories = GameObject.FindGameObjectsWithTag("MemoryImage");
            foreach (GameObject gameObject in memories)
            {
                gameObject.GetComponent<Image>().enabled = false;
            }
            audioHandler.unpauseSounds();

        } 

        if(state == GameState.Ending)
        {
            UIHandler.fadeIn(whiteFade);
        }

        
    }

    public void StartGame()
    {
        cameraController.StartGame();
        hook.GetComponent<Hook>().descending = true;
        UIHandler.ChangeBottomText("");
        UIHandler.disableLogo();
        state = GameState.Playing;

        audioHandler.playSound("Reel2Water",AudioHandler.SoundSource.Reel, true, false);
        //audioHandler.playSound("Reel2Loop", AudioHandler.SoundSource.Reel, true, true);

    }
}

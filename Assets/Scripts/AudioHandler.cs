using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource music;
    public AudioSource environment;
    public AudioSource memories;
    public AudioSource reel;

    public Dictionary<SoundSource, AudioSource> sourceList;
    public List<AudioClip> clips;

    public enum Sound
    {
        SeaSong,
        SeaLevelBG,
        HospitalCleanBG,
        HospitalDirtyBG,
        UnderwaterBG,
        SoulRising,
        MemCakeTopper,
        MemFootball,
        MemNewton,
        MemRobot,
        MemTeddy,
        ReelAboveWater,
        ReelUnderWater,
        ReelLoop
    }

    public enum SoundSource
    {
        Music,
        Environment,
        Memory,
        Reel
    }

    void Start()
    {
        sourceList = new Dictionary<SoundSource, AudioSource>() {
            { SoundSource.Music, music },
            { SoundSource.Environment, environment },
            { SoundSource.Memory, memories },
            { SoundSource.Reel, reel }
        };
    }

    public void playSound(string clipName, SoundSource soundSource, bool interrupt, bool delayed)
    {
        if (!interrupt && sourceList[soundSource].isPlaying) return;

        AudioClip clipToPlay = null;
        foreach (AudioClip clip in clips)
        {
            if (clip.name == clipName) clipToPlay = clip;
        }
        if (clipToPlay == null) return;

        float delay = 0f;
        if (delayed) delay = sourceList[soundSource].clip.length;

        sourceList[soundSource].clip = clipToPlay;
        sourceList[soundSource].PlayDelayed(delay);

        if(soundSource == SoundSource.Memory)
        {
            sourceList[SoundSource.Environment].Pause();
            sourceList[SoundSource.Music].Pause();
            sourceList[SoundSource.Reel].Pause();
        }

    }

    public void unpauseSounds()
    {
        sourceList[SoundSource.Environment].UnPause();
        sourceList[SoundSource.Music].UnPause();
        sourceList[SoundSource.Reel].UnPause();
    }


}

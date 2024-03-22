using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("# BGM")]
    public AudioSource[] bgmPlayers;
    AudioClip[] bgmClips;
    [SerializeField] float bgmVolume;
    [SerializeField] int bgmChannels;
    AudioHighPassFilter bgmEffect;


    [Header("# SFX")]
    AudioClip[] sfxClips;
    public AudioSource[] sfxPlayers;
    [SerializeField] float sfxVolume;
    [SerializeField] int channels;

    [Header("# Sound Data")]
    public SoundData sfxData;
    public SoundData bgmData;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init();
        }
        else
            Destroy(gameObject);
    }



    void Init()
    {
        //Bgm Player Initialize
        GameObject bgmObject = new GameObject("BgmPlayers");
        bgmObject.transform.parent = transform;
        bgmPlayers = new AudioSource[bgmChannels];
        for (int index = 0; index < bgmChannels; index++)
        {
            bgmPlayers[index] = bgmObject.AddComponent<AudioSource>();
            bgmPlayers[index].playOnAwake = false;
            bgmPlayers[index].loop = true;
            bgmPlayers[index].volume = bgmVolume;
        }
        //bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();


        //Sfx Player Initialize
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].bypassListenerEffects = true;
            sfxPlayers[index].volume = sfxVolume;
        }
    }



    public void PlayBgm(AudioClip bgm, bool isPlay)
    {
        if(isPlay)
        {
            for (int index = 0; index < bgmPlayers.Length; index++)
            {
                if (bgmPlayers[index].isPlaying)
                {
                    continue;
                }
                else
                {
                    bgmPlayers[index].clip = bgm;
                    bgmPlayers[index].Play();
                    break;
                }
            }
        }
        else if(!isPlay)
        {
            for (int index = 0; index < bgmPlayers.Length; index++)
            {
                if (bgmPlayers[index].clip != bgm)
                {
                    continue;
                }
                else
                {
                    bgmPlayers[index].Stop();
                    break;
                }
            }
        }
    }


    public AudioSource SelectBgm(AudioClip bgm)
    {
        for(int i = 0; i < bgmPlayers.Length; i++)
        {
            if (bgmPlayers[i].clip == bgm)
            {
                return bgmPlayers[i].GetComponent<AudioSource>();
            }
        }
        return null;
    }



    public void EffectBgm(bool isPlay)
    {
        bgmEffect.enabled = isPlay;
    }

    public void PlaySfx(AudioClip sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            if (sfxPlayers[index].isPlaying)
            {
                continue;
            }
            else
            {
                sfxPlayers[index].clip = sfx;
                sfxPlayers[index].Play();
                break;
            }

        }
    }
}
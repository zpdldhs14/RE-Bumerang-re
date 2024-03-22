using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SoundData")]
public class SoundData : ScriptableObject
{
    [Header("SFX Sounds")]
    public AudioClip[] audioClips;


    public Dictionary<string, int> soundNameToIndexMap = new Dictionary<string, int>();


    private void OnEnable()
    {

        for (int i = 0; i < audioClips.Length; i++)
        {
            soundNameToIndexMap[audioClips[i].name] = i;
        }
    }


    public AudioClip GetSound(string soundName)
    {
        if (soundNameToIndexMap.ContainsKey(soundName))
        {
            int index = soundNameToIndexMap[soundName];
            if (index >= 0 && index < audioClips.Length)
            {
                return audioClips[index];
            }
        }
        return null;
    }
}
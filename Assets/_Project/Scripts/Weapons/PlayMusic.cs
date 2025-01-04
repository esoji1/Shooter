using System.Collections.Generic;
using UnityEngine;

public class PlayMusic
{
    public AudioSource GetAvailableAudioSource(List<AudioSource> audioSources,
        AudioSource audioSourcePrefab, Transform transform)
    {
        foreach (AudioSource source in audioSources)
            if (source.isPlaying == false)
                return source;

        AudioSource newSource = UnityEngine.Object.Instantiate(audioSourcePrefab, transform);
        audioSources.Add(newSource);
        return newSource;
    }
}

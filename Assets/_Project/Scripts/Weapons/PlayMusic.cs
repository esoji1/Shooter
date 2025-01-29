using System.Collections.Generic;
using UnityEngine;

public class PlayMusic
{
    private float _minInclusive = 0.87f;
    private float _maxInclusive = 1.05f;

    public AudioSource GetAvailableAudioSource(List<AudioSource> audioSources,
        AudioSource audioSourcePrefab, Transform transform)
    {
        foreach (AudioSource source in audioSources)
            if (source.isPlaying == false)
                return source;

        AudioSource newSource = UnityEngine.Object.Instantiate(audioSourcePrefab, transform);
        newSource.pitch = Random.Range(_minInclusive, _maxInclusive);
        audioSources.Add(newSource);
        return newSource;
    }
}

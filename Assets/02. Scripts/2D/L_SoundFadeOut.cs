using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_SoundFadeOut : MonoBehaviour
{
    public AudioSource audioSource;
    public static class AudioController
    {
        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
        {
            FadeTime = 6f;
            float startVolume = audioSource.volume;
            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
                yield return null;
            }
            audioSource.Stop();
        }
     
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AudioController.FadeOut(audioSource, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

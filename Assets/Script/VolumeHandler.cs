using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeHandler : MonoBehaviour
{
/*    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
   {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
    // Start is called before the first frame update
    public void Fade(AudioSource audioSource, float duration, float targetVolume){
        StartCoroutine(FadeVolume.StartFade(audioSource, duration, targetVolume));
    }*/

    public void FadeIn(AudioSource audioSource){
         StartCoroutine(FadeVolume.StartFade(audioSource, 1.5f, 0.3f));
    }

    public void FadeOut(AudioSource audioSource){
         StartCoroutine(FadeVolume.StartFade(audioSource, 1.5f, 0.08f));
    }

    public void FadeOutComplete(AudioSource audioSource){
         StartCoroutine(FadeVolume.StartFade(audioSource, 1.5f, 0));
    }
}

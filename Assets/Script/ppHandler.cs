using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class ppHandler : MonoBehaviour
{
    public Volume volume;
    public bool lighting;
    public bool OneTimeShaking;
    public Bloom bloom;
    public Vignette vignette;
    public ChromaticAberration caValue;
    // Start is called before the first frame update
    void Start()
    {


        volume.profile.TryGet<Bloom>(out bloom);
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<ChromaticAberration>(out caValue);

        lighting = false;
        OneTimeShaking = false;
    }

    public void activateCrystal()
    {
        if (!lighting){
            lighting = true;
            OneTimeShaking = true;
        } else {
            lighting = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lighting && bloom.intensity.value <= 2.0f)
        {
            bloom.intensity.value = bloom.intensity.value + 0.1f;
            //Debug.Log("now bloom is" + bloom.intensity.value);
        } 

        if (!lighting && bloom.intensity.value > 1.0f)
        {
            bloom.intensity.value = bloom.intensity.value - 0.1f;
           // Debug.Log("now bloom is" + bloom.intensity.value);
        }

        if (lighting && vignette.intensity.value <= 0.4f)
        {
            vignette.intensity.value = vignette.intensity.value + 0.02f;
          //  Debug.Log("now bloom is" + bloom.intensity.value);
        } 

        if (!lighting && vignette.intensity.value > 0f)
        {
            vignette.intensity.value = vignette.intensity.value - 0.02f;
            Debug.Log("now bloom is" + bloom.intensity.value);
        }

        if (OneTimeShaking && caValue.intensity.value <= 1f)
        {
            caValue.intensity.value = caValue.intensity.value + 0.2f;
            if (caValue.intensity.value == 1f)
            {
                OneTimeShaking = false;
            }
            //Debug.Log("now bloom is" + caValue.intensity.value);
        } 

        if (!OneTimeShaking && caValue.intensity.value > 0f)
        {
            caValue.intensity.value = caValue.intensity.value - 0.2f;
            //Debug.Log("now bloom is" + caValue.intensity.value);
        }
    }
}

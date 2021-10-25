using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingHandler : MonoBehaviour
{
public Material glow, nonglow;
bool isGlowing = false;

public void ToggleGlow()
{
    if (isGlowing)
    {
        gameObject.GetComponent<MeshRenderer>().material = nonglow;
        isGlowing = false;
    } else {
        gameObject.GetComponent<MeshRenderer>().material = glow;
        isGlowing = true;
    }
}
}

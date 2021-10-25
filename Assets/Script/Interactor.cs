using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.UI;


public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayermask = 6;
    public Interactable interactable;
    public AudioHandler audioHandler;
    public Image interactImage;
    public Image PressEButtonArea;
    public Sprite defaultIcon;
    public Vector2 defaultIconSize;
    public Sprite deafaultInteractIcon;
    public Vector2 defaultInteractIconSize;
    public Sprite PressEButtonIcon;
    public Sprite TransparentIcon;
    public Sprite WaitForAudio;
    public Vector2 defaultTextBoxSize;
    public Vector2 waitTextBoxSize;
    bool audioPlaying;
    //UnityEvent onInteract;
    // Start is called before the first frame update
    void Start()
    {
        audioPlaying = false;
    }

    public void audioToggle() {
        
        if (audioPlaying) 
        {
            audioPlaying = false;
        } else {
            audioPlaying = true; 
        }
        Debug.Log("Switch happen now audioPlaying is" + audioPlaying);
    }

    // Update is called once per frame
    void Update()
    {
      RaycastHit hit;
        
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10, interactableLayermask))
        {
            if (hit.collider.GetComponent<Interactable>() != false)
            {
            //onInteract = hit.collider.GetComponent<Interactable>().onInteract;
                if ((interactable == null) || (interactable.ID != hit.collider.GetComponent<Interactable>().ID))
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                    audioHandler = hit.collider.GetComponent<AudioHandler>();
                    
                    //Debug.Log("New interactable!");
                }
                if (interactable.interactIcon != null)
                {
                    interactImage.sprite = interactable.interactIcon;
                    if (interactable.iconSize == Vector2.zero)
                    {
                        interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                    } else {
                        interactImage.rectTransform.sizeDelta = interactable.iconSize; 
                    }
                } else {
                    interactImage.sprite = deafaultInteractIcon;
                    PressEButtonArea.sprite = PressEButtonIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                }
                if (audioPlaying) {
                        Debug.Log("Change text reached");
                        PressEButtonArea.rectTransform.sizeDelta = waitTextBoxSize;
                        PressEButtonArea.sprite = WaitForAudio;
                } else {
                        PressEButtonArea.rectTransform.sizeDelta = defaultTextBoxSize;
                        PressEButtonArea.sprite = PressEButtonIcon;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (audioPlaying) {

                    } else {
                        audioToggle();
                        interactable.onInteract.Invoke();
                        audioHandler.startInteract();
                    }
                }
            }
        } else {
            if (interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                PressEButtonArea.sprite = TransparentIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.UI;


public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayermask = 6;
    public Interactable interactable;
    public Image interactImage;
    public Sprite defaultIcon;
    public Vector2 defaultIconSize;
    public Sprite deafaultInteractIcon;
    public Vector2 defaultInteractIconSize;
    //UnityEvent onInteract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      RaycastHit hit;
        
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayermask))
        {
            if (hit.collider.GetComponent<Interactable>() != false)
            {
            //onInteract = hit.collider.GetComponent<Interactable>().onInteract;
                if ((interactable == null) || (interactable.ID != hit.collider.GetComponent<Interactable>().ID))
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                    
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
                    interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                   interactable.onInteract.Invoke();
                }
            }
        } else {
            if (interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
        }
    }
}

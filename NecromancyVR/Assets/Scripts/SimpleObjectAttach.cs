using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleObjectAttach : MonoBehaviour
{
    //interactable for reasons
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        //save interactable variable
        interactable = GetComponent<Interactable>();
    }

    public void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }

    public void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }

    public void HandHoverUpdate(Hand hand)
    {
        GrabTypes grapType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //check if the object isn't being held and the player is trying to grab it
        //else, release the object
        if(interactable.attachedToHand == null && grapType != GrabTypes.None)
        {
            Debug.Log("Attaching to hand");
            hand.AttachObject(gameObject, grapType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        }
        else if(isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }
}

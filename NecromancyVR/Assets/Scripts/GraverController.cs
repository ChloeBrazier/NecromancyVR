using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GraverController : MonoBehaviour
{
    //TODO: Fix Graver left-handed holding pose
    //this object's interactable component
    private Interactable interactable;

    //action for flipping through the Graver
    private SteamVR_Action_Vector2 flipAction;

    //variables for tracking touchpad swiping
    private Vector2 swipeXAxis = Vector2.right;
    private Vector2 swipeYAxis = Vector2.up;
    private bool trackSwipe = false;
    private bool checkSwipe = false;
    public float swipeAngleRange;
    public float minSwipeDistance;
    public float swipeVelocity;
    private Vector2 swipeStart;
    private Vector2 swipeEnd;


    //detachment timer values to check if the Graver has been thrown away
    private float detachTick = 0;
    private float detachTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        //save interactable component
        interactable = GetComponent<Interactable>();

        //save flip action to touchpad
        flipAction = SteamVR_Actions.default_TouchPad;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the Graver is attached to a hand
        if(interactable.attachedToHand == null)
        {
            //increment detach tick
            detachTick += Time.deltaTime;

            //check if the detachment tick is greater than the timer
            if(detachTick > detachTimer)
            {
                //despawn the graver
                Destroy(gameObject);
            }
        }
        else
        {
            //TODO: Allow for page-flipping with the Graver via swipe detection
            //save the input source of the hand holding the Graver
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            //if(flipAction[source].)
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GraverController : MonoBehaviour
{
    //this object's interactable component
    private Interactable interactable;

    //detachment timer values to check if the graver has been thrown away
    private float detachTick = 0;
    private float detachTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        //save interactable component
        interactable = GetComponent<Interactable>();
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
    }
}

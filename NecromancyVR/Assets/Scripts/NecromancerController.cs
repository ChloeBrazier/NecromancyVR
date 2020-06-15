using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class NecromancerController : MonoBehaviour
{
    //active Graver
    private Interactable activeGraver;

    //Graver prefab
    [SerializeField]
    private GameObject graverPrefab;

    //bool to see if the player can pull out the Graver
    //private bool summonGraver = false;

    //max summon distance for the Graver
    public float graverSummonDistance;

    //vr camera
    [SerializeField]
    private GameObject vrCam;

    //action bool for VR controllers
    public SteamVR_Action_Boolean graverSummonAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //loop to check each hand
        foreach(Hand hand in Player.instance.hands)
        {
            //save the input source of the hand
            SteamVR_Input_Sources source = hand.handType;

            //--check if the player's hand is behind them
            //get vector between head and hand
            Vector3 headToHand = hand.transform.position - vrCam.transform.position;

            //get the dot product of the head and the vector between the head and the hand
            float forwardProduct = Vector3.Dot(Player.instance.bodyDirectionGuess, headToHand);

            //check if the forward product is negative, and allow the player to pull out the Graver if the vector is small enough and no other Graver exists in the world
            if (forwardProduct < 0 && headToHand.z < graverSummonDistance && headToHand.x < graverSummonDistance && activeGraver == null)
            {
                //rumble the controller when it's possible to summon the Graver
                hand.TriggerHapticPulse(2500);

                //check if the trigger is pressed and then summon the Graver to the player's hand if it is
                if(graverSummonAction[source].stateDown)
                {
                    //check if another Graver exists in the world and destroy it
                    if(activeGraver != null)
                    {
                        Destroy(activeGraver.gameObject);
                    }

                    //spawn the Graver and attach it to the player's hand
                    GameObject newGraver = Instantiate(graverPrefab);
                    activeGraver = graverPrefab.GetComponent<Interactable>();
                    hand.AttachObject(newGraver, GrabTypes.Pinch);
                    hand.HoverLock(activeGraver);
                }
            }
        }
    }
}

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
    private bool summonGraver = false;

    //max summon distance for the Graver
    public float graverSummonDistance;

    //vr camera
    [SerializeField]
    private GameObject vrCam;

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
            //--check if the player's hand is behind their head
            //get vector between head and hand
            Vector3 headToHand = hand.transform.position - vrCam.transform.position;

            //get the dot product of the head and the vector between the head and the hand
            float forwardProduct = Vector3.Dot(Player.instance.bodyDirectionGuess, headToHand);

            //check if the forward product is negative, and allow the player to pull out the Graver if the vector is small enough and no other Graver exists in the world
            if (forwardProduct < 0 && headToHand.z < graverSummonDistance && headToHand.x < graverSummonDistance && activeGraver == null)
            {
                //activate ability to summon graver
                summonGraver = true;

                //rumble the controller when it's possible to summon the Graver
                hand.TriggerHapticPulse(2500);
            }
            else
            {
                //set graver activation bool to false
                summonGraver = false;
            }
        }
    }
}

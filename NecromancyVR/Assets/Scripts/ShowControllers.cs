using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ShowControllers : MonoBehaviour
{
    //bool that decides when to show controllers
    [SerializeField]
    private bool showControllers = false;

    // Update is called once per frame
    void Update()
    {
        foreach(Hand hand in Player.instance.hands)
        {
            if(showControllers == true)
            {
                hand.ShowController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
            }
            else
            {
                hand.HideController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithoutController);
            }
        }
    }
}

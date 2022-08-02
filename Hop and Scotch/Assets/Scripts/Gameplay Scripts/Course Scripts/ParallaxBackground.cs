using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public Transform cameraTransform; //there can be multiple players, so setting this up manually is necessary

    private Vector3 lastCameraPosition;

    private Vector3 deltaMovement;

    [SerializeField] private Vector2 parallaxEffectMultiplier ;

    // Start is called before the first frame update
    void Start()
    {
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        deltaMovement = cameraTransform.position - lastCameraPosition; //this tracks how much the camera has moved since the previous frame. 
                                                                       //LastUpdate makes sure this happens AFTER the camera has moved

        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0);    //we move the background piece this script is attached to by the camera movement

        lastCameraPosition = cameraTransform.position;   //then we reset our lastcameraposition to our currentcamera position
    }
}

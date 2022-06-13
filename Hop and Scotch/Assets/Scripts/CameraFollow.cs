using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float xMax = 400;

    [SerializeField]
    private float yMax = 400;

    [SerializeField]
    private float xMin = -400;

    [SerializeField]
    private float yMin = -400;

    public Transform target;

    public Player TargetPlayer;

    public float CameraOffset;
    public float CameraOffsetRate;
    public float MaxRightCameraOffset;
    public float MaxLeftCameraOffset;

    void Start()
    {
    }
    void LateUpdate()
    {
        if (TargetPlayer != null)
        {

            transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax) + CameraOffset, Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);

            /*
            if ((TargetPlayer.VehicleMode == "Cowboy") && (TargetPlayer.PVeloc >= TargetPlayer.MaxSpeed))
            {
                if (TargetPlayer.isFlipped == 1)
                {
                    if (CameraOffset >= MaxRightCameraOffset) CameraOffset = MaxRightCameraOffset;

                    else CameraOffset = CameraOffset + CameraOffsetRate;
                }
                else if (TargetPlayer.isFlipped == -1)
                {
                    if (CameraOffset <= MaxLeftCameraOffset) CameraOffset = MaxLeftCameraOffset;

                    else CameraOffset = CameraOffset - CameraOffsetRate;
                }


            }
            
            if (TargetPlayer.VehicleMode == "Cowboy" && !TargetPlayer.Accelerating)
            {
                if (TargetPlayer.isFlipped == 1)
                {
                    if (CameraOffset <= 0) CameraOffset = 0;
                    CameraOffset = CameraOffset - CameraOffsetRate;
                }
                else if (TargetPlayer.isFlipped == -1)
                {
                    if (CameraOffset >= 0) CameraOffset = 0;
                    CameraOffset = CameraOffset + CameraOffsetRate;
                }


            }
            */
        }
    }

    public void SetXBoundary(float min, float max)
    {
        xMin = min;
        xMax = max;      
    }
}

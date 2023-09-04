using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThorughPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LetThrough()
    {
        //Debug.Log("FTP Function Called");
        effector.rotationalOffset = 180f;

        Invoke(nameof(SetBackUp),0.6f);
    }

    public void SetBackUp()
    {
        effector.rotationalOffset = 0f;
    }

}

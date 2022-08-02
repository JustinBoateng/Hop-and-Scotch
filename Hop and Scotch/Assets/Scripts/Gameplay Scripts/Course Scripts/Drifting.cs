using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drifting : MonoBehaviour
{
    Rigidbody2D MyRD;

    // Start is called before the first frame update
    void Start()
    {
        MyRD = GetComponent<Rigidbody2D>();
        MyRD.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        MyRD.velocity = new Vector2(0.5f, 0);
    }
}

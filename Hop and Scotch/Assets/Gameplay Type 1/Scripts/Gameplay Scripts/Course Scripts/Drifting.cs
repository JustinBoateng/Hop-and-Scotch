using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drifting : MonoBehaviour
{
    Rigidbody2D MyRD;

    float basetimer = 10f;
    float timer = 10f;
    float timerrate = 0.003f;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        MyRD = GetComponent<Rigidbody2D>();
        MyRD.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        MyRD.velocity = new Vector2(0.5f * direction, 0);

        timer = timer - timerrate;
        if (timer <= 0) {
            timer = basetimer;
            direction = direction * -1;
        }


    }
}

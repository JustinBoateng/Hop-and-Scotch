using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSmokePolish : MonoBehaviour
{
    public int counter = 0;

    public int counterrate = 2;

    public int max = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter = counter + counterrate;
        if (counter >= max) Destroy(this.gameObject);
    }
}

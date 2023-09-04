using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStages : MonoBehaviour
{
    public Sprite StageVisual;
    public string Description;

 
    public Sprite getVisual()
    {
        return StageVisual;
    }

    public string getDesc()
    {
        return Description;
    }

}

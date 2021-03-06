using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public bool passed = false;
    public Transform pos;

    public int buttontype;
    public char butt;
    public Sprite buttImage;
    public GameObject ButtonPrefab;

    public bool Blank = false;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setButt(int bt, char c)
    {
        //set the buton type and the actual button 
        buttontype = bt;
        butt = c;


            //set the image to the 
        //GameObject BI = Instantiate(ButtonPrefab, new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, -1), this.transform.rotation);

            //set the button image to the child of this object
        //BI.transform.SetParent(this.transform);        
        //BI.AddComponent<SpriteRenderer>();

        if (c == '0')
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
            Blank = true;
        }

        else if (((int)char.GetNumericValue(c) > 0) && ((int)char.GetNumericValue(c) < 8))
        {
            //Debug.Log("Type: " + bt + "  Button Number: " + (int)char.GetNumericValue(c));
            GameObject BI = Instantiate(ButtonPrefab, new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, -1), this.transform.rotation);
            BI.transform.SetParent(this.transform);
            BI.GetComponent<SpriteRenderer>().sprite = ButtonEncyclopedia.BS.RetrieveSprite(bt, (int)char.GetNumericValue(c)); //the -0 converts the char to an int
        }

        else if (c == '8')
        {
            this.GetComponent<SpriteRenderer>().sprite = ButtonEncyclopedia.BS.RetrieveSprite(bt, 8);
            
        }

        else
        {
            this.GetComponent<SpriteRenderer>().sprite = ButtonEncyclopedia.BS.RetrieveSprite(bt, 9);
          
        }
      
    }

    public bool isBlank()
    {
        return Blank;
    }
}

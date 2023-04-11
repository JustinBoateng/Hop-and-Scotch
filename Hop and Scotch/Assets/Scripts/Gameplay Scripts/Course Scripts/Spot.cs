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


    public SpriteRenderer BlockVisual;
    public SpriteRenderer BlockVisualExtra;

    public string SpotCode;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setButt(int bt, char c, float yoffset, float buttoffset)
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
            Destroy(this.gameObject);
            //if(this.GetComponentInChildren<GameObject>().gameObject != null)
             //   Destroy(this.GetComponentInChildren<GameObject>().gameObject);
            //Blank = true;
        }

        else if (((int)char.GetNumericValue(c) > 0) && ((int)char.GetNumericValue(c) < 8))
        {
            //Debug.Log("Type: " + bt + "  Button Number: " + (int)char.GetNumericValue(c));
            GameObject BI = Instantiate(ButtonPrefab, new Vector3(this.transform.position.x, this.transform.position.y - buttoffset, -1), this.transform.rotation);
            BI.transform.SetParent(this.transform);
            BI.GetComponent<SpriteRenderer>().sprite = ButtonEncyclopedia.BS.RetrieveSprite(bt, (int)char.GetNumericValue(c)); //the -0 converts the char to an int
            BI.GetComponent<SpriteRenderer>().sortingLayerName = "Spot Layer";
            BI.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }

        else if (c == '8')
        {
            BlockVisual.GetComponent<SpriteRenderer>().sprite = ButtonEncyclopedia.BS.RetrieveSprite(bt, 8);
            BlockVisual.gameObject.transform.position = new Vector2(BlockVisual.transform.position.x, BlockVisual.transform.position.y - 0.31f);
            //set sprite to be Start 
            Destroy(BlockVisualExtra);
        }

        else
        {
            BlockVisual.GetComponent<SpriteRenderer>().sprite = ButtonEncyclopedia.BS.RetrieveSprite(bt, 9);
            //set block sprite to be END
            BlockVisual.gameObject.transform.position = new Vector2(BlockVisual.transform.position.x, BlockVisual.transform.position.y - 0.31f);
            Destroy(BlockVisualExtra);
        }

        //this.gameObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + yoffset);

        BlockVisual.gameObject.transform.position = new Vector2(BlockVisual.transform.position.x, BlockVisual.transform.position.y + yoffset);

        if(BlockVisualExtra)
        BlockVisualExtra.gameObject.transform.position = new Vector2(BlockVisualExtra.transform.position.x, BlockVisualExtra.transform.position.y + yoffset);

    }

    public bool isBlank()
    {
        return Blank;
    }
}

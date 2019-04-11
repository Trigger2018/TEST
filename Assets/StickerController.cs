using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerController : MonoBehaviour {
private int stickerCount=0;
public int stickerNumber;
    public GameObject yourObject;
    public bool menuActive;
    public SpriteRenderer currentSticker;

    public Sprite[] images;
    public GameObject[] stickersPrefab;
	
	public bool snapControl = false;
    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			snapControl = !snapControl;
		}
        StickerControl();
        SelectSticker();
        
    }

    public void ChangeSticker(int stickernumber)
    {
        if((stickernumber > images.Length -1) || (stickernumber <0))
        {
            Debug.Log(stickernumber + " is out of range");
        }
        else
        {
            currentSticker.sprite  = images[stickernumber];
            yourObject = stickersPrefab[stickernumber];
        }
    }

    public void StickerControl()
    {
        ChangeSticker(stickerNumber);
		currentSticker.sortingOrder = stickerCount+1;
        Vector3 cursorPosition = Input.mousePosition;
            cursorPosition.z = 2.0f;       // we want 2m away from the camera position
            this.transform.position = Camera.main.ScreenToWorldPoint(cursorPosition);
			if(snapControl)
			{
				this.transform.position = new Vector3( 
					Mathf.Round(this.transform.position.x*2f)/2f,
					Mathf.Round(this.transform.position.y*2f)/2f,
					Mathf.Round(this.transform.position.z*2f)/2f) ;
			}

        if(!menuActive)
        {
            if (Input.GetButtonDown ("Fire1")) //this checks to see if the "Fire1" button has been pressed Down
            {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
			if(snapControl)
			{
				this.transform.position = new Vector3( 
					Mathf.Round(this.transform.position.x*2f)/2f,
					Mathf.Round(this.transform.position.y*2f)/2f,
					Mathf.Round(this.transform.position.z*2f)/2f) ;
					objectPos = this.transform.position;
					GameObject clone = Instantiate(yourObject, objectPos, Quaternion.identity);
					stickerCount++;
				clone.GetComponent<SpriteRenderer>().sortingOrder = stickerCount;
			}
			else
			{
            	GameObject clone = Instantiate(yourObject, objectPos, Quaternion.identity);
				stickerCount++;
				clone.GetComponent<SpriteRenderer>().sortingOrder = stickerCount;
			}
			
			
            }
        }
    }

    public void SelectSticker()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            stickerNumber--;    
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            stickerNumber++;
        }

        if(stickerNumber <0)
        {
            stickerNumber = images.Length-1;
        }
        if(stickerNumber > images.Length-1 )
        {
            stickerNumber =0;
        }
    }

}

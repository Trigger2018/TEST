using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
public bool setWall;
Renderer rend ;
BoxCollider wall;
	// Use this for initialization
	void Start () {
		
		//Fetch the Renderer from the GameObject
         rend = GetComponent<Renderer>();
		wall = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(setWall)
		{
			MakeWallChanges();	
		}
		else if (!setWall)
		{
			NoWallChanges();
		}
	}

	void MakeWallChanges()
	{
		rend.material.color = Color.red;	
		wall.isTrigger = true;

	}
	void NoWallChanges()
	{
		//rend.material.color = Color.white;	
		wall.isTrigger = false;

	}

	 void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
		//Set the main Color of the Material to green
        rend.material.color = Color.green;
        
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
		rend.material.color = Color.white;
    }

	void OnMouseDown()
    {
		setWall = !setWall;
		Debug.Log("Change the wall State");
	}
}

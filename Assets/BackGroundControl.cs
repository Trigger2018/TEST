using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundControl : MonoBehaviour {

	public Sprite[] bkgImg;
	public SpriteRenderer currentBKG;
	public int bkgNumber;
	// Use this for initialization
	void Start () {
		currentBKG = GetComponent<SpriteRenderer>();
		ChangeBackground(bkgNumber);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeBackground(int setNumber)
	{
		ChangBkgNumber(setNumber);
		currentBKG.sprite = bkgImg[bkgNumber];
	}
	public void ChangBkgNumber(int setNumber)
	{
		bkgNumber = setNumber;
		if(bkgNumber > bkgImg.Length - 1 ||bkgNumber <0)
		{
			bkgNumber =0;
		}
	}
}

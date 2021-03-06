﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class basket : MonoBehaviour
{
	private static int cups=0; 
    public GameObject canvas1;
    public GameObject winCanvas;
    
    void Awake()
    {
        
    }

    void Start()
    {
        cups=0;
    }

	void OnCollisionEnter() //if ball hits board
    {
        cups++;
        Debug.Log("cups="+cups);

        Invoke("DestroyAfterTime",1.5f);

        //display win message after getting all cupss
        if(cups >= 10)
        {
            winCanvas.SetActive(true);
            canvas1.SetActive(false);
            Debug.Log("win");

        }
            
    }

    void DestroyAfterTime(){
		Debug.Log("Cup Destroyed");
        Destroy (transform.parent.gameObject);
        Destroy (gameObject);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class throwScriptv3 : MonoBehaviour {
    public Rigidbody rb;
    public Transform planeTrans;

	public float forceMultiplier;
    private Vector2 startSwipe;
	private Vector2 endSwipe;
	private Vector3 originalPos;

    public GameObject ball;

    void Start(){
        rb = GetComponent<Rigidbody>();
        originalPos = ball.transform.position;
    }

    void FixedUpdate(){
        if(Input.GetMouseButtonDown (0)){
            Debug.Log("Begin");
            startSwipe = Camera.main.ScreenToViewportPoint (Input.mousePosition) * 2;
            Debug.Log(startSwipe);
        }
        if (Input.GetMouseButtonUp (0)){
            endSwipe = Camera.main.ScreenToViewportPoint (Input.mousePosition) * 2;
            Vector2 swipe = startSwipe - endSwipe;
            Debug.Log("End");
            Debug.Log(swipe.y);
            if(Math.Abs(swipe.y) > 0){
                Launch();
            }
        }
    }

    void Launch(){
        ball.GetComponent<Rigidbody>().isKinematic = false;
		Vector2 swipe = startSwipe - endSwipe;
		float xforce = (swipe.x * forceMultiplier);
		float yforce = Math.Abs((swipe.y * forceMultiplier)/2);
        float tentativeZ = (Math.Abs(planeTrans.position.z - ball.transform.position.z) + 1.25f)*forceMultiplier;
        float zforce;
        if(tentativeZ < yforce)
            zforce = tentativeZ;
        else
            zforce = yforce;

        rb.AddForce (xforce, 100f, zforce, ForceMode.Force);
        Debug.Log("xForce="+xforce+", zForce="+zforce);
    }
}
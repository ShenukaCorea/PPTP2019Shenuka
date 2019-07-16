using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerswing : MonoBehaviour
{
	public Sprite authoritybig;
	public Sprite authoritysmall;
	public Sprite subjectbig;
	public Sprite subjectsmall;
	public CameraController camCon;
	private float authoritydist;
	private float subjectdist;
	GameObject authority, subject;
    // Start is called before the first frame update
    void Start()
    {
        authority = GameObject.Find("authority");
        subject = GameObject.Find("subject");
        camCon = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        authoritydist = authority.GetComponent<ProximityToCenter>().GetCenterDistance();
        Debug.Log("AUTHORITY is " + authoritydist + " pixels from the center");
        subjectdist = subject.GetComponent<ProximityToCenter>().GetCenterDistance();
        Debug.Log("SUBJECT is " + subjectdist + " pixels from the center");

        if( camCon.canObserve()){
	        if ( authoritydist<subjectdist){
	        	Debug.Log("AUTHORITY is closer to center");
	        	authority.GetComponent<SpriteRenderer>().sprite=authoritybig;
	        	subject.GetComponent<SpriteRenderer>().sprite=subjectsmall;
	        }
	        else{
	        	Debug.Log("SUBJECT is closer to center");
	        	authority.GetComponent<SpriteRenderer>().sprite=authoritysmall;
	        	subject.GetComponent<SpriteRenderer>().sprite=subjectbig;
	        }
        }
    }
}

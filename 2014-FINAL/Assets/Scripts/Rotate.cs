using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	public float myRotationSpeed = 100.0f;
	
	public bool isRotateX = false;
	public bool isRotateY = false;
	public bool isRotateZ = false;
	
	private bool positiveRotation = false;
	
	private int posOrNeg = 1;
	
	void Start () 
	{
		collider.isTrigger = true;
		if(positiveRotation == false)
		{
			posOrNeg = -1;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isRotateX)
		{
			transform.Rotate(myRotationSpeed*Time.deltaTime * posOrNeg,0,0);
		}
		else if(isRotateY)
		{
			transform.Rotate(0,myRotationSpeed * Time.deltaTime * posOrNeg ,0);
		}
		else if (isRotateZ)
		{
			transform.Rotate(0,0, myRotationSpeed* Time.deltaTime * posOrNeg);
		}
		
		
	}
	
}

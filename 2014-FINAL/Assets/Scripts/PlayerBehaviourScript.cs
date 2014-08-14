using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerBehaviourScript : MonoBehaviour {

	// Use this for initialization



	public List<Transform> wayPoints = new List<Transform>();
	public float timmer;
	public float speed = 10.0f;
	public int index;
	public Vector3 Force;
	private  Vector3 velocity = Vector3.zero;



	void Start () 
	{
		Invoke("StartTimer",5);

	}
	
	// Update is called once per frame
	void Update () 


	
	{
		if (speed > float.Epsilon)
		{
			transform.forward = velocity;
			
		}
		Force = Vector3.zero;



		Debug.Log(Time.time);
			if(index == 10)
			{
				index = 0;
			}



		Vector3 direction = wayPoints[index].transform.position - transform.position;
		direction.Normalize();
		var distance = Vector3.Distance(wayPoints[index].transform.position,transform.position);

		if (distance<1.0f)
		{
			index = index + 1;
			

		}




		transform.Translate(direction * Time.deltaTime * speed);
	}

	void StartTimer()
	{
		StartCoroutine(Idle1());

	}

	IEnumerator Idle1()

	{

		speed = 25f;
		yield return new WaitForSeconds(0.5f);
		speed = 20f;
		yield return new WaitForSeconds(0.5f);
		speed = 15f;
		yield return new WaitForSeconds(0.5f);
		speed = 10f;





	}



}



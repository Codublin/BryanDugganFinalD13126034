using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyBehaviourScript : MonoBehaviour {



	public enum GameState
	{
		Seek, 
		Arrive,
		Chase, 
		Flee,
		Idle
	}
	// Use this for initialization
	public List<Transform> wayPoints = new List<Transform>();
	public GameObject Bullet;
	private float fireRate = 5f;
	public float timmer;
	public float speed = 45.0f;
	public int index;
	public GameState currentState;
	public Transform player;
	private PlayerBehaviourScript  _player;
	
	
	void Start () 
	{
		 Invoke("StartTimer",60);
		_player = GameObject.Find("Player").GetComponent<PlayerBehaviourScript>();

		timmer = Time.time; 
	}
	
	// Update is called once per frame
	void Update () 
		
	{

		if(index == 10)
		{
			index = 0;
		}

		if(currentState == GameState.Seek)
		{
			Vector3 direction = wayPoints[index].transform.position - transform.position;
			direction.Normalize();
			var distance = Vector3.Distance(wayPoints[index].transform.position,transform.position);
			var distanceFromPlayer = Vector3.Distance(player.transform.position,transform.position);

			Debug.Log (distanceFromPlayer);
			if(distanceFromPlayer <40f)
			{
				currentState = GameState.Chase;
			}

			if (distance<5.0f)
			{
				index = index +1;
			}
		
			transform.Translate(direction * Time.deltaTime *speed);
		}

		
		if(currentState == GameState.Chase)
		{
			if (Time.time > fireRate)
			{
				Instantiate(Bullet,transform.position,Quaternion.identity);
				fireRate = Time.time +20;

			}

			_player.speed = 12f;
			speed = 15f;



			var distanceFromPlayer = Vector3.Distance(player.transform.position,transform.position);

			if(distanceFromPlayer > 1.3f)
			{
				speed = 55f;
			}

			if (distanceFromPlayer >1.5f)
			{
				currentState = GameState.Flee;
			}
			
			Vector3 direction = player.transform.position - transform.position;
			transform.Translate(direction * Time.deltaTime * speed);



		}
		if(currentState == GameState.Flee)
		{

			Debug.Log("Your in flee state");
			currentState = GameState.Seek;

		
		}
		if(currentState == GameState.Idle)
		{
			Debug.Log("Your in idle state");
			
		}






	}

	void StartTimer()
	{
		StartCoroutine(Idle1());
		
	}
	
	IEnumerator Idle1()
		
	{
		
		speed = 15f;
		yield return new WaitForSeconds(0.5f);
		speed = 12.5f;
		yield return new WaitForSeconds(0.5f);
		speed =10f;
		yield return new WaitForSeconds(0.5f);
		
		
		
		
		
	}
	
	
	
}
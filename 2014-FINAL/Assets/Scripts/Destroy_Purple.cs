using UnityEngine;
using System.Collections;

public class Destroy_Purple: MonoBehaviour
{

	public float lifetime;
	public GameObject explosion;

	void Start ()
	{
		Destroy (gameObject, lifetime);
		Instantiate(explosion, transform.position, transform.rotation);
	
	}

	void Update()
	{
		if(lifetime <=0.5f)
		{
		Instantiate(explosion, transform.position, transform.rotation);
	    }
	}

}

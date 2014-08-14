using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour
{

	public Transform target;

	public float Speed = 1.0f;

void  Update()
	{
		if (target = null)
		{
			transform.RotateAround(target.position,Vector3.up,Speed * Time.deltaTime);
		}


}
}
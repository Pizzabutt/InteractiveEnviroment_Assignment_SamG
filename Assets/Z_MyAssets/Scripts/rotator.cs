using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour
{
	public float speed;
	void Start ()
	{
	
	}
	void Update ()
	{
		transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker: MonoBehaviour
{
	private Rigidbody _rigidbody;

	// Use this for initialization
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			_rigidbody.AddForce(50, 0, 0, ForceMode.VelocityChange);
		}
	}
}


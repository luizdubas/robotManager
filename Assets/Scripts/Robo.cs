using UnityEngine;
using System.Collections;

public class Robo : MonoBehaviour {
	
	private float runSpeed = 50;
	
	// Use this for initialization
	void Start () {
		Debug.Log( "Start new Robo" );
	}
	
	// Update is called once per frame
	void Update () {
	//	rigidbody.velocity = new Vector3( rigidbody.velocity.x, rigidbody.velocity.y,  runSpeed * Time.deltaTime );
	}
}

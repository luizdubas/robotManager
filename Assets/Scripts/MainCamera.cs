using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	

	private RobotUtility robotUtility;
	
	// Use this for initialization
	void Start () {
		GameObject novoRobo;
		robotUtility = GameObject.Find("RobotUtility").GetComponent<RobotUtility>();
		
		novoRobo = robotUtility.criarRobo( 
			robotUtility.prefabRobot1, /** Armature  **/
			robotUtility.prefabRobot2, /** HEAD      **/
			robotUtility.prefabRobot1, /** BODY      **/
			robotUtility.prefabRobot2, /** ARMS		 **/
			robotUtility.prefabRobot1  /** LEGS      **/
		);
		
		novoRobo.transform.position = new Vector3( 0, 2, 0 );
		novoRobo.animation.Play("Move");
		novoRobo.animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	private RobotUtility robotUtility;
	private GameObject novoRobo;
	private bool moving;
	private float rotation = 0;
	private Vector3 move = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		robotUtility = GameObject.Find("RobotUtility").GetComponent<RobotUtility>();
		
		novoRobo = robotUtility.criarRobo( 
			robotUtility.prefabRobot1, /** Armature  **/
			robotUtility.prefabRobot2, /** HEAD      **/
			robotUtility.prefabRobot1, /** BODY      **/
			robotUtility.prefabRobot2, /** ARMS		 **/
			robotUtility.prefabRobot1  /** LEGS      **/
		);
		
		novoRobo.transform.position = new Vector3( 0, 1, 0 );
		/*novoRobo.animation.Play("Walk");
		novoRobo.animation.wrapMode = WrapMode.Loop;*/
	}
	
	// Update is called once per frame
	void Update () {
		#region input robo
		if(Input.GetKeyDown("up"))
		{
			Debug.Log("Current rotation = "+novoRobo.transform.eulerAngles.y);
			moving = true;
			move = new Vector3(0,0,1);
			rotation = -novoRobo.transform.eulerAngles.y;
			novoRobo.transform.Rotate(new Vector3(0,rotation,0));
			Debug.Log("New rotation = "+rotation);
			novoRobo.animation.Play("Walk");
			novoRobo.animation.wrapMode = WrapMode.Loop;
		}
		if(Input.GetKeyDown("down"))
		{
			Debug.Log("Current rotation = "+novoRobo.transform.eulerAngles.y);
			moving = true;
			move = new Vector3(0,0,-1);
			if(rotation != 180)
				rotation = (novoRobo.transform.eulerAngles.y - 180) * -1;
			else 
				rotation = 0f;
			Debug.Log("New rotation = "+rotation);
			novoRobo.transform.Rotate(new Vector3(0,rotation,0));
			novoRobo.animation.Play("Walk");
			novoRobo.animation.wrapMode = WrapMode.Loop;
			
		}
		if(Input.GetKeyDown("left"))
		{
			Debug.Log("Current rotation = "+novoRobo.transform.eulerAngles.y);
			moving = true;
			move = new Vector3(-1,0,0);
			if(rotation != 270)
				rotation = (novoRobo.transform.eulerAngles.y - 270) * -1;
			else 
				rotation = 0f;
			novoRobo.transform.Rotate(new Vector3(0,rotation,0));
			Debug.Log("New rotation = "+rotation);
			novoRobo.animation.Play("Walk");
			novoRobo.animation.wrapMode = WrapMode.Loop;
		}
		if(Input.GetKeyDown("right"))
		{
			Debug.Log("Current rotation = "+novoRobo.transform.eulerAngles.y);
			moving = true;
			move = new Vector3(1,0,0);
			if(rotation != 90)
				rotation = (novoRobo.transform.eulerAngles.y - 90) * -1;
			else 
				rotation = 0f;
			novoRobo.transform.Rotate(new Vector3(0,rotation,0));
			Debug.Log("New rotation = "+rotation);
			novoRobo.animation.Play("Walk");
			novoRobo.animation.wrapMode = WrapMode.Loop;
		}
		
		if(Input.GetKeyUp("right") || Input.GetKeyUp("up") || Input.GetKeyUp("down") || Input.GetKeyUp("left")){
			moving = false;
			novoRobo.animation.Blend("Rest");
			novoRobo.animation.Stop("Walk");
		}
		if(moving)
			novoRobo.transform.position += move * Time.deltaTime;
		#endregion
		
		if(Input.GetKeyDown(KeyCode.Alpha5)){
			Camera.main.transform.position = new Vector3(0,1,-5.5f);
			Camera.main.transform.eulerAngles = new Vector3(0,0,0);
		}
		if(Input.GetKeyDown(KeyCode.Alpha0)){
			Camera.main.transform.position = new Vector3(-15,5,0);
			Camera.main.transform.eulerAngles = new Vector3(25,90,0);
		}
	}
}

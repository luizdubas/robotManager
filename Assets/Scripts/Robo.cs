using UnityEngine;
using System.Collections;
using System;

public class Robo : MonoBehaviour {	
	/** Atributos do robo fora de Batalha */
	private Atributo velocidade;
	private Atributo ataque;
	private Atributo defesa;
	private Atributo hp;
	private Atributo stamina;
		
	private GameObject roboGameObject;

	private string headPrefabName;
	private string bodyPrefabName;
	private string armsPrefabName;
	private string legsPrefabName;
	
	private float runSpeed = 50;
	
	// Use this for initialization
	void Start () {
		Debug.Log( "Start new Robo" );
	}
	
	// Update is called once per frame
	void Update () {
		//	rigidbody.velocity = new Vector3( rigidbody.velocity.x, rigidbody.velocity.y,  runSpeed * Time.deltaTime );
	}
	
	public bool buildRobot () {
		bool retorno = false;
		
		try{
			RobotUtility robotUtility = GameObject.Find("RobotUtility").GetComponent<RobotUtility>();

			this.roboGameObject = robotUtility.criarRobo( 
				robotUtility.getGameObjectByName(this.bodyPrefabName), /** Armature  **/
				robotUtility.getGameObjectByName(this.headPrefabName), /** HEAD      **/
				robotUtility.getGameObjectByName(this.bodyPrefabName), /** BODY      **/
				robotUtility.getGameObjectByName(this.armsPrefabName), /** ARMS		 **/
				robotUtility.getGameObjectByName(this.legsPrefabName)  /** LEGS      **/
			);
			
			retorno = true;
		}catch (Exception e){
			Debug.Log(e);
			retorno = false;
		}
		
		Debug.Log("retorno = "+ retorno );
		return retorno;	
	}
	
	public void disablePhysics(){
		this.roboGameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
	}
	
	public void enablePhysics(){
		this.roboGameObject.rigidbody.constraints = RigidbodyConstraints.None;
	}
	
	
	/** Getters and Setters */
	public Atributo Ataque {
		get {
			return this.ataque;
		}
		set {
			ataque = value;
		}
	}

	public Atributo Defesa {
		get {
			return this.defesa;
		}
		set {
			defesa = value;
		}
	}

	public Atributo Hp {
		get {
			return this.hp;
		}
		set {
			hp = value;
		}
	}

	public Atributo Stamina {
		get {
			return this.stamina;
		}
		set {
			stamina = value;
		}
	}

	public GameObject RoboGameObject {
		get {
			return this.roboGameObject;
		}
		set {
			roboGameObject = value;
		}
	}

	public string HeadPrefabName {
		get {
			return this.headPrefabName;
		}
		set {
			headPrefabName = value;
		}
	}

	public string BodyPrefabName {
		get {
			return this.bodyPrefabName;
		}
		set {
			bodyPrefabName = value;
		}
	}

	public string ArmsPrefabName {
		get {
			return this.armsPrefabName;
		}
		set {
			armsPrefabName = value;
		}
	}

	public string LegsPrefabName {
		get {
			return this.legsPrefabName;
		}
		set {
			legsPrefabName = value;
		}
	}	
}

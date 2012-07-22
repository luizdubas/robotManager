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
	
	private GameObject headGameObject;
	private GameObject bodyGameObject;
	private GameObject armsGameObject;
	private GameObject legsGameObject;

	private Part headPart;
	private Part bodyPart;
	private Part armsPart;
	private Part legsPart;
	
	private float runSpeed = 50;
	
	// Use this for initialization
	void Start () {
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
			
			headGameObject = this.roboGameObject.transform.Find("head").gameObject;
			bodyGameObject = this.roboGameObject.transform.Find("body").gameObject;
			armsGameObject = this.roboGameObject.transform.Find("arms").gameObject;
			legsGameObject = this.roboGameObject.transform.Find("legs").gameObject;
			
			headPart = headGameObject.GetComponent<Part>();
			bodyPart = bodyGameObject.GetComponent<Part>();
			armsPart = armsGameObject.GetComponent<Part>();
			legsPart = legsGameObject.GetComponent<Part>();
			
			retorno = true;
		}catch (Exception e){
			retorno = false;
			Debug.Log(e);
			
		}
		
		return retorno;	
	}
	
	public bool changePart(string partName, Part partToChange){
		bool retorno = false;
		
		try{
			RobotUtility robotUtility = GameObject.Find("RobotUtility").GetComponent<RobotUtility>();
			
			switch( partName ){
			case "head":
				this.headGameObject = robotUtility.changePart( headGameObject, partToChange, roboGameObject );
				this.HeadPart = this.HeadGameObject.GetComponent<Part>();
				break;
			case "body":
				bodyGameObject = robotUtility.changePart( bodyGameObject, partToChange, roboGameObject );
				this.BodyPart = bodyGameObject.GetComponent<Part>();
				
				break;
			case "arms":
				armsGameObject = robotUtility.changePart( armsGameObject, partToChange, roboGameObject );
				this.ArmsPart = armsGameObject.GetComponent<Part>();
				
				break;
			case "legs":
				legsGameObject = robotUtility.changePart( legsGameObject, partToChange, roboGameObject );
				this.LegsPart = legsGameObject.GetComponent<Part>();
				break;
			}

			retorno = true;
		}catch (Exception e){
			retorno = false;
			Debug.Log(e);
		}
		
		return retorno;	
	}
	
	public void disablePhysics(){
		this.roboGameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
	}
	
	public void enablePhysics(){
		this.roboGameObject.rigidbody.constraints = RigidbodyConstraints.None;
	}
	
	
	public Atributo Velocidade {
		get {
			return this.velocidade;
		}
		set {
			velocidade = value;
		}
	}

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

	public GameObject HeadGameObject {
		get {
			return this.headGameObject;
		}
		set {
			headGameObject = value;
		}
	}

	public GameObject BodyGameObject {
		get {
			return this.bodyGameObject;
		}
		set {
			bodyGameObject = value;
		}
	}

	public GameObject ArmsGameObject {
		get {
			return this.armsGameObject;
		}
		set {
			armsGameObject = value;
		}
	}

	public GameObject LegsGameObject {
		get {
			return this.legsGameObject;
		}
		set {
			legsGameObject = value;
		}
	}

	public Part HeadPart {
		get {
			return this.headPart;
		}
		set {
			headPart = value;
		}
	}

	public Part BodyPart {
		get {
			return this.bodyPart;
		}
		set {
			bodyPart = value;
		}
	}

	public Part ArmsPart {
		get {
			return this.armsPart;
		}
		set {
			armsPart = value;
		}
	}

	public Part LegsPart {
		get {
			return this.legsPart;
		}
		set {
			legsPart = value;
		}
	}

	public float RunSpeed {
		get {
			return this.runSpeed;
		}
		set {
			runSpeed = value;
		}
	}
}
using UnityEngine;
using System.Collections;
using System;

public class Robo : MonoBehaviour {	
	/** Atributos do robo fora de Batalha */
	private double velocidadeBase;
	private double ataqueBase;
	private double defesaBase;
	private double hpBase;
	private double staminaBase;
	
	/** Bonus de equipamentos */
	private double velocidadeBonus;
	private double ataqueBonus;
	private double defesaBonus;
	private double hpBonus;
	private double staminaBonus;

	/** Atributos somandos bonus e penalidades */
	private double velocidadeAtual;
	private double ataqueAtual;
	private double defesaAtual;
	private double hpAtual;
	private double staminaAtual;
	
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
	public double VelocidadeBase {
		get {
			return this.velocidadeBase;
		}
		set {
			velocidadeBase = value;
		}
	}

	public double AtaqueBase {
		get {
			return this.ataqueBase;
		}
		set {
			ataqueBase = value;
		}
	}

	public double DefesaBase {
		get {
			return this.defesaBase;
		}
		set {
			defesaBase = value;
		}
	}

	public double HpBase {
		get {
			return this.hpBase;
		}
		set {
			hpBase = value;
		}
	}

	public double StaminaBase {
		get {
			return this.staminaBase;
		}
		set {
			staminaBase = value;
		}
	}

	public double VelocidadeBonus {
		get {
			return this.velocidadeBonus;
		}
		set {
			velocidadeBonus = value;
		}
	}

	public double AtaqueBonus {
		get {
			return this.ataqueBonus;
		}
		set {
			ataqueBonus = value;
		}
	}

	public double DefesaBonus {
		get {
			return this.defesaBonus;
		}
		set {
			defesaBonus = value;
		}
	}

	public double HpBonus {
		get {
			return this.hpBonus;
		}
		set {
			hpBonus = value;
		}
	}

	public double StaminaBonus {
		get {
			return this.staminaBonus;
		}
		set {
			staminaBonus = value;
		}
	}

	public double VelocidadeAtual {
		get {
			return this.velocidadeAtual;
		}
		set {
			velocidadeAtual = value;
		}
	}

	public double AtaqueAtual {
		get {
			return this.ataqueAtual;
		}
		set {
			ataqueAtual = value;
		}
	}

	public double DefesaAtual {
		get {
			return this.defesaAtual;
		}
		set {
			defesaAtual = value;
		}
	}

	public double HpAtual {
		get {
			return this.hpAtual;
		}
		set {
			hpAtual = value;
		}
	}

	public double StaminaAtual {
		get {
			return this.staminaAtual;
		}
		set {
			staminaAtual = value;
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

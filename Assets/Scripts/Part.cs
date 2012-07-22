using UnityEngine;
using System.Collections;

public class Part : MonoBehaviour {
	
	public Texture textura;
	
	public double velocidade;
	public double ataque;
	public double defesa;
	public double hp;
	public double stamina;
	
	public double id;
	private string prefabName;
	private string partType;
	
	public Part clone(){
		Part newPart = new Part();
		
		newPart.velocidade = this.velocidade;
		newPart.ataque = this.ataque;
		newPart.defesa = this.defesa;
		newPart.hp = this.hp;
		newPart.stamina = this.stamina;
		newPart.textura = this.textura;
		
		return newPart;
	}
	
	public double Ataque {
		get {
			return this.ataque;
		}
		set {
			ataque = value;
		}
	}

	public double Id {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}

	public string PrefabName {
		get {
			return this.prefabName;
		}
		set {
			prefabName = value;
		}
	}

	public string PartType {
		get {
			return this.partType;
		}
		set {
			partType = value;
		}
	}
	
}

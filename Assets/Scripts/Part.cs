using UnityEngine;
using System.Collections;

public class Part : MonoBehaviour {
	
	public Texture texture;
	
	public string label;
	
	public double attack;
	public double defense;
	public double hp;
	public double agility;
	public double stamina;
	
	private double id;
	private string prefabName;
	private string partType;
	
	public Part clone(){
		Part newPart = new Part();
		
		newPart.attack = this.attack;
		newPart.defense = this.defense;
		newPart.hp = this.hp;
		newPart.agility = this.agility;
		newPart.stamina = this.stamina;
		newPart.texture = this.texture;
		newPart.label = this.label;
		
		return newPart;
	}
	
	public void copyUniqueAttributes( Part otherPart ){
		otherPart.id = this.id;	
		otherPart.prefabName = this.prefabName;
		otherPart.partType = this.partType;
	}
	public Texture Texture {
		get {
			return this.texture;
		}
		set {
			texture = value;
		}
	}

	public string Label {
		get {
			return this.label;
		}
		set {
			label = value;
		}
	}

	public double Attack {
		get {
			return this.attack;
		}
		set {
			attack = value;
		}
	}

	public double Defense {
		get {
			return this.defense;
		}
		set {
			defense = value;
		}
	}

	public double Hp {
		get {
			return this.hp;
		}
		set {
			hp = value;
		}
	}

	public double Agility {
		get {
			return this.agility;
		}
		set {
			agility = value;
		}
	}

	public double Stamina {
		get {
			return this.stamina;
		}
		set {
			stamina = value;
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

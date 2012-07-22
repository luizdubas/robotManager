using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stock : MonoBehaviour {
	
	private List<Part> headList;
	private List<Part> bodyList;
	private List<Part> armsList;
	private List<Part> legsList;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public List<Part> HeadList {
		get {
			return this.headList;
		}
		set {
			headList = value;
		}
	}

	public List<Part> BodyList {
		get {
			return this.bodyList;
		}
		set {
			bodyList = value;
		}
	}

	public List<Part> ArmsList {
		get {
			return this.armsList;
		}
		set {
			armsList = value;
		}
	}

	public List<Part> LegsList {
		get {
			return this.legsList;
		}
		set {
			legsList = value;
		}
	}
}

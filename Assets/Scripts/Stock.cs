using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stock : MonoBehaviour {
	
	private List<GameObject> headList;
	private List<GameObject> bodyList;
	private List<GameObject> armsList;
	private List<GameObject> legsList;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public List<GameObject> HeadList {
		get {
			return this.headList;
		}
		set {
			headList = value;
		}
	}

	public List<GameObject> BodyList {
		get {
			return this.bodyList;
		}
		set {
			bodyList = value;
		}
	}

	public List<GameObject> ArmsList {
		get {
			return this.armsList;
		}
		set {
			armsList = value;
		}
	}

	public List<GameObject> LegsList {
		get {
			return this.legsList;
		}
		set {
			legsList = value;
		}
	}
}

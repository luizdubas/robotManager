using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private Robo robo;
	private Stock stock;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Robo Robo {
		get {
			return this.robo;
		}
		set {
			robo = value;
		}
	}

	public Stock Stock {
		get {
			return this.stock;
		}
		set {
			stock = value;
		}
	}
}

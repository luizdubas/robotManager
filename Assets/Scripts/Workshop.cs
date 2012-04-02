using UnityEngine;
using System.Collections;

public class Workshop : MonoBehaviour {

	#region Variaveis
	
	public Rect posicaoTituloTela, posicaoLabelNome, areaDesenho;
	public float larguraGUIOriginal = 0, alturaGUIOriginal = 0;
	public int espacoAtributos = 0,tamanhoNome = 0;
	public GUISkin guiSkin;
	private int currentRobot = 0;
	private Rect fullscreen;
	private string RobotName = "No name";
	private Robo robo;
	
	#endregion
	
	void Start () {
		fullscreen = new Rect(0,0,larguraGUIOriginal,alturaGUIOriginal);
		robo = new Robo();
		
		robo.HeadPrefabName = "prefabRobot1";
		robo.BodyPrefabName = "prefabRobot1";
		robo.ArmsPrefabName = "prefabRobot1";
		robo.LegsPrefabName = "prefabRobot1";
		
		robo.buildRobot();
		robo.disablePhysics();
		
		robo.RoboGameObject.transform.localScale = new Vector3( 200, 200, 200 );
		robo.RoboGameObject.transform.position = new Vector3(0 , 9.3f, 10);
			
	}
	
	void OnGUI(){
		GUI.matrix = Matrix4x4.TRS(new Vector3(0,0,0), Quaternion.identity, new Vector3(Screen.width/larguraGUIOriginal,Screen.height/alturaGUIOriginal,1));
		GUI.depth = 2;
		GUI.Label(posicaoTituloTela,"Workshop",guiSkin.GetStyle("Titulo"));
		GUI.Box(posicaoTituloTela,"",guiSkin.GetStyle("TituloOverlay"));

		if( GUI.Button(posicaoLabelNome,"BUTAO 1",guiSkin.GetStyle("Titulo")) ){
			Debug.Log("BUTAO 1");	
		}
		/*
		if( GUI.Button(posicaoLabelNome,"BUTAO 2",guiSkin.GetStyle("Titulo")) ){
			Debug.Log("BUTAO 2");	
		}
		
		if( GUI.Button(posicaoLabelNome,"BUTAO 3",guiSkin.GetStyle("Titulo")) ){
			Debug.Log("BUTAO 3");	
		}
		
		if( GUI.Button(posicaoLabelNome,"BUTAO 4",guiSkin.GetStyle("Titulo")) ){
			Debug.Log("BUTAO 4");	
		}
		
		if( GUI.Button(posicaoLabelNome,"BUTAO 5",guiSkin.GetStyle("Titulo")) ){
			Debug.Log("BUTAO 5");	
		}
		 */	

	}

	void Update () {
	
	}
}
using UnityEngine;
using System.Collections;

public class Workshop : MonoBehaviour {
	
	public enum MenuWorkshopState{
		Default,
		ChangeParts
	}
	
	public enum MenuWorkshopChangePartsState{
		Head,
		Body,
		Arms,
		Legs
	}
	
	#region Variaveis
	
	public Rect posicaoTituloTela, posicaoLabelNome;
	public float larguraGUIOriginal = 0, alturaGUIOriginal = 0;
	public int espacoAtributos = 0,tamanhoNome = 0;
	public GUISkin guiSkin;
	private int currentRobot = 0;
	private Rect fullscreen;
	private string RobotName = "No name";
	private Robo robo;
	private MenuWorkshopState menuState;
	private MenuWorkshopChangePartsState changePartsState;
	
	#endregion
	
	void Start () {
		fullscreen = new Rect(0,0,larguraGUIOriginal,alturaGUIOriginal);
		menuState = MenuWorkshopState.Default;
		changePartsState = MenuWorkshopChangePartsState.Head;
		
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

		switch( menuState ){
		case MenuWorkshopState.Default:
			defaultGui();
			break;
		case MenuWorkshopState.ChangeParts:
			changePartsGui();
			break;
		}
	}
	
	void defaultGui(){
		GUI.Label(posicaoTituloTela,"Workshop",guiSkin.GetStyle("Titulo"));
		GUI.Box(posicaoTituloTela,"",guiSkin.GetStyle("TituloOverlay"));
		
		if( GUI.Button( new Rect(0, 133, 325, 50),"Trocar Partes",guiSkin.GetStyle("Titulo") ) ){
			menuState = MenuWorkshopState.ChangeParts;
		}		
	}
	
	void changePartsGui(){
		GUI.Label(posicaoTituloTela,"Trocar Partes",guiSkin.GetStyle("Titulo"));
		GUI.Box(posicaoTituloTela,"",guiSkin.GetStyle("TituloOverlay"));

		if( GUI.Button( new Rect(0,200,200,50),"Cabeça",guiSkin.GetStyle("Titulo") ) ){
			changePartsState = MenuWorkshopChangePartsState.Head;
		}
		
		if( GUI.Button( new Rect(0,300,200,50),"Corpo",guiSkin.GetStyle("Titulo") ) ){
			changePartsState = MenuWorkshopChangePartsState.Body;
		}
		
		if( GUI.Button( new Rect(0,400,200,50),"Braços",guiSkin.GetStyle("Titulo") ) ){
			changePartsState = MenuWorkshopChangePartsState.Arms;
		}
		
		if( GUI.Button( new Rect(0,500,200,50),"Pernas",guiSkin.GetStyle("Titulo") ) ){
			changePartsState = MenuWorkshopChangePartsState.Legs;
		}
		
		if( GUI.Button( new Rect(0,alturaGUIOriginal -100,200,50),"Voltar",guiSkin.GetStyle("Titulo") ) ){
			menuState = MenuWorkshopState.Default;
		}
		
		
		GUI.Label( new Rect(712, 150, 200, 50), "Stats", guiSkin.GetStyle("Titulo") );
		
		switch(changePartsState){
		case MenuWorkshopChangePartsState.Head:
			changePartsHeadGui();
			break;
		case MenuWorkshopChangePartsState.Body:	
			changePartsBodyGui();
			break;
		case MenuWorkshopChangePartsState.Arms:	
			changePartsArmsGui();
			break;
		case MenuWorkshopChangePartsState.Legs:	
			changePartsLegsGui();
			break;
		}
	}
	
	void changePartsHeadGui(){
		GUI.Label( new Rect(312, 150, 300, 50), "Head Stock", guiSkin.GetStyle("Titulo") );
	}
	
	void changePartsBodyGui(){
		GUI.Label( new Rect(312, 150, 300, 50), "Body Stock", guiSkin.GetStyle("Titulo") );
	}
	
	void changePartsArmsGui(){
		GUI.Label( new Rect(312, 150, 300, 50), "Arms Stoc", guiSkin.GetStyle("Titulo") );
	}
	
	void changePartsLegsGui(){
		GUI.Label( new Rect(312, 150, 300, 50), "Legs Stock", guiSkin.GetStyle("Titulo") );
	}

	void Update () {
	
	}
}
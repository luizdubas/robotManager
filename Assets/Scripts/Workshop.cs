using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	private Rect fullscreen;
	private Player player;
	private MenuWorkshopState menuState;
	private MenuWorkshopChangePartsState changePartsState;
	private GUIStyle selectedBorder;
	
	#endregion
	
	void Start () {
		fullscreen = new Rect(0,0,larguraGUIOriginal,alturaGUIOriginal);
		player = new Player();
		RobotUtility robotUtility = GameObject.Find("RobotUtility").GetComponent<RobotUtility>();
		
		menuState = MenuWorkshopState.Default;
		changePartsState = MenuWorkshopChangePartsState.Head;

		selectedBorder = new GUIStyle();
		selectedBorder.border = new RectOffset( 135, 135, 135, 135 );
		selectedBorder.normal.background = GUIUtil.getBlackTexture();
				
		player.Robo = new Robo();
		player.Stock = new Stock();
		
		player.Robo.HeadPrefabName = "prefabRobot1";
		player.Robo.BodyPrefabName = "prefabRobot1";
		player.Robo.ArmsPrefabName = "prefabRobot1";
		player.Robo.LegsPrefabName = "prefabRobot1";
		
		player.Robo.buildRobot();
		player.Robo.disablePhysics();
		
		player.Robo.RoboGameObject.transform.localScale = new Vector3( 200, 200, 200 );
		player.Robo.RoboGameObject.transform.position = new Vector3(0 , 9.3f, 10);
			
		player.Stock.HeadList = new List<Part>();
		player.Stock.BodyList = new List<Part>();
		player.Stock.ArmsList = new List<Part>();
		player.Stock.LegsList = new List<Part>();
		
		player.Stock.HeadList.Add( player.Robo.HeadPart );
		player.Stock.BodyList.Add( player.Robo.BodyPart );
		player.Stock.ArmsList.Add( player.Robo.ArmsPart );
		player.Stock.LegsList.Add( player.Robo.LegsPart );
		
		player.Stock.HeadList.Add( robotUtility.getPartNewInstance("prefabRobot2", "head") );
		player.Stock.BodyList.Add( robotUtility.getPartNewInstance("prefabRobot2", "body") );
		player.Stock.ArmsList.Add( robotUtility.getPartNewInstance("prefabRobot2", "arms") );
		player.Stock.LegsList.Add( robotUtility.getPartNewInstance("prefabRobot2", "legs") );
		
		player.Stock.HeadList.Add( robotUtility.getPartNewInstance("prefabRobot1", "head") );
		player.Stock.BodyList.Add( robotUtility.getPartNewInstance("prefabRobot1", "body") );
		player.Stock.ArmsList.Add( robotUtility.getPartNewInstance("prefabRobot1", "arms") );
		player.Stock.LegsList.Add( robotUtility.getPartNewInstance("prefabRobot1", "legs") );
		
		player.Stock.HeadList.Add( robotUtility.getPartNewInstance("prefabRobot2", "head") );
		player.Stock.BodyList.Add( robotUtility.getPartNewInstance("prefabRobot2", "body") );
		player.Stock.ArmsList.Add( robotUtility.getPartNewInstance("prefabRobot2", "arms") );
		player.Stock.LegsList.Add( robotUtility.getPartNewInstance("prefabRobot2", "legs") );
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
		GUI.Label( new Rect(222, 150, 300, 50), "Head Stock", guiSkin.GetStyle("Titulo") );
		
		showPartsPreview( player.Stock.HeadList, "head", player.Robo.HeadPart.Id );
	}
	
	void changePartsBodyGui(){
		GUI.Label( new Rect(222, 150, 300, 50), "Body Stock", guiSkin.GetStyle("Titulo") );
		
		showPartsPreview( player.Stock.BodyList, "body", player.Robo.BodyPart.Id );
	}
	
	void changePartsArmsGui(){
		GUI.Label( new Rect(222, 150, 300, 50), "Arms Stoc", guiSkin.GetStyle("Titulo") );
		
		showPartsPreview( player.Stock.ArmsList, "arms", player.Robo.ArmsPart.Id );
	}
	
	void changePartsLegsGui(){
		GUI.Label( new Rect(222, 150, 300, 50), "Legs Stock", guiSkin.GetStyle("Titulo") );
		
		showPartsPreview( player.Stock.LegsList, "legs", player.Robo.LegsPart.Id );
	}
	
	void showPartsPreview( List<Part> partList, string partName, double selectedId ){
		int left = 222,
			top = 250,
			i;
		
		bool more = false;
		
		i = 0;
//		Debug.Log("selected = "+ selectedId );		
		foreach( Part part in partList ){

			if( part.Id == selectedId ){
				GUI.Label( new Rect(left, top, part.textura.width, part.textura.height), part.textura, selectedBorder );
			}else{
				if( GUI.Button( new Rect(left, top, part.textura.width, part.textura.height), part.textura ) ){
					player.Robo.changePart( partName, part );
				}
			}
			
			left += 160;
			
			if( i == 2 ){
				left = 222;
				top += 160;
			}else if ( i == 8 ){
				more = true;
				break;
			}
			
			i++;
		}
		
		if( more ){
			
		}
		
	}

	void Update () {
	
	}
}
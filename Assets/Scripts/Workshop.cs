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
		selectedBorder.border = new RectOffset( 135, 135, 135, 145 );
		
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
		
		if( GUI.Button( new Rect(0, 133, 325, 50),"Change Parts",guiSkin.GetStyle("Titulo") ) ){
			menuState = MenuWorkshopState.ChangeParts;
		}		
	}
	
	
	void changePartsGui(){
		GUI.Label(posicaoTituloTela,"Change Parts",guiSkin.GetStyle("Titulo"));
		GUI.Box(posicaoTituloTela,"",guiSkin.GetStyle("TituloOverlay"));

		if( GUI.Button( new Rect(0,200,200,50),"Head",guiSkin.GetStyle("Titulo") ) ){
			changePartsState = MenuWorkshopChangePartsState.Head;
		}
		
		if( GUI.Button( new Rect(0,300,200,50),"Body",guiSkin.GetStyle("Titulo") ) ){
			changePartsState = MenuWorkshopChangePartsState.Body;
		}
		
		if( GUI.Button( new Rect(0,400,200,50),"Arms",guiSkin.GetStyle("Titulo") ) ){
			changePartsState = MenuWorkshopChangePartsState.Arms;
		}
		
		if( GUI.Button( new Rect(0,500,200,50),"Legs",guiSkin.GetStyle("Titulo") ) ){
			changePartsState = MenuWorkshopChangePartsState.Legs;
		}
		
		if( GUI.Button( new Rect(0,alturaGUIOriginal -100,200,50),"Back",guiSkin.GetStyle("Titulo") ) ){
			menuState = MenuWorkshopState.Default;
		}
		
		changePartsStatsLabelGui();
		
		switch(changePartsState){
		case MenuWorkshopChangePartsState.Head:
			changePartsHeadGui();
			
			changePartsStatsCurrentPartGui( player.Robo.HeadPart );
			break;
		case MenuWorkshopChangePartsState.Body:	
			changePartsBodyGui();
			
			changePartsStatsCurrentPartGui( player.Robo.BodyPart );
			break;
		case MenuWorkshopChangePartsState.Arms:	
			changePartsArmsGui();
			
			changePartsStatsCurrentPartGui( player.Robo.ArmsPart );
			break;
		case MenuWorkshopChangePartsState.Legs:	
			changePartsLegsGui();
			
			changePartsStatsCurrentPartGui( player.Robo.LegsPart );
			break;
		}
	}
	
	void changePartsStatsLabelGui(){
		int left = 700;
		
		GUIStyle skin = new GUIStyle();
		skin.normal.background = GUIUtil.getBlackTexture();
		
		GUI.Box( new Rect(left - 20, 230, 330, 320), "", skin );
	
		GUI.Label( new Rect(left, 150, 200, 50), "Stats", guiSkin.GetStyle("Titulo") );
		
		GUI.Label( new Rect(left, 250, 200, 50), "Name", guiSkin.GetStyle("WorkshopStatsLabel"));
		
		GUI.Label( new Rect(left, 300, 200, 50), "Attack", guiSkin.GetStyle("WorkshopStatsLabel") );
		
		GUI.Label( new Rect(left, 350, 200, 50), "Defense", guiSkin.GetStyle("WorkshopStatsLabel") );
		
		GUI.Label( new Rect(left, 400, 200, 50), "Hp", guiSkin.GetStyle("WorkshopStatsLabel") );
		
		GUI.Label( new Rect(left, 450, 200, 50), "Agility", guiSkin.GetStyle("WorkshopStatsLabel") );
		
		GUI.Label( new Rect(left, 500, 200, 50), "Stamina", guiSkin.GetStyle("WorkshopStatsLabel") );
	}
	
	void changePartsStatsCurrentPartGui( Part currentPart ){
		int left = 790;
		
		GUI.Label( new Rect(left, 250, 200, 50), currentPart.Label, guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 300, 200, 50), currentPart.Attack.ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 350, 200, 50), currentPart.Defense.ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 400, 200, 50), currentPart.Hp.ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 450, 200, 50), currentPart.Agility.ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 500, 200, 50), currentPart.Stamina.ToString(), guiSkin.GetStyle("WorkshopStatsValue")	 );
	}
	
	void changePartsStatsHoverPartGui( Part hoverPart ){
		int left = 880;
				
		GUI.Label( new Rect(left, 250, 200, 50), hoverPart.Label, guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 300, 200, 50), hoverPart.Attack.ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 350, 200, 50), hoverPart.Defense.ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 400, 200, 50), hoverPart.Hp.ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 450, 200, 50), hoverPart.Agility.ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 500, 200, 50), hoverPart.Stamina.ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
	}
	
	void changePartsStatsComparisionPartGui( Part currentPart, Part hoverPart ){
		int left = 970;
		
		GUI.Label( new Rect(left, 300, 200, 50), (currentPart.Attack - hoverPart.Attack).ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 350, 200, 50), (currentPart.Defense - hoverPart.Defense).ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 400, 200, 50), (currentPart.Hp - hoverPart.Hp).ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 450, 200, 50), (currentPart.Agility - hoverPart.Agility).ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
		
		GUI.Label( new Rect(left, 500, 200, 50), (currentPart.Stamina - hoverPart.Stamina).ToString(), guiSkin.GetStyle("WorkshopStatsValue") );
	}
	
	void changePartsHeadGui(){		
		GUI.Label( new Rect(222, 150, 300, 50), "Head Stock", guiSkin.GetStyle("Titulo") );
		
		showPartsPreview( player.Stock.HeadList, "head", player.Robo.HeadPart );
	}
	
	void changePartsBodyGui(){
		GUI.Label( new Rect(222, 150, 300, 50), "Body Stock", guiSkin.GetStyle("Titulo") );
		
		showPartsPreview( player.Stock.BodyList, "body", player.Robo.BodyPart );
	}
	
	void changePartsArmsGui(){
		GUI.Label( new Rect(222, 150, 300, 50), "Arms Stoc", guiSkin.GetStyle("Titulo") );
		
		showPartsPreview( player.Stock.ArmsList, "arms", player.Robo.ArmsPart );
	}
	
	void changePartsLegsGui(){
		GUI.Label( new Rect(222, 150, 300, 50), "Legs Stock", guiSkin.GetStyle("Titulo") );
		
		showPartsPreview( player.Stock.LegsList, "legs", player.Robo.LegsPart );
	}
	
	void showPartsPreview( List<Part> partList, string partName, Part currentPart ){
		int left = 222,
			top = 250,
			i = 0;
		
		Rect partBounds;
		Vector2 mousePosition = new Vector2( Input.mousePosition.x, (Screen.height - Input.mousePosition.y) );
		
		bool more = false;
		
		foreach( Part part in partList ){
			partBounds = new Rect( left, top, part.texture.width / 2, part.texture.height / 2 + 10 );
			
			if( part.Id == currentPart.Id ){
				GUI.Label( partBounds, part.texture, selectedBorder );
			}else{
				if( GUI.Button( partBounds, part.texture ) ){
					player.Robo.changePart( partName, part );
				}
			}
			
			//Cuidado isso nao funciona dentro do editor do Unity.
			if( partBounds.Contains( mousePosition ) ){
				changePartsStatsHoverPartGui( part );
				changePartsStatsComparisionPartGui( currentPart, part );
			}
			
			GUI.Label( new Rect(left + 30, top + 110, part.texture.width / 2, part.texture.height / 2), part.label );
			
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
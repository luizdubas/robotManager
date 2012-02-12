using UnityEngine;
using System.Collections;

public class CreateRobot : MonoBehaviour {
	
	#region Variaveis
	
	public Rect posicaoTituloTela, posicaoLabelNome, posicaoTextNome, posicaoLabelModelo, posicaoRobo, posicaoSetaEsquerda,
		posicaoSetaDireita, posicaoBotaoCriar, posicaoLogoJogo, posicaoInicioAtributoLabel, posicaoInicioAtributoValor, areaDesenho;
	public float larguraGUIOriginal = 0, alturaGUIOriginal = 0;
	public int espacoAtributos = 0,tamanhoNome = 0;
	public GUISkin guiSkin;
	public GameObject[] temp_InitialRobotList;
	private int currentRobot = 0;
	private Rect fullscreen;
	private string RobotName = "No name";
	
	#endregion
	
	void Start () {
		fullscreen = new Rect(0,0,larguraGUIOriginal,alturaGUIOriginal);
	}
	
	void OnGUI(){
		GUI.matrix = Matrix4x4.TRS(new Vector3(0,0,0), Quaternion.identity, new Vector3(Screen.width/larguraGUIOriginal,Screen.height/alturaGUIOriginal,1));
		GUI.depth = 2;
		GUI.Box(fullscreen,"",guiSkin.GetStyle("Background"));
		GUI.Label(posicaoTituloTela,"Create your robot",guiSkin.GetStyle("Titulo"));
		GUI.Box(posicaoTituloTela,"",guiSkin.GetStyle("TituloOverlay"));
		GUI.Label(posicaoLabelModelo,"Model",guiSkin.GetStyle("TituloDireita"));
		GUI.Box(posicaoLabelModelo,"",guiSkin.GetStyle("TituloDireitaOverlay"));
		GUI.Label(posicaoLabelNome,"Name",guiSkin.label);
		GUI.Box(posicaoLabelNome,"",guiSkin.GetStyle("LabelOverlay"));
		RobotName = GUI.TextField(posicaoTextNome,RobotName,tamanhoNome,guiSkin.textField);
		DesenhaAtributos();
		//GUI.Box(posicaoRobo, "",guiSkin.GetStyle("RoboBG"));
		GUI.Box(posicaoRobo, "",guiSkin.GetStyle("RoboOverlay"));
		if(GUI.Button(posicaoSetaEsquerda,"",guiSkin.GetStyle("SetaEsquerda"))){
			ChangeModel(-1);
		}
		if(GUI.Button(posicaoSetaDireita,"",guiSkin.GetStyle("SetaDireita"))){
			ChangeModel(1);
		}
		if(GUI.Button(posicaoBotaoCriar,"Create",guiSkin.GetStyle("BotaoCriar"))){
		}
		GUI.Box(posicaoBotaoCriar,"",guiSkin.GetStyle("BotaoCriarOverlay"));
	}
	
	void DesenhaAtributos(){
		int index = 0;
		DesenhaAtributo("HP","500",index);
		index++;
		DesenhaAtributo("STA","100",index);
		index++;
		DesenhaAtributo("ATK","50",index);
		index++;
		DesenhaAtributo("DEF","50",index);
		index++;
		DesenhaAtributo("ACC","50",index);
		index++;
		DesenhaAtributo("INT","50",index);
		index++;
		DesenhaAtributo("SPD","50",index);
	}
	
	void DesenhaAtributo(string nomeAtributo, string valorAtributo, int indiceAtributo){
		Rect posicaoLabel = new Rect(posicaoInicioAtributoLabel.x,posicaoInicioAtributoLabel.y + (espacoAtributos*indiceAtributo),posicaoInicioAtributoLabel.width, posicaoInicioAtributoLabel.height);
		Rect posicaoValor = new Rect(posicaoInicioAtributoValor.x,posicaoInicioAtributoValor.y + (espacoAtributos*indiceAtributo),posicaoInicioAtributoValor.width, posicaoInicioAtributoValor.height);
		GUI.Label(posicaoLabel,nomeAtributo,guiSkin.label);
		GUI.Box(posicaoLabel,"",guiSkin.GetStyle("LabelOverlay"));
		GUI.Box(posicaoValor,valorAtributo,guiSkin.box);
	}
	
	void ChangeModel(int modifier){
		currentRobot += modifier;
		if(currentRobot < 0) currentRobot = temp_InitialRobotList.Length - 1;
		else if (currentRobot >= temp_InitialRobotList.Length) currentRobot = 0;
		GameObject actual = GameObject.FindWithTag("Player");
		Vector3 pos = actual.transform.position;
		Quaternion rot = actual.transform.rotation;
		GameObject newObject = (GameObject) GameObject.Instantiate(temp_InitialRobotList[currentRobot],pos,rot);
		newObject.transform.localScale = new Vector3(9*1.5f,9*1.5f,9*1.5f);
		newObject.tag = actual.tag;
		GameObject.DestroyImmediate(GameObject.FindWithTag("Player"));
		newObject.transform.parent = GameObject.FindWithTag("RobotHolder").transform;
	}

	void Update () {
	
	}
}

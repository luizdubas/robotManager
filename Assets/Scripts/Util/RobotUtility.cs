using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RobotUtility : MonoBehaviour {
	
	public static int contador = 1;
	
	public GameObject prefabRobot1;
	public GameObject prefabRobot2;
	/** Colocar aki todos os prefabs dos robos **/
	
	public GameObject getGameObjectByName(string nome){
		GameObject retorno = null;
		if( nome == "prefabRobot1" ){
			retorno = prefabRobot1;
		}else if( nome == "prefabRobot2" ){
			retorno = prefabRobot2;
		}
		
		return retorno;
	}
	
	public string getNameByGameObject(GameObject go){
		string retorno = null;
		if( go == prefabRobot1 ){
			retorno = "prefabRobot1";
		}else if( go == prefabRobot2 ){
			retorno = "prefabRobot2";
		}
		
		return retorno;
	}
	
	/** Caso nao seja escolhido o prefab do armature ele usa o do body **/
	public GameObject criarRobo( GameObject headPrefab, GameObject bodyPrefab, GameObject armsPrefab, GameObject legsPrefab ){
		return criarRobo( bodyPrefab,  headPrefab, bodyPrefab, armsPrefab, legsPrefab );
	}
	
	public GameObject criarRobo( GameObject armaturePrefab, GameObject headPrefab, GameObject bodyPrefab, GameObject armsPrefab, GameObject legsPrefab ){
		return criarRobo( armaturePrefab,  headPrefab, bodyPrefab, armsPrefab, legsPrefab, "Robo" );
	}
		
	public GameObject criarRobo( GameObject armaturePrefab, GameObject headPrefab, GameObject bodyPrefab, GameObject armsPrefab, GameObject legsPrefab, string scriptName ){
		GameObject newRobot, oldPart, newPart;
		Part part;
		BoxCollider collider;
		Rigidbody rigidbody;
		Transform armature;
	
		armature = null;
		oldPart = newPart = null;
		
		Debug.Log("Instanciando novo robo a partir do prefab: "+armaturePrefab.name);
		newRobot = (GameObject) Instantiate( armaturePrefab );		
		newRobot.name = "newRobot";
		
		collider = newRobot.AddComponent<BoxCollider>();
		rigidbody = newRobot.AddComponent<Rigidbody>();
		newRobot.AddComponent( scriptName );		
		
		Debug.Log("\tProcurando armature do prefab...");
		armature = procuraObjetoEmUmaObjetoInstanciado( "Armature", newRobot.transform ).transform;
		
		Debug.Log("\tContruindo Head: "+headPrefab.name );
		if( headPrefab != armaturePrefab ){
			oldPart = procuraObjetoEmUmaObjetoInstanciado( "head", newRobot.transform );
			newPart = procuraObjetoEmUmaPrefab( "head", headPrefab );
			
			changePart( oldPart, newPart, newRobot );
		}
		
		part = procuraObjetoEmUmaObjetoInstanciado( "head", newRobot.transform ).GetComponent<Part>();
		part.PartType = "head";
		part.PrefabName = getNameByGameObject( headPrefab );
		part.Id = RobotUtility.contador++;
		
		Debug.Log("\tContruindo Body: "+bodyPrefab.name);
		if( bodyPrefab != armaturePrefab ){
			oldPart = procuraObjetoEmUmaObjetoInstanciado( "body", newRobot.transform );
			newPart = procuraObjetoEmUmaPrefab( "body", bodyPrefab );

			changePart( oldPart, newPart, newRobot );
		}
		
		part = procuraObjetoEmUmaObjetoInstanciado( "body", newRobot.transform ).GetComponent<Part>();
		part.PartType = "body";
		part.PrefabName = getNameByGameObject( bodyPrefab );
		part.Id = RobotUtility.contador++;
		
		Debug.Log("\tContruindo Arms: "+armsPrefab.name);		
		if( armsPrefab != armaturePrefab ){
			oldPart = procuraObjetoEmUmaObjetoInstanciado( "arms", newRobot.transform );
			newPart = procuraObjetoEmUmaPrefab( "arms", armsPrefab );

			changePart( oldPart, newPart, newRobot );
		}
		
		part = procuraObjetoEmUmaObjetoInstanciado( "arms", newRobot.transform ).GetComponent<Part>();
		part.PartType = "arms";
		part.PrefabName = getNameByGameObject( armsPrefab );
		part.Id = RobotUtility.contador++;
		
		Debug.Log("\tContruindo legs: "+legsPrefab.name);
		if( legsPrefab != armaturePrefab ){
			oldPart = procuraObjetoEmUmaObjetoInstanciado( "legs", newRobot.transform );
			newPart = procuraObjetoEmUmaPrefab( "legs", legsPrefab );

			changePart( oldPart, newPart, newRobot );
		}
		
		part = procuraObjetoEmUmaObjetoInstanciado( "legs", newRobot.transform ).GetComponent<Part>();
		part.PartType = "legs";
		part.PrefabName = getNameByGameObject( legsPrefab );
		part.Id = RobotUtility.contador++;
		
		Debug.Log("\tContruindo Fisica");
		//collider.center = new Vector3( 0, 0 , -1 );
		collider.size = new Vector3( 0.1F, 0.1F, 0.1F	 );
		
		rigidbody.mass = 100;
		rigidbody.freezeRotation = true;
		
		Robo robo = new Robo();
	
		return newRobot;
	}
	
	public GameObject changePart( GameObject oldGameObject, Part newPart, GameObject newRobot ){
		Part clonedNewPart;
				
		GameObject newGameObject = procuraObjetoEmUmaPrefab( newPart.PartType, getGameObjectByName( newPart.PrefabName ) );
		
		newGameObject = changePart( oldGameObject, newGameObject, newRobot );
		
		newGameObject.name = newGameObject.name.Replace("(Clone)", "");
		
		clonedNewPart = newGameObject.GetComponent<Part>();
		
		clonedNewPart.PartType = newPart.PartType;
		clonedNewPart.PrefabName = newPart.PrefabName;
		clonedNewPart.Id = newPart.Id;
		
		return newGameObject;
	}
	
	
	public GameObject changePart( GameObject oldGameObject, GameObject newGameObject, GameObject newRobot ){
		copyBones( oldGameObject, newGameObject );
		
		newGameObject.transform.position = oldGameObject.transform.position; 
		
		Destroy( oldGameObject );
		
		newGameObject.transform.parent = newRobot.transform;
		
		return newGameObject;
	}
	
	private GameObject procuraObjetoEmUmaObjetoInstanciado( string nomeDoObjeto, Transform armature ){
		GameObject returnObject = null;
		
		foreach( Transform oldPartTransform in armature.GetComponentsInChildren<Transform>() ){
			if( oldPartTransform.name.Contains( nomeDoObjeto ) ){
				returnObject = oldPartTransform.gameObject;
				break;
			}
		}
		
		return returnObject;
	}
	
	private GameObject procuraObjetoEmUmaPrefab( string nomeDoObjeto, GameObject prefab ){
		GameObject returnObject = null;
		
		Transform armatureTransform, partTransform, transform;
		int childCount, armatureChildCount;
		
		transform  = prefab.GetComponent<Transform>();
		childCount = transform.GetChildCount();

		for( int i = 0; i < childCount; i++ ){
			partTransform = transform.GetChild( i );
			if( partTransform.name.Contains( nomeDoObjeto ) ){
				returnObject = (GameObject) Instantiate( partTransform.gameObject );
				break;
			}
		}
		
		return returnObject;
	}
	
	private void copyBones( GameObject fromPart, GameObject destinyPart) {
		SkinnedMeshRenderer oldMeshRenderer, newMeshRenderer;
		
		oldMeshRenderer = fromPart.transform.GetComponent<SkinnedMeshRenderer>();
		newMeshRenderer = destinyPart.transform.GetComponent<SkinnedMeshRenderer>();
		
		newMeshRenderer.bones = oldMeshRenderer.bones;
	}
	
	public Part getPartNewInstance( string prefabName, string partName ){	
		Part newPart = getGameObjectByName( prefabName ).transform.Find( partName ).GetComponent<Part>().clone();
		
		newPart.PartType = partName;
		newPart.PrefabName = prefabName;
		
		//Aqui vai ter que pegar do banco quando for multiplayer
		newPart.Id = RobotUtility.contador++;
		
		return newPart;
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RobotUtility : MonoBehaviour {
	
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
	
	/** Caso nao seja escolhido o prefab do armature ele usa o do body **/
	public GameObject criarRobo( GameObject headPrefab, GameObject bodyPrefab, GameObject armsPrefab, GameObject legsPrefab ){
		return criarRobo( bodyPrefab,  headPrefab, bodyPrefab, armsPrefab, legsPrefab );
	}
	
	public GameObject criarRobo( GameObject armaturePrefab, GameObject headPrefab, GameObject bodyPrefab, GameObject armsPrefab, GameObject legsPrefab ){
		return criarRobo( armaturePrefab,  headPrefab, bodyPrefab, armsPrefab, legsPrefab, "Robo" );
	}
		
	public GameObject criarRobo( GameObject armaturePrefab, GameObject headPrefab, GameObject bodyPrefab, GameObject armsPrefab, GameObject legsPrefab, string scriptName ){
		GameObject newRobot, oldPart, newPart;
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
			
			copyBones( oldPart, newPart );
			
			newPart.transform.position = oldPart.transform.position; 
			
			Destroy( oldPart );
			
			newPart.transform.parent = newRobot.transform;
		}
		
		Debug.Log("\tContruindo Body: "+bodyPrefab.name);
		if( bodyPrefab != armaturePrefab ){
			oldPart = procuraObjetoEmUmaObjetoInstanciado( "body", newRobot.transform );
			newPart = procuraObjetoEmUmaPrefab( "body", bodyPrefab );

			copyBones( oldPart, newPart );
			
			newPart.transform.position = oldPart.transform.position; 
			
			Destroy( oldPart );
			
			newPart.transform.parent = newRobot.transform;
		}
		
		Debug.Log("\tContruindo Arms: "+armsPrefab.name);		
		if( armsPrefab != armaturePrefab ){
			oldPart = procuraObjetoEmUmaObjetoInstanciado( "arms", newRobot.transform );
			newPart = procuraObjetoEmUmaPrefab( "arms", armsPrefab );

			copyBones( oldPart, newPart );
			
			newPart.transform.position = oldPart.transform.position; 
			
			Destroy( oldPart );
			
			newPart.transform.parent = newRobot.transform;
		}
		
		Debug.Log("\tContruindo legs: "+legsPrefab.name);
		if( legsPrefab != armaturePrefab ){
			oldPart = procuraObjetoEmUmaObjetoInstanciado( "legs", newRobot.transform );
			newPart = procuraObjetoEmUmaPrefab( "legs", legsPrefab );

			copyBones( oldPart, newPart );
			
			newPart.transform.position = oldPart.transform.position; 
			
			Destroy( oldPart );
			
			newPart.transform.parent = newRobot.transform;
		}
		
		
		Debug.Log("\tContruindo Fisica");
		//collider.center = new Vector3( 0, 0 , -1 );
		collider.size = new Vector3( 0.1F, 0.1F, 0.1F	 );
		
		rigidbody.mass = 100;
		rigidbody.freezeRotation = true;
		
		Robo robo = new Robo();
	
		return newRobot;
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
}
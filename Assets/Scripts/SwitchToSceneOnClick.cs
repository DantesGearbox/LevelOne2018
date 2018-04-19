using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToSceneOnClick : MonoBehaviour {

	public string sceneToLoad;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Mouse0) || Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Return)){
			SceneManager.LoadScene (sceneToLoad);
		}
	}
}

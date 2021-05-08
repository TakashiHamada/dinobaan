using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButtonManager : MonoBehaviour {
	[SerializeField] bool m_used_as_back_to_capture = false;
	void Awake () {
		Debug.Log("E:previous_scene" + Session.Scene.previous_scene);
		if(m_used_as_back_to_capture)
			gameObject.SetActive(Session.Scene.previous_scene == "Capture");
	}
	public void Return () {
		SceneLoader scene_loader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneLoader>();
		scene_loader.LoadScene(GetTargetScene(scene_loader.GetCurrentScene()));
	}
	private string GetTargetScene (string current_scene) {
		switch (current_scene) {
			case "Capture" : return "Title";
			case "Collection" : return "Title";
			case "Detail" : return "Collection";
			case "Setting" : return "Title";
		}
		return "Title";
	}
	public void LoadCaptureScene () {
		SceneLoader scene_loader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneLoader>();
		scene_loader.LoadScene("Capture");
	}
}

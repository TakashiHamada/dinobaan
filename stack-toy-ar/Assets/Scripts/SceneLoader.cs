using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour {
	void Awake () {
		SceneManager.LoadScene("_Initialize", LoadSceneMode.Additive);
	}
	public void LoadScene(string scene) {
		// SE
		var se = GameObject.Find("SoundBox");
		se.SendMessage("PlaySeButtonDown");
		// 保存してから遷移
		Session.Scene.previous_scene = GetCurrentScene();
		SceneManager.LoadScene(scene);
	}
	public string GetCurrentScene () {
		return SceneManager.GetActiveScene().name;
	}
}
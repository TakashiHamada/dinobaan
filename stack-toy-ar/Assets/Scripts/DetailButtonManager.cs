using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailButtonManager : MonoBehaviour {
	public void LoadDetailScene () {
        SceneLoader scene_loader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneLoader>();
		scene_loader.LoadScene("Detail");
    }
}

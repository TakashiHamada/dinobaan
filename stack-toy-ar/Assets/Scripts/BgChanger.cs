using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgChanger : MonoBehaviour {
	[SerializeField] private Sprite[] images;
	void Start () {
		int id = Session.Scene.selected_dino_collection_id;
		if(id < 0) id = 0;
		Debug.Log("E:dino_bg = " + Define.Dino.type[id]);
		if(Session.Dino.captured_array[id]) {
			GetComponent<Image>().sprite = images[Define.Dino.type[id]];
			GetComponent<Image>().type = Image.Type.Simple;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HintGenerator : MonoBehaviour {
	[SerializeField] private GameObject m_white;
	[SerializeField] private GameObject m_black;
	void Start () {
		int dino_id = Session.Scene.selected_dino_collection_id;

		// デバック時のエラー回避　ゲーム中は起き得ない
		if(dino_id < 0) dino_id = 0;

		string hint_data = Define.Hint.list[dino_id];
		for(int id = 0; id < 25; id++) {
			Instantiate(hint_data.Substring(id, 1) == "_" ? m_white : m_black, transform);
		}
	}
}

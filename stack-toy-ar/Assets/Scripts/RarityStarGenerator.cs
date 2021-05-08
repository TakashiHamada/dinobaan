using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RarityStarGenerator : MonoBehaviour {
	[SerializeField] GameObject _star;
	void Start () {
		int id = Session.Scene.selected_dino_collection_id;
		if(id == -1) return;
		if(Session.Dino.captured_array[id]) {
			int addtional_star = GetRankString(Define.Dino.siblings[id]);
			for(id = 0; id < addtional_star; id++) {
				Instantiate(_star, transform);
			}
		} else {
			// まだ捕まえていない
			Destroy(_star);
		}
	}
	private int GetRankString (int siblings) {
		if(siblings < 10) return 3;
		else if(siblings < 20) return 2;
		else if(siblings < 30) return 1;
		else return 0;
	}
}

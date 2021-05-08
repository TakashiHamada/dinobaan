using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPosKeeper : MonoBehaviour {
	private RectTransform _rect;
	private Vector3 _init_pos;
	void Start () {
		_rect = GetComponent<RectTransform>();
		_init_pos = _rect.position;
		_rect.position = new Vector3(_init_pos.x, Session.Scene.collection_scroll_pos_y, _init_pos.z);
	}
	void Update () {
		Session.Scene.collection_scroll_pos_y = _rect.position.y;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbnailGenerator : MonoBehaviour {
	[SerializeField] private GameObject m_thumbnail;
	private List<GameObject> m_list;
	void Start () {
		m_list = new List<GameObject>();
		for(int id = 0; id < 33; id++) {
			var obj = Instantiate(m_thumbnail, transform);
			obj.GetComponent<ThumbnailManager>().Initialize(id, Session.Dino.IsCaptured(id));
			m_list.Add(obj);
		}
	}
}

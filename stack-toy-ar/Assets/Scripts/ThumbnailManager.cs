using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThumbnailManager : MonoBehaviour {
	[SerializeField] private int m_id = -1;
	[SerializeField] private GameObject m_silhouette;
	[SerializeField] private GameObject m_captured;
	[SerializeField] private TextMeshProUGUI m_dino_name;
	private bool m_is_captured = false;
	public void Initialize (int id, bool is_captured) {
		m_id = id;
		m_is_captured = is_captured;
		UpdateImage();
		m_dino_name.text = Session.Dino.captured_array[id] ? GetDino(Session.Lang.selected_lang)[m_id] : "?";
	}
	private void UpdateImage () {
		m_silhouette.SetActive(!m_is_captured);
		m_captured.SetActive(m_is_captured);
		if(m_is_captured) {
			Texture2D texture = Resources.Load("DinoCaptured/Cap" + Define.Dino.name[m_id]) as Texture2D;
			m_captured.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
		} else {
			Texture2D texture = Resources.Load("DinoSilhouette/Sil" + Define.Dino.name[m_id]) as Texture2D;
			m_silhouette.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
		}
	}
	public void LoadCollectionDetail () {
		Session.Scene.selected_dino_collection_id = m_id;
		GameObject.FindGameObjectWithTag("GameController").SendMessage("LoadScene", "Detail");
	}
	private string[] GetDino (Define.System.Lang lang) {
		switch(lang) {
			case Define.System.Lang.ja : return GameText.Dino.ja;
			case Define.System.Lang.en : return GameText.Dino.en;
			case Define.System.Lang.zh_CN : return GameText.Dino.zh_CN;
			case Define.System.Lang.zh_TW : return GameText.Dino.zh_TW;
			default : return GameText.Dino.en;
		}
	}
}

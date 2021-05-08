using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SceneMangers {
	public class Detail : MonoBehaviour {
		[SerializeField] private GameObject _btn_capture;
		[SerializeField] private GameObject _dino_point;
		[SerializeField] private GameObject _dino_description;
		[SerializeField] private GameObject _hint;
		[SerializeField] private GameObject _dino_title;
		[SerializeField] private GameObject _dino_age;
		[SerializeField] private GameObject _dino_length;
		void Start () {

			int id = Session.Scene.selected_dino_collection_id;
			Debug.Log("E:selected dino is " + id);
			// 文字削除
			_dino_age.GetComponent<TextMeshProUGUI>().text = "";
			_dino_length.GetComponent<TextMeshProUGUI>().text = "";
			
			// デバック時のエラー回避　ゲーム中は起き得ない
			if(id < 0) id = 0;

			// for(int i = 0; i < 33; i++) {
			// 	Debug.Log("E:" + Session.Dino.IsCaptured(i));
			// }

			// ヒントで表示
			_btn_capture.SetActive(!Session.Dino.IsCaptured(id));
			_hint.SetActive(!Session.Dino.IsCaptured(id));
			// 図鑑で表示
			// m_dino_description.SetActive(true);
			_dino_description.GetComponent<TextMeshProUGUI>().text = GetDinoDescription(Session.Lang.selected_lang)[id];
			_dino_description.SetActive(Session.Dino.IsCaptured(id));

			if(Session.Lang.selected_lang == Define.System.Lang.en)
				_dino_description.GetComponent<TextMeshProUGUI>().lineSpacing = -5f;

			if(Session.Lang.selected_lang == Define.System.Lang.zh_CN ||
			Session.Lang.selected_lang == Define.System.Lang.zh_TW)
				_dino_description.GetComponent<TextMeshProUGUI>().fontSize = 80f;

			if(Session.Dino.IsCaptured(id)) {
				// 図鑑
				PlayDinoVoice(Define.Dino.name[id]);
				_dino_point.SendMessage("SummonDino", id);
				_dino_description.GetComponent<TextMeshProUGUI>().text = GetDinoDescription(Session.Lang.selected_lang)[id];
				_dino_title.GetComponent<TextMeshProUGUI>().text = GetDino(Session.Lang.selected_lang)[id];
				_dino_age.GetComponent<TextMeshProUGUI>().text = GetDinoAge(Session.Lang.selected_lang)[id];
				_dino_length.GetComponent<TextMeshProUGUI>().text = GameText.DinoLength.ja[id];
			}
			else {
				// ヒント
				_dino_title.GetComponent<TextMeshProUGUI>().text = "???";
			}
		}
		private void PlayDinoVoice (string name ) {
			if(!GetComponent<AudioSource>().isPlaying) {
				GetComponent<AudioSource>().clip = Resources.Load("Sounds/" + name) as AudioClip;
				GetComponent<AudioSource>().Play();
			}
		}
		// TODO後で整理
		private string[] GetDinoDescription (Define.System.Lang lang) {
			switch(lang) {
				case Define.System.Lang.ja : return GameText.DinoDescription.ja;
				case Define.System.Lang.en : return GameText.DinoDescription.en;
				case Define.System.Lang.zh_CN : return GameText.DinoDescription.zh_CN;
				case Define.System.Lang.zh_TW : return GameText.DinoDescription.zh_TW;
				default : return GameText.DinoDescription.en;
			}
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
		private string[] GetDinoAge (Define.System.Lang lang) {
			switch(lang) {
				case Define.System.Lang.ja : return GameText.DinoAge.ja;
				case Define.System.Lang.en : return GameText.DinoAge.en;
				case Define.System.Lang.zh_CN : return GameText.DinoAge.zh_CN;
				case Define.System.Lang.zh_TW : return GameText.DinoAge.zh_TW;
				default : return GameText.DinoAge.en;
			}
		}
	}
}
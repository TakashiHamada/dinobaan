using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SummonEffectManager : MonoBehaviour {
	private int disconnect_count = 0;
	private bool is_ready = true;
	[SerializeField] private DinoPicManager dino_pic_manager;
	[SerializeField] private GameObject effect_appearance;
	[SerializeField] private TextMeshProUGUI m_dino_name;
	[SerializeField] private GameObject captured_elements;
	[SerializeField] private GameObject guide_text;
	private bool is_dino_appeared = false;
	void Awake () {
		captured_elements.SetActive(false);
	}
	public void ShowSummonOnceEffect (int id) {
		guide_text.SetActive(false);
		StartCoroutine("WaitSummonOnceEffect", id);
	}
	public void SetDinoAppeared () {
		if(is_dino_appeared) SceneManager.LoadScene("Capture");
		is_dino_appeared = true;
	}
	IEnumerator WaitSummonOnceEffect (int id) {
		Instantiate(effect_appearance);
		yield return new WaitForSeconds(1f);
		dino_pic_manager.Show(Define.Dino.name[id]);
		Activate(id);
		yield return new WaitForSeconds(2.0f);
		// ボタン等を表示　同じシーンで消えない
		captured_elements.SetActive(true);
	}
	public void Activate (int id) {
		if(is_ready) {
			ShowDinoName(Define.Dino.name[id]);
			PlayDinoVoice(Define.Dino.name[id]);
		}
		disconnect_count = 0;
		is_ready = false;
	}
	private void ShowDinoName (string name = "") {
		m_dino_name.text = name == "" ? "" : GetComponent<DinoNameManager>().GetDinoNameByLanguages(name, Session.Lang.selected_lang);
	}
	private void PlayDinoVoice (string name ) {
		if(!GetComponent<AudioSource>().isPlaying) {
			GetComponent<AudioSource>().clip = Resources.Load("Sounds/" + name) as AudioClip;
			GetComponent<AudioSource>().Play();
		}
	}
	void Update () {
		disconnect_count ++;
		if(disconnect_count > Define.Param.DINO_LIFE) {
			m_dino_name.text = "";
			is_ready = true;
		}
	}
}

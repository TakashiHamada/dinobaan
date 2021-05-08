using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTextLoader : MonoBehaviour {
	[SerializeField] private int m_order = -1;
	void Start () {
		if(m_order == -1) {
			Debug.LogError("TEXT -1");
			return;
		}
		if(!GetComponent<TextMeshProUGUI>()) {
			Debug.LogError(gameObject.name);
		}
		GetComponent<TextMeshProUGUI>().text =
		Session.Lang.selected_lang == Define.System.Lang.ja ? GameText.Info.ja[m_order]:
		Session.Lang.selected_lang == Define.System.Lang.en ? GameText.Info.en[m_order]:
		Session.Lang.selected_lang == Define.System.Lang.zh_CN ? GameText.Info.zh_CN[m_order]:
		GameText.Info.zh_TW[m_order];
	}
}

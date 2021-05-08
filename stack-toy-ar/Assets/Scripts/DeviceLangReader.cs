using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceLangReader : MonoBehaviour {
	void Awake () {
		Session.Lang.selected_lang =
		Application.systemLanguage == SystemLanguage.Japanese ? Define.System.Lang.ja ://ja
		Application.systemLanguage == SystemLanguage.English ? Define.System.Lang.en :
		Application.systemLanguage == SystemLanguage.ChineseSimplified ? Define.System.Lang.zh_CN :
		Application.systemLanguage == SystemLanguage.ChineseTraditional ? Define.System.Lang.zh_TW :
		Define.System.Lang.en;
		Debug.Log(Session.Lang.selected_lang);
	}
}

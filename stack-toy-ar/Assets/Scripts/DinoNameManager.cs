using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoNameManager : MonoBehaviour {
	public string GetDinoNameByLanguages (string name, Define.System.Lang lang) {
		string[] name_list = GetDinoNameList(lang);
		for(int id = 0; id < Define.Dino.name.Length; id++) {
			if(Define.Dino.name[id] == name) return name_list[id];
		}
		return "???";
	}
	private string[] GetDinoNameList (Define.System.Lang lang) {
		switch(lang) {
			case Define.System.Lang.ja : return GameText.Dino.ja;
			case Define.System.Lang.en : return GameText.Dino.en;
			case Define.System.Lang.zh_CN : return GameText.Dino.zh_CN;
			case Define.System.Lang.zh_TW : return GameText.Dino.zh_TW;
			default : return GameText.Dino.en;
		}
	}
}

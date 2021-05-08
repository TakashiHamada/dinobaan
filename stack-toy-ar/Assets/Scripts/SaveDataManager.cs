using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour {
	void Awake () {
		// DontDestroyOnLoad( this.gameObject);
		// load data
		string captured_array_string = PlayerPrefs.GetString("captured_array");
		if(captured_array_string == "")
			for(int id = 0; id < 33; id++) captured_array_string += "_";
		Session.Dino.captured_array = ConvertFromStringToBoolArray(captured_array_string);

		string badges_array_string = PlayerPrefs.GetString("is_badges_displayed_array");
		if(badges_array_string == "")
			for(int id = 0; id < 5; id++) badges_array_string += "_";
		Session.Scene.is_badges_displayed_array = ConvertFromStringToBoolArray(badges_array_string);
	}
	public void CapturedDino (int id) {
		Debug.Log("E:capture = " + id);
		Session.Dino.captured_array[id] = true;
		// save data
		PlayerPrefs.SetString("captured_array", ConvertFromBoolArrayToString(Session.Dino.captured_array));
	}
	public void ReleaseDino (int id) {
		Debug.Log("E:release = " + id);
		Session.Dino.captured_array[id] = false;
		// save data
		PlayerPrefs.SetString("captured_array", ConvertFromBoolArrayToString(Session.Dino.captured_array));
	}
	public void BadgeDisplayed (int id) {
		Session.Scene.is_badges_displayed_array[id] = true;
		PlayerPrefs.SetString("is_badges_displayed_array", ConvertFromBoolArrayToString(Session.Scene.is_badges_displayed_array));
	}
	private string ConvertFromBoolArrayToString (bool[] array) {
		string store = "";
		foreach (bool f in array)
			store += f ? "#" : "_";
		return store;
	}
	private bool[] ConvertFromStringToBoolArray (string text) {
		bool[] store = new bool[text.Length];
		for(int id = 0; id < text.Length; id++) {
			store[id] = text.Substring(id, 1) == "#";
		}
		return store;
	}
}
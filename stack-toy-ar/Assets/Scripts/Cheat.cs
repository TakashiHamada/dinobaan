using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour {
	public void AllDinoChaptured () {
		SaveDataManager save_data = GameObject.FindWithTag("SaveDataManager").GetComponent<SaveDataManager>();
		for(int id = 0; id < 33; id++) save_data.CapturedDino(id);
		Debug.Log("E:AllDinoChaptured");
	}
	public void AllDinoReleased () {
		SaveDataManager save_data = GameObject.FindWithTag("SaveDataManager").GetComponent<SaveDataManager>();
		for(int id = 0; id < 33; id++) save_data.ReleaseDino(id);
		Debug.Log("E:AllDinoReleased");
	}
}

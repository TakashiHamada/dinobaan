using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturedDinoGenerator : MonoBehaviour {
	public void SummonDino (int id) {
		var dino = Instantiate(Resources.Load("Dino/" + Define.Dino.name[id]), transform) as GameObject;
		dino.SetActive(true);
	}
}

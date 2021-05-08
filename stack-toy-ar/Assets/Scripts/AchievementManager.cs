using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour {
	void Start () {
		int badge_number = GetBadgeNumber();
		if(badge_number == -1) {
			gameObject.SetActive(false);
			return;
		}
		if(!Session.Scene.is_badges_displayed_array[badge_number]) {
			var save_data_manager = GameObject.FindGameObjectWithTag("SaveDataManager").GetComponent<SaveDataManager>();
			save_data_manager.BadgeDisplayed(badge_number);
		} else gameObject.SetActive(false);
	}
	private int GetBadgeNumber () {
		int count = Session.Dino.CountCapturedDino();
		if (count == 33) return 4;
		if (count >= 30) return 3;
		if (count >= 20) return 2;
		if (count >= 10) return 1;
		if (count >= 1 ) return 0;
		return -1;
	}
}

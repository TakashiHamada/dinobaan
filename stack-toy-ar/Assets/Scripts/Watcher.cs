using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uween;
using System.Linq;

public class Watcher : MonoBehaviour {
	[SerializeField] GameObject target;
	[SerializeField] GameObject child;
	[SerializeField] GameObject text;
	private AudioSource audio_source;
	private int life_count = 50;
	private bool is_active = false;
	private List<float> position_strage_x = new List<float>();
	private List<float> position_strage_y = new List<float>();
	private List<float> position_strage_z = new List<float>();
	private List<float> rotation_strage_x = new List<float>();
	private List<float> rotation_strage_y = new List<float>();
	private List<float> rotation_strage_z = new List<float>();
	private List<float> rotation_strage_w = new List<float>();
	void Start() {
		text.SetActive(false);
		audio_source = GetComponent<AudioSource>();
	}
	private float GetAverageFromList(List<float> list, float new_float) {
		list.Add(new_float);
        if (list.Count > 3) list.RemoveAt(0);
        return list.Average();
	}
	private Vector3 GetFilteredPosition () {
		return new Vector3(
			GetAverageFromList(position_strage_x, target.transform.position.x),
			GetAverageFromList(position_strage_y, target.transform.position.y),
			GetAverageFromList(position_strage_z, target.transform.position.z));
	}
	private Quaternion GetFilteredRotation () {
		return new Quaternion(
			GetAverageFromList(rotation_strage_x, target.transform.rotation.x),
			GetAverageFromList(rotation_strage_y, target.transform.rotation.y),
			GetAverageFromList(rotation_strage_z, target.transform.rotation.z),
			GetAverageFromList(rotation_strage_w, target.transform.rotation.w));
	}
	private void ShowModel () {
		child.SetActive(true);
		is_active = true;
		TweenSXYZ.Add(child, 0.8f, 1f).From(0f).EaseOutCircular();
		text.SetActive(true);
		audio_source.Play();
	}
	void Update () {
		if(target.active) {
			if(!is_active) ShowModel();
			life_count = 50;
			child.transform.position = GetFilteredPosition();
			child.transform.rotation = GetFilteredRotation();
		} else {
			life_count--;
			if(life_count == 0) {
				child.SetActive(false);
			} else if (life_count == 30) {
				TweenSXYZ.Add(child, 1f, 0f).EaseOutCircular();
				is_active = false;
				text.SetActive(false);
			}
		}
	}
}

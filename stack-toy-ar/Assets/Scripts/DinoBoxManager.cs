using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DinoBoxManager : MonoBehaviour {
	[SerializeField] private GameObject model_base;
	[SerializeField] private GameObject lower_model_base;
	[SerializeField] private GameObject effect_disappearance;
	[SerializeField] private GameObject shadow;
	private GameObject target_model;
	private Transform ar_base;
	private int life_count = -1;
	private List<float> position_strage_x = new List<float>();
	private List<float> position_strage_y = new List<float>();
	private List<float> position_strage_z = new List<float>();
	private List<float> rotation_strage_x = new List<float>();
	private List<float> rotation_strage_y = new List<float>();
	private List<float> rotation_strage_z = new List<float>();
	private List<float> rotation_strage_w = new List<float>();
	void Start () {
		life_count = Define.Param.DINO_LIFE;
	}
	public void InstantiateDino (Transform obj, int id) {
		ar_base = obj;
		shadow.SetActive(true);
		Destroy(target_model);
		target_model = Instantiate(Resources.Load("Dino/" + Define.Dino.name[id])) as GameObject;
		target_model.transform.parent = lower_model_base.transform;
		target_model.transform.position = model_base.transform.position;
		target_model.transform.rotation = model_base.transform.rotation;
		target_model.transform.Rotate(Vector3.right, 90);
		// 捕獲を保存
		var save_data_manager = GameObject.FindGameObjectWithTag("SaveDataManager").GetComponent<SaveDataManager>();
		save_data_manager.CapturedDino(id);
		// Session
		Session.Scene.selected_dino_collection_id = id;
	}
	public void UpdateDino (Transform obj) {
		if(!target_model) return;
		target_model.SetActive(true);
		model_base.transform.position = GetFilteredPosition();
		model_base.transform.rotation = GetFilteredRotation();
		life_count = Define.Param.DINO_LIFE;
	}
	private float GetAverageFromList(List<float> list, float new_float) {
		list.Add(new_float);
        if (list.Count > 4) list.RemoveAt(0);
        return list.Average();
	}
	private Vector3 GetFilteredPosition () {
		return new Vector3(
			GetAverageFromList(position_strage_x, ar_base.position.x),
			GetAverageFromList(position_strage_y, ar_base.position.y),
			GetAverageFromList(position_strage_z, ar_base.position.z));
	}
	private Quaternion GetFilteredRotation () {
		return new Quaternion(
			GetAverageFromList(rotation_strage_x, ar_base.rotation.x),
			GetAverageFromList(rotation_strage_y, ar_base.rotation.y),
			GetAverageFromList(rotation_strage_z, ar_base.rotation.z),
			GetAverageFromList(rotation_strage_w, ar_base.rotation.w));
	}
	void Update () {
		life_count --;
		// 削除
		if(life_count == 0) {
			if(target_model) {
				shadow.SetActive(false);
				target_model.SetActive(false);
				Destroy(Instantiate(effect_disappearance, model_base.transform.position ,Quaternion.identity), 1f);
			}
		}
	}
}

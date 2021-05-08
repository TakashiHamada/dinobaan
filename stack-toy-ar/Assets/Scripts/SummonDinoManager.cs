using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonDinoManager : MonoBehaviour {
	public int id = -1;
	private DinoBoxManager dino_box_manager;
	private SummonEffectManager summon_effect_manager;
	private enum State {
		not_yet,
		summon_once_play,
		summon_once_end
	}
	private State state = State.not_yet;
	[SerializeField] private GameObject target;
	void Start () {
		dino_box_manager = (GameObject.FindWithTag("DinoBox") as GameObject).GetComponent<DinoBoxManager>();
		summon_effect_manager = (GameObject.FindWithTag("SummonEffect") as GameObject).GetComponent<SummonEffectManager>();
	}
	void Update () {
		if(Time.time < 0.5f) return;
		if(target.active) {
			if(state == State.not_yet) {
				state = State.summon_once_play;
				summon_effect_manager.SetDinoAppeared();
				StartCoroutine("WaitSummonOnceEffect", id);
			}
			if(state == State.summon_once_end) {
				dino_box_manager.UpdateDino(target.transform);
				summon_effect_manager.Activate(id);
			}
		}
	}
	IEnumerator WaitSummonOnceEffect (int id) {
		summon_effect_manager.ShowSummonOnceEffect(id);
		yield return new WaitForSeconds(3.0f);
		dino_box_manager.InstantiateDino(target.transform, id);
		state = State.summon_once_end;
	}
}

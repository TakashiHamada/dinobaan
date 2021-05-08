using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoxManager : MonoBehaviour {
	private AudioSource _audio_source;
	[SerializeField] private AudioClip[] _clips;
	void Start () {
		_audio_source = GetComponent<AudioSource>();
	}
	public void PlaySeButtonDown () {
		_audio_source.clip = _clips[0];
		_audio_source.Play();
	}
}

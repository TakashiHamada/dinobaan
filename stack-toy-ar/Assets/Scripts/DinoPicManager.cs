using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uween;

public class DinoPicManager : MonoBehaviour {
	[SerializeField] private GameObject _bg;
	[SerializeField] private GameObject _dino;
	void Start () {
		_bg.GetComponent<Image>().enabled = false;
		_dino.GetComponent<Image>().enabled = false;
	}
	public void Show (string name) {
		_bg.GetComponent<Image>().enabled = true;
		_dino.GetComponent<Image>().enabled = true;
		Texture2D texture = Resources.Load("DinoPic/" + name) as Texture2D;
		_dino.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
		StartCoroutine(Wait());
	}
	IEnumerator Wait () {
		TweenSXY.Add(_bg, 0.8f, 1f).EaseOutExponential().From(new Vector2(0f, 0f));
		TweenSXY.Add(_dino, 0.5f, 5f).EaseOutExponential().From(new Vector2(0f, 0f));
		yield return new WaitForSeconds(1.5f);
		TweenSXY.Add(_bg, 1.2f, 0f).EaseInCirc();
		TweenSXY.Add(_dino, 0.8f, 0f).EaseInCirc();
		yield return new WaitForSeconds(1.2f);
		_bg.GetComponent<Image>().enabled = false;
		_dino.GetComponent<Image>().enabled = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BadgeManager : MonoBehaviour {
	[SerializeField] TMPro.TextMeshProUGUI _captured_dino_count;
	[SerializeField] Sprite[] _source_images;
	void Start () {
		Debug.Assert(_source_images.Length == 5, "バッジ未設定　５にすること");
		int captured_dino_count = Session.Dino.CountCapturedDino();
		// バッジ未取得の場合は非表示
		if (captured_dino_count == 0) {
			gameObject.SetActive(false);
			return;
		}
		_captured_dino_count.text = captured_dino_count.ToString();
		GetComponent<UnityEngine.UI.Image>().sprite = SelectSprite(captured_dino_count);
	}
	private Sprite SelectSprite (int count) {
		if (count == 33) return _source_images[4];
		if (count >= 30) return _source_images[3];
		if (count >= 20) return _source_images[2];
		if (count >= 10) return _source_images[1];
		if (count >= 1 ) return _source_images[0];
		Debug.Assert(false, "バッジ選択で不正");
		return _source_images[0];
	}
}

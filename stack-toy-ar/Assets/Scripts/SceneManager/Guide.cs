using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SceneMangers {
	public class Guide : MonoBehaviour {
		[SerializeField] private string _next_scene;
		[SerializeField] private GameObject _button;
		void Start () {
			// 仕様検討が必要
			return;
			if(GetTrueCount(Session.Dino.captured_array) > 1) {
				_button.SetActive(false);
				StartCoroutine("Wait");
			}
		}
		private int GetTrueCount (bool[] ary) {
			int count = 0;
			foreach(bool flag in ary) count += flag ? 1 : 0;
			return count;
		}
		private IEnumerator Wait (){
			yield return new WaitForSeconds(1.5f);
			GetComponent<SceneLoader>().LoadScene(_next_scene);
		}
	}
}
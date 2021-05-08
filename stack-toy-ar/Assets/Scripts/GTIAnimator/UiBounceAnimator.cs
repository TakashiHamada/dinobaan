using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBounceAnimator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var scale = (Mathf.Sin(Time.time * 10f) * 0.02f) + 1.1f;
        transform.localScale = new Vector2(scale, scale);
		
		
	}
	private void Animate () {
        
    }
}

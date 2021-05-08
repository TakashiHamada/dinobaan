using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarkerBasedARExample;
using OpenCVMarkerBasedAR;
using System.Linq;

public class InitializeARmakers : MonoBehaviour {
	[SerializeField] GameObject marker;
	private List<GameObject> targets;
	void Awake () {
		// return;
		var web_cam_texture = GetComponent<WebCamTextureMarkerBasedARExample>();
		var answers = new Answers();
		web_cam_texture.markerSettings = new MarkerSettings[answers.dino_group.Length];
		// web_cam_texture.markerSettings = new MarkerSettings[10];
		for(int id = 0; id < web_cam_texture.markerSettings.Length; id++) {
			var obj = Instantiate(marker) as GameObject;

			obj.GetComponent<MarkerSettings>().markerDesign.data = answers.patterns[id];
			obj.GetComponent<SummonDinoManager>().id = answers.dino_group[id];
			web_cam_texture.markerSettings[id] = obj.GetComponent<MarkerSettings>();
		}
	}
}

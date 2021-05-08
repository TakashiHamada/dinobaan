using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Session {
	public class Dino : MonoBehaviour {
		public static bool[] captured_array = new bool[33];
		public static bool IsCaptured (int id) {
			return captured_array[id];
		}
		public static int CountCapturedDino () {
			int captured_dino_count = 0;
			for (int id = 0; id < captured_array.Length; id++)
				if (captured_array[id]) captured_dino_count ++;
			return captured_dino_count;
		}
	}
}
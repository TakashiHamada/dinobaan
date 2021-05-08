using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public class DinoTransformManager : MonoBehaviour
{
	[SerializeField] private Transform m_dino_base;
	[SerializeField] private ScreenTransformGesture m_manipulation_gesture;
	[SerializeField] private bool m_is_up_rotate = false;
	void Start() {
		m_manipulation_gesture.Transformed += manipulationTransformedHandler;
	}
	private void manipulationTransformedHandler(object sender, System.EventArgs e) {
		// 回転
		m_dino_base.Rotate(m_is_up_rotate ? Vector3.up : Vector3.forward, m_manipulation_gesture.DeltaPosition.x * Define.Param.DINO_ROTATE);
		// スケール
		if(m_dino_base.localScale.x < 0.5f) {
			m_dino_base.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		} else if (m_dino_base.localScale.x > 2f) {
			m_dino_base.localScale = new Vector3(2f, 2f, 2f);
		} else {
			float scale = m_manipulation_gesture.DeltaScale + ((1f - m_manipulation_gesture.DeltaScale) * Define.Param.DINO_SCALE);
			m_dino_base.localScale *= m_dino_base.localScale.x < 0.5f ? 1f : scale;
		}
	}
}
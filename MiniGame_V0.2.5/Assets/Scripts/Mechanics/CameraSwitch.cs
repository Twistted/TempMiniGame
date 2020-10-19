using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.Mechanics
{
	public class CameraSwitch : MonoBehaviour
	{
		public GameObject mycamera;
		public Transform centre;
		public Transform camera2D;
		public Transform camera3D;
		public bool is3D;

		public Vector3 pos2D;
		public Vector3 pos3D;
		public Vector3 rot2D;
		public Vector3 rot3D;

		public AnimationCurve curve;//x轴是移动时间，y轴是移动量
		public float moveDalayTime;//移动到目的地花费的时间
		private Vector3 objectPos;
		public float x;
		public bool isRot;//判断是否在旋转过程中

		void start()
		{
			is3D = false;
			objectPos = mycamera.transform.position;
			isRot = false;
			x = 0;
		}

		void Update()
		{
			if (Input.GetButtonDown("Change Camera"))
			{
				isRot = true;
			}
			if (isRot)
			{
				change();
			}
		}

		void change()
		{
			if (!is3D)
			{
				x += Time.deltaTime / moveDalayTime;
				mycamera.transform.position = Vector3.Lerp(pos2D, pos3D, curve.Evaluate(x));
				mycamera.transform.eulerAngles = Vector3.Lerp(rot2D, rot3D, curve.Evaluate(x));
				mycamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(27, 34, curve.Evaluate(x));
				if (x >= 1)
				{
					is3D = true;
					x = 0;
					isRot = false;
				}
			}
			else
			{
				x += Time.deltaTime / moveDalayTime;
				mycamera.transform.position = Vector3.Lerp(pos3D, pos2D, curve.Evaluate(x));
				mycamera.transform.eulerAngles = Vector3.Lerp(rot3D, rot2D, curve.Evaluate(x));
				mycamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(34, 27, curve.Evaluate(x));
				if (x >= 1)
				{
					is3D = false;
					x = 0;
					isRot = false;
				}
			}
		}
	}
}

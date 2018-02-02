using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamTest : MonoBehaviour {

	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		foreach (var device in devices) {
			// FaceTime HD Camera
			// RICOH THETA V
			Debug.Log(string.Format("接続しているデバイスの名前：{0}", device.name));
		}
	}
	
	void Update () {
		
	}
}

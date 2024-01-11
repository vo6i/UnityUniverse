using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollyZoom: MonoBehaviour {

    public Camera cam;
    public Slider slider;

    void Update () {
        cam.fieldOfView = slider.value + 40;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 40, 140);
        cam.gameObject.transform.position = new Vector3(cam.gameObject.transform.position.x, cam.gameObject.transform.position.y, slider.value * 0.13f - 19);
    }

}

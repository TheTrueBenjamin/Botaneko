using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toolkit : MonoBehaviour
{
    [Header("Camera Sensativity")]
    public Slider cameraSenseSlider;
    public CameraController cameraController;
    public TMP_Text cameraSenseText;

    void Start()
    {
        cameraSenseSlider.SetValueWithoutNotify(cameraController.rotationSpeed);
        cameraSenseText.text = cameraController.rotationSpeed.ToString("F2");
        cameraSenseSlider.onValueChanged.AddListener((val) => UpdateCameraSense(val));
    }

    private void UpdateCameraSense(float val)
    {
        cameraController.rotationSpeed = val;
        cameraSenseText.text = val.ToString("F1");
    }
}

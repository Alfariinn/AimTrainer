using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] TMP_Text sensitivityDisplay;
    [SerializeField] TMP_Text fovDisplay;


    public void changeSensitivity(float sens)
    {
        PlayerController.mouseSensitivity = sens;
    }

    public void changeFOV(float fov)
    {
        PlayerController.fov = fov;
    }

    private void Update()
    {
        sensitivityDisplay.text =$"Mouse Sensitivity: {PlayerController.mouseSensitivity.ToString("0.00")}";
        fovDisplay.text = $"FOV: {PlayerController.fov.ToString("0")}";
    }

    public void GunModel(bool visible)
    {
        GunController.gunVisible = visible;
    }


}

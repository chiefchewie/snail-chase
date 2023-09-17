using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InputManager : MonoBehaviour
{
    public GameObject SpeedField;
    public GameObject LatField;
    public GameObject LongField;

    public void SubmitButtonClick()
    {
        try
        {
            double latitude = double.Parse(LatField.GetComponent<TMPro.TMP_InputField>().text);
            double longitude = double.Parse(LongField.GetComponent<TMPro.TMP_InputField>().text);
            string speed = SpeedField.GetComponent<TMPro.TMP_Dropdown>().captionText.text;
            double speed_mps;
            if (speed == "Snail")
            {
                speed_mps = 0.1;
            } else if (speed == "Walk")
            {
                speed_mps = 0.9;
            } else
            {
                speed_mps = 4;
            }
            Debug.Log("Latitude: " + latitude + " | Longitude: " + longitude + " | Speed: " + speed_mps);
            MainManager.instance.latitude = latitude;
            MainManager.instance.longitude = longitude;
            MainManager.instance.speed_mps = speed_mps;
        }
        catch (System.FormatException e)
        {
            LatField.GetComponent<TMPro.TMP_InputField>().text = "";
            LongField.GetComponent<TMPro.TMP_InputField>().text = "";
            Debug.Log("Invalid input");
            SceneManager.LoadScene("BlankAR");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InputManager : MonoBehaviour
{
    public GameObject SpeedField;
    public GameObject DistField;

    public void SubmitButtonClick()
    {
        try
        {
            double distance = double.Parse(DistField.GetComponent<TMPro.TMP_InputField>().text);
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

            (double, double) latLong = getLatLong(distance, speed_mps);

            Debug.Log("Distance:" + distance + " | Speed: " + speed_mps);
            MainManager.instance.distance = distance;
            MainManager.instance.speed_mps = speed_mps;
            MainManager.instance.latlong = latLong;
            SceneManager.LoadScene("BlankAR");
        }
        catch (System.FormatException e)
        {
            DistField.GetComponent<TMPro.TMP_InputField>().text = "";
            Debug.Log("Invalid input");
        }
    }

    private (double, double) getLatLong(double distance, double speed_mps)
    {
        int METERS_TO_DEGREES = 111139;
        System.Random r = new System.Random();

        double x = r.NextDouble() * distance;
        double y = System.Math.Sqrt(distance * distance - x * x);
        Debug.Log(System.Math.Sqrt(y * y + x * x) == distance);

        double latitude = y / METERS_TO_DEGREES;
        double longitude = x / METERS_TO_DEGREES;

        return (latitude, longitude);
    }

}
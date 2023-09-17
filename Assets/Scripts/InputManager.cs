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

            /*
            Random r = new Random();
            double latitude = r.NextDouble()*distance;
            double longitude = Math.Sqrt(distance*distance - latitude*latitude);
            Debug.Log(Math.Sqrt(longitude*longitude + latitude*latitude) == distance);
            */

            Debug.Log("Distance": + distance + " | Speed: " + speed_mps);
            MainManager.instance.distance = distance;
            MainManager.instance.speed_mps = speed_mps;
            // SceneManager.LoadScene("BlankAR");
        }
        catch (System.FormatException e)
        {
            DistField.GetComponent<TMPro.TMP_InputField>().text = "";
            Debug.Log("Invalid input");
        }
    }
}
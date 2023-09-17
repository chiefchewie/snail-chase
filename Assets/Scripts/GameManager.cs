using ARLocation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlaceAtLocation snail;
    [SerializeField] private float deathDistance;
    [SerializeField] private Text debugText;
    [SerializeField] private float gracePeriod = 10;

    private bool alive = true;
    private float timeSurvived = 0;

    void Start()
    {
        alive = true;
        timeSurvived = 0;
    }

    void Update()
    {
        debugText.text = string.Format("alive: {0}\ntime survived: {1}", alive, timeSurvived);

        if (timeSurvived < gracePeriod)
        {
            return;
        }

        var distance = snail.SceneDistance;
        if (distance < deathDistance)
        {
            alive = false;
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            alive = true;
        }
    }

    void FixedUpdate()
    {
        if (alive)
        {
            timeSurvived += Time.fixedDeltaTime;
        }
    }
}

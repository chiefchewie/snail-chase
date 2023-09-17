using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ARLocation;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;

    void Start()
    {
    }

    void Update()
    {        
    }

    void FixedUpdate()
    {
        var dir = player.transform.position - this.transform.position;
        dir.Normalize();
        dir *= (float)speed;

        this.transform.position += ((float) MainManager.Instance.speed_mps) * Time.fixedDeltaTime * dir;

        this.transform.LookAt(player.transform);
    }
}

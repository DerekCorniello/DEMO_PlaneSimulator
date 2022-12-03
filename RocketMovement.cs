using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RocketMovement : MonoBehaviour
{
    public GameObject rocket;
    public int shotRockets = 0;
    public TextMeshProUGUI shotRocketsText = null;
    public QuitGame quit;
    public static int rocketsInPlay = 0;

    void Start()
    {
        shotRocketsText.text = "Rockets Left: 10";
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (shotRockets < 10)
            {
                rocketsInPlay++;
                GameObject newRocket = Instantiate(rocket);
                newRocket.GetComponent<RocketMoveAfterSpawn>().plane = gameObject;
                newRocket.name = "rocket_" + (shotRockets + 1);
                newRocket.transform.position = transform.position;
                newRocket.transform.rotation = (transform.rotation * Quaternion.Euler(0, 90, 0));
                newRocket.SetActive(true);
                shotRockets++;
                shotRocketsText.text = "Rockets Left: " + (10 - shotRockets).ToString();
            }
        }
    }
}
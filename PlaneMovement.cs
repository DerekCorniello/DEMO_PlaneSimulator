using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float speed = 50f;
    public float bias = .96f;
    public GameObject Plane;
    public GameObject Smoke;
    public bool stillInAir = true;
    public QuitGame quit;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {

        // Plane Movement

        speed += transform.right.y * Time.deltaTime;

        if (speed < 40f)
        {
            speed = 40f;
        }

        transform.position += -transform.right * Time.deltaTime * speed * 2.0f;
        transform.Rotate(Input.GetAxis("Horizontal") * 2f, 0f, Input.GetAxis("Vertical") * 2f);

        float terrainHeightAtMyPosition = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightAtMyPosition > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeightAtMyPosition, transform.position.z);
            Smoke.transform.position = new Vector3(transform.position.x, terrainHeightAtMyPosition + 2f, transform.position.z);
            Smoke.SetActive(true);
            Plane.SetActive(false);
            stillInAir = false;
            Camera.main.transform.LookAt(Smoke.transform.position + Smoke.transform.up * 10);
            quit.gameOverFunction(false, true);
        }

        // Bounding area
        Vector3 correction = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (transform.position.x > 1000.0f)
        {
            correction = new Vector3(1000.0f, transform.position.y, transform.position.z);
        }

        if (transform.position.y > 1000.0f)
        {
            correction = new Vector3(transform.position.x, 1000.0f, transform.position.z);
        }

        if (transform.position.z > 1000.0f)
        {
            correction = new Vector3(transform.position.x, transform.position.y, 1000.0f);
        }

        if (transform.position.x < 0.0f)
        {
            correction = new Vector3(0.0f, transform.position.y, transform.position.z);
        }

        if (transform.position.y < 0.0f)
        {
            correction = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }

        if (transform.position.z < 0.0f)
        {
            correction = new Vector3(transform.position.x, transform.position.y, 0.0f);
        }

        transform.position = correction;

        // Camera Movement
        if (stillInAir)
        {
            Vector3 moveCameraTo = transform.position + transform.right * 10f + Vector3.up * 5f;
            Camera.main.transform.position = (Camera.main.transform.position * bias) + (moveCameraTo * (1.0f - bias));
            Camera.main.transform.LookAt(transform.position - transform.right * 25f + transform.up * 3f );
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Smoke.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Smoke.SetActive(true);
        Plane.SetActive(false);
        stillInAir = false;
        Camera.main.transform.LookAt(Smoke.transform.position + Smoke.transform.up * 3);
        quit.gameOverFunction(false, true);
    }
}
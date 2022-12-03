using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    public Terrain land;


    void Start()
    {
        var size = land.terrainData.size; // gives us a Vector3 of (1000.0, 600.0, 1000.0)

        for (int x = 0; x < 5; x++)
        {
            float terrainHeightAtMyPosition = Terrain.activeTerrain.SampleHeight(transform.position);
            float randomx = Random.Range(0, 1000f);
            float randomz = Random.Range(0, 1000f);
            transform.position = new Vector3(randomx, 0, randomz);
            float randomy = Random.Range(Terrain.activeTerrain.SampleHeight(transform.position) + 100, 700);
            float randomrotx = Random.Range(0f, 359f);
            float randomroty = Random.Range(0f, 359f);
            float randomrotz = Random.Range(0f, 359f);

            Vector3 randomPosition = new Vector3(randomx, randomy, randomz);
            Vector3 randomRotation = new Vector3(randomrotx, randomroty, randomrotz);
            
            GameObject newtarget = Instantiate(target);
            newtarget.name = "target_" + x;
            newtarget.transform.position = randomPosition;
            newtarget.transform.Rotate(randomRotation);
            newtarget.SetActive(true);
        }
    }
}
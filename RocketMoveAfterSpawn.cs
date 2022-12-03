using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketMoveAfterSpawn : MonoBehaviour
{
    public TargetCounterManager targetCounter;
    public bool collisionVar = false;
    public float speed = 60;
    public GameObject plane;
    public GameObject explode;
    public float terrainHeightAtRocketPosition;
    public QuitGame quit;
    public RocketMovement RocketMovement;

    void Update()
    {
        terrainHeightAtRocketPosition = Terrain.activeTerrain.SampleHeight(transform.position);

        if (collisionVar == false)
        { 
            moveRocket();

            if (transform.position.x > 1000.0f || transform.position.y > 800.0f || transform.position.z > 1000.0f || transform.position.x < 0.0f || transform.position.y < -5.0f || transform.position.z < 0.0f)
            {
                RocketMovement.rocketsInPlay--;

                if (RocketMovement.shotRockets == 10)
                {
                    if (RocketMovement.rocketsInPlay == 0)
                    {
                        quit.gameOverFunction(false, false);
                    }
                }

                Destroy(gameObject);
            }
        }
    }

    private void moveRocket()
    {
        if (terrainHeightAtRocketPosition >= transform.position.y)
        {
            RocketMovement.rocketsInPlay--;
            GameObject newexplode2 = Instantiate(explode);
            newexplode2.transform.position = transform.position;
            newexplode2.SetActive(true);
            collisionVar = true;
            Destroy(newexplode2, 2);

            if (RocketMovement.shotRockets == 10)
            {
                if (RocketMovement.rocketsInPlay == 0)
                {
                    quit.gameOverFunction(false, false);
                }
            }

        }
        if (collisionVar == false)
        {
            transform.position += -transform.forward * 250.0f * Time.deltaTime;
        }
        if (collisionVar == true)
        {
            if (RocketMovement.shotRockets == 10)
            {
                if (RocketMovement.rocketsInPlay == 0)
                {
                    quit.gameOverFunction(false, false);
                }
            }

            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            RocketMovement.rocketsInPlay--;
            targetCounter.updateCount();
            Destroy(gameObject);
            GameObject newexplode = Instantiate(explode);
            newexplode.transform.position = transform.position;
            newexplode.SetActive(true);
            collisionVar = true;

            if (RocketMovement.shotRockets == 10)
            {
                if (RocketMovement.rocketsInPlay == 0)
                {
                    quit.gameOverFunction(false, false);
                }
            }

            Destroy(collision.gameObject);
            Destroy(newexplode, 2);
        }
    }
}
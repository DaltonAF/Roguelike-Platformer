using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{

    public float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    public GameObject echo;
    public PlayerMovement playermovement;
    private GameObject instance;

    

    void Update()
    {
        Vector3 xyz = new Vector3(0, 90, 0);
        Quaternion newRotation = Quaternion.Euler(xyz);
        if(playermovement.isDashing)
        {
            if(timeBetweenSpawns <= 0)
            {
                instance = Instantiate(echo, transform.position, this.transform.rotation);
                Destroy(instance, 1.5f);
                timeBetweenSpawns = startTimeBetweenSpawns;
            }

            else
            {
                timeBetweenSpawns -= Time.deltaTime;
            }
        }
    }
}

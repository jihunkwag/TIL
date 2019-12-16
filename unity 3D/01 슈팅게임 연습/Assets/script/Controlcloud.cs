using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlcloud : MonoBehaviour
{
    public GameObject[] clouds;
    float CloudSpeed;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < clouds.Length; i++)
        {
            clouds[i].transform.position = new Vector3(Random.Range(15.0f, 50.0f), Random.Range(2.3f, 5.9f), 6.5f);
        }
        CloudSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < clouds.Length; i++)
        {
            if (clouds[i].transform.position.x < -16.0f)
                clouds[i].transform.position = new Vector3(Random.Range(15.0f, 50.0f), Random.Range(2.3f, 5.9f), 6.5f);
            else
                clouds[i].transform.position = new Vector3(clouds[i].transform.position.x - Random.Range(0.5f, 0.8f), clouds[i].transform.position.y, clouds[i].transform.position.z);
        }
    }
}

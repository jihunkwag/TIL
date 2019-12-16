using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public Sprite[] smokes;
    public int nframeprSec;
    public float deleteTime;

    int imgPerSec;
    float TimePerSec;
    float nextTime;
    int curFrame;

    float time;
    
    // Start is called before the first frame update
    void Start()
    {
        curFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            imgPerSec = smokes.Length;
            TimePerSec = 1.0f / (imgPerSec * nframeprSec);
            nextTime = TimePerSec;

            nextTime = Time.time + TimePerSec;

            curFrame++;

            if (curFrame >= imgPerSec)
            {
                curFrame = 0;
            }

            gameObject.GetComponent<SpriteRenderer>().sprite
                = smokes[curFrame];
        }
        gameObject.transform.position
            = new Vector3(gameObject.transform.position.x - 1,
            gameObject.transform.position.y,
            gameObject.transform.position.z);

        time += Time.deltaTime;
        if (time > deleteTime)
           Destroy(gameObject);
    }
}

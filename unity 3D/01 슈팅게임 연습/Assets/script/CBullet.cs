using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    Vector2 posBullet;
    public float BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //posBullet = GameObject.Find("Plane").transform.position;
        //gameObject.transform.position = new Vector2(posBullet.x,posBullet.y);    
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.transform.localScale.x * BulletSpeed, 0);
        
        if (gameObject.transform.position.x >= 13.0f)
            Destroy(gameObject);
    }
}

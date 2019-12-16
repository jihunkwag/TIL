using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlane : MonoBehaviour
{
    /*Object 관련 변수 */
    public GameObject Player_Object;
    public GameObject Missale_Oject;
    public GameObject EffectSound_Oject;
    public GameObject EngineSmoke;
    /*이미지 관련 변수*/
    public Sprite Img_idle;
    public Sprite[] Img_rotation;

    public float moveSpeed;

    int Ddodge_imgPerSec;
    float Ddodge_TimePerSec;
    float Ddodge_nextTime;
    int Ddodge_curFrame;

    public int nframeprSec;
    public Camera MainCarmera;
    int player_State;
    public static int time;

    enum state
    {
        Idle, 
        Attack_Right
    }

    void Start()
    {
        player_State = (int)state.Idle;
        nframeprSec = 8;
        



    }

    // Update is called once per frame
    void Update()
    {
        
        switch (player_State)
        {
            case (int)state.Idle:
               
                
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Player_Object.transform.position 
                        = new Vector2(Player_Object.transform.position.x, 
                        Player_Object.transform.position.y + moveSpeed);
                    // GetComponent.Player_Object.transform.position.y = 
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Player_Object.transform.position 
                        = new Vector2(Player_Object.transform.position.x,
                        Player_Object.transform.position.y - moveSpeed);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Player_Object.transform.position = new Vector2(Player_Object.transform.position.x - moveSpeed, 
                        Player_Object.transform.position.y);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {   Player_Object.transform.position = new Vector2(Player_Object.transform.position.x + moveSpeed,
                        Player_Object.transform.position.y);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject ad = Instantiate(Missale_Oject, new Vector3(Player_Object.transform.position.x + 1.0f, Player_Object.transform.position.y, Player_Object.transform.position.z),Player_Object.transform.localRotation) as GameObject;
                    Instantiate(EffectSound_Oject, gameObject.transform.position, gameObject.transform.localRotation);
                }
                
                    Instantiate(EngineSmoke, new Vector3(gameObject.transform.position.x - 1f,
                        gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.localRotation);
                break;
                
           
            
        }

        
    }
 
    void Idle()
    {
        
        Player_Object.GetComponent<SpriteRenderer>().sprite
            = Img_idle;
    }
    void Ddodge()
    {
        Ddodge_imgPerSec = Img_rotation.Length;
        Ddodge_TimePerSec = 1.0f / (Ddodge_imgPerSec * nframeprSec);
        Ddodge_nextTime = Ddodge_TimePerSec;

        Ddodge_nextTime = Time.time + Ddodge_TimePerSec;

        Ddodge_curFrame++;

        if (Ddodge_curFrame >= Ddodge_imgPerSec)
        {
            Ddodge_curFrame = -1;
        }

        Player_Object.GetComponent<SpriteRenderer>().sprite
            = Img_rotation[Ddodge_curFrame];
    }
    bool OnKeydown(int Keycode)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return true;

        }
        else return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companian : MonoBehaviour
{
    GameObject Player;
    Vector3 padding;
    Vector3 offset;
    bool isFound;
    private float nextActionTime = 0.0f;
    public float period = 0.5f;
    public float speed = 2f;
    public float radius = 3f;
    public static int anzahl = 1;
    int counterAnim;
    GameObject FireFly;
    SpriteRenderer sr;
    bool startHappy;
    public Sprite normal;
    public Sprite Happy1;
    public Sprite Happy2;


    // Start is called before the first frame update
    void Start()
    {
        startHappy = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        isFound = false;
        padding = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        FireFly = gameObject.transform.GetChild(1).gameObject;
        sr = FireFly.GetComponent<SpriteRenderer>();
        counterAnim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();


    }
    private void FollowPlayer()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (startHappy)
            {
                HappyAnim();
            }
            else
            {
                wobbel();
             
            }
            
        }

        if (isFound && !startHappy)
        {
            offset = (Player.transform.position + padding) - transform.position;
            var move = new Vector3(offset.x, offset.y, 0) * Time.deltaTime * speed;
            transform.Translate(move);
            RotateImage(offset.x);

        }



    }
    private void wobbel()
    {
        
        padding = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0f);
        RotateImage(padding.x);
    }
    private void HappyAnim()
    {
        if(counterAnim < 4) { 
            if (sr.sprite == Happy2 || sr.sprite == normal)
            {
                sr.sprite = Happy1;
                Debug.Log("s1");
            }
            else if(sr.sprite == Happy1)
            {
                sr.sprite = Happy2;
                Debug.Log("s2");
            }
            counterAnim++;
        }
        else
        {
            sr.sprite = normal;
            Debug.Log("sn");
            startHappy = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFound = true;
            GetComponent<CircleCollider2D>().enabled = false;
            startHappy = true;
            anzahl++;
        }
    
        
    }
    private void RotateImage(float x)
    {
        if (x > 0)
        {
            FireFly.transform.rotation = new Quaternion(0, 180, 0, 1);
        }
        else
        {
            FireFly.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
    }

}

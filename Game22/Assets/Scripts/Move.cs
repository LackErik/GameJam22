using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    float xAchse = 0f;
    float yAchse = 0f;
    private float nextActionTime = 0.0f;
    public float period = 2f;
    GameObject FireFly;
    SpriteRenderer sr;
    public Sprite normalFly;
    public Sprite pushFly;
    Rigidbody2D rb;
 

    // Start is called before the first frame update
    void Start()
    {
        FireFly = gameObject.transform.GetChild(1).gameObject;
        sr = FireFly.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
     
    }

    // Update is called once per frame

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
        }

        LookDirection();
        Controlle();

    }

    private void LookDirection() 
    {


        if (xAchse > 0)
        {
            FireFly.transform.rotation = new Quaternion(0, 180, 0, 1);
        }
        else
        {
            FireFly.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
    }
    private void Controlle()
    {
        xAchse = Input.GetAxis("Horizontal");
        yAchse = Input.GetAxis("Vertical");
        var move = new Vector3(xAchse, yAchse);
        rb.MovePosition(move * speed * Time.deltaTime + transform.position);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        sr.sprite = pushFly;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        sr.sprite = normalFly;
    }

}

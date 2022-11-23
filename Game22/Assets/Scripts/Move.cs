using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    float xAchse = 0f;
    float yAchse = 0f;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    GameObject FireFly;
    SpriteRenderer sr;
    public Sprite normalFly;
    public Sprite pushFly;
    public Sprite blinkFly;
    Rigidbody2D rb;
    public int timeCounter;
    public int blinkPeriod;
    public GameObject msgBox;


    // Start is called before the first frame update
    void Start()
    {
        FireFly = gameObject.transform.GetChild(1).gameObject;
        sr = FireFly.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        timeCounter = 0;


    }

    // Update is called once per frame

    void Update()
    {

        Blink();
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
    private void Blink()
    {
        if (Time.time > nextActionTime)
        {
            timeCounter++;

            nextActionTime += period;
            if (timeCounter == blinkPeriod)
            {
                if (sr.sprite == normalFly)
                {
                    sr.sprite = blinkFly;
                }

                timeCounter = 0;
                blinkPeriod = Mathf.RoundToInt(Random.Range(5f, 9f));
            }
            else
            {
                if (sr.sprite == blinkFly)
                {
                    sr.sprite = normalFly;
                }

            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sr.sprite = pushFly;
        if (collision.gameObject.CompareTag("InteractivObject"))
        {
           // msgBox.gameObject.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        sr.sprite = normalFly;
        if (collision.gameObject.CompareTag("InteractivObject"))
        {
           // msgBox.gameObject.SetActive(false);
        }
    }

   

}
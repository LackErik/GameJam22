using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    float xAchse = 0f;
    float yAchse = 0f;
    GameObject FireFly;
    SpriteRenderer sr;
    public Sprite normalFly;
    public Sprite pushFly;

    // Start is called before the first frame update
    void Start()
    {
        FireFly = gameObject.transform.GetChild(1).gameObject;
        sr = FireFly.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xAchse = Input.GetAxis("Horizontal");
        yAchse = Input.GetAxis("Vertical");
        if(xAchse > 0)
        {
            FireFly.transform.rotation = new Quaternion( 0, 180, 0,1);
        }
        else
        {
            FireFly.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
       
            var move = new Vector3(xAchse, yAchse);
            transform.Translate(move * speed * Time.deltaTime);

     

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

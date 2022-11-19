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


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        isFound = false;
     
        padding = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
 
       // WobbelJannik();
    
      
    }
    private void FollowPlayer()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            padding = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0f);
        }
       

        if (isFound)
        {
            offset = (Player.transform.position + padding) - transform.position;
            var move = new Vector3(offset.x, offset.y, 0) * Time.deltaTime * speed;
            transform.Translate(move);

        }

    }
    private void WobbelJannik()
    {
        Vector3 direktien = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        var move = new Vector3(direktien.x, direktien.y, 0) * Time.deltaTime * 3f;
        transform.Translate(move);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isFound = true;
        GetComponent<CircleCollider2D>().enabled = false;
        
    }

}

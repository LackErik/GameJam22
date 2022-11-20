using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int braucht = 2;
    public bool eventPass;
    public bool rolling;

    // Start is called before the first frame update
    void Start()
    {
        eventPass = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (eventPass)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (Companian.anzahl >= braucht)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            eventPass = true;
        }
    }
}

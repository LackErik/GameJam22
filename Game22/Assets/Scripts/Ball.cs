using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int braucht = 2;
    public int anzahl = 0;
    public bool eventPass;
    public bool rolling;
    public Vector3 ballPosition;
    Vector3 offset;
    Vector3 rollPosition;
    GameObject ziel;
    // Start is called before the first frame update
    void Start()
    {
        eventPass = false;
        ballPosition = gameObject.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (!eventPass)
        {
            gameObject.transform.position = ballPosition;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (anzahl >= braucht)
        {
            eventPass = true;
        }
    }
   

    /**
    private void Roll()
    {
        
            offset = ziel.transform.position - ballPosition;
            var move = new Vector3(offset.x, offset.y, 0) * Time.deltaTime * 2f;
            transform.Translate(move);
        
        
    }
    **/
}

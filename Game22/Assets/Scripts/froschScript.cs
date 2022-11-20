using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class froschScript : MonoBehaviour
{
    
    SpriteRenderer sr;
    //public Sprite frogAlive;
    public Sprite frogDead;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tannenzapfen"))
        {
            gameObject.transform.position = new Vector3(30f, -29f, 0f);
            sr.sprite = frogDead;

        }

    }
}

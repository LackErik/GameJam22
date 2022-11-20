using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glas : MonoBehaviour
{

    public int braucht = 10;
    public bool eventPass;
    SpriteRenderer sr;
    public Sprite glasStay;
    public Sprite glasFall;
    public GameObject prefab;
    public GameObject light;

   

    // Start is called before the first frame update
    void Start()
    {
        eventPass = false;
       
        sr = gameObject.GetComponent<SpriteRenderer>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if (eventPass)
        {
            //hier neuen Sprite
            sr.sprite = glasFall;
             
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Companian.anzahl >= braucht)
            {
                eventPass = true;
                startSpawner();
                gameObject.GetComponents<BoxCollider2D>()[0].enabled = false;
                gameObject.GetComponents<BoxCollider2D>()[1].enabled = false;
                Destroy(light);

            }
        }
    }
  
    void startSpawner()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnAt(gameObject.transform.position);
        }
    }
    void SpawnAt(Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }


}

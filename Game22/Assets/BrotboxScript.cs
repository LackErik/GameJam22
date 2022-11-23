using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotboxScript : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite boxOpen;
    public int needed = 3;
    BoxCollider2D col;
    public GameObject msgBox;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        col = gameObject.GetComponents<BoxCollider2D>()[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Companian.anzahl >= needed)
        {
            sr.sprite = boxOpen;
            col.isTrigger = true;
            sr.sortingOrder = 1;

        }
        if (other.CompareTag("Player") && Companian.anzahl < needed)
        {
            msgBox.SetActive(true);
        }
            

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Companian.anzahl < needed)
        {
            msgBox.SetActive(false);
        }
    }
}

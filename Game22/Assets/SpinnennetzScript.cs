using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnennetzScript : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite netzKaputt;
    public int needed = 8;
    EdgeCollider2D col;
    public GameObject msgBox;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        col = gameObject.GetComponents<EdgeCollider2D>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Companian.anzahl >= needed)
        {
            sr.sprite = netzKaputt;
            col.isTrigger = true;

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
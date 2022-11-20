using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tannenzapfenScript : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    Vector3 m_YAxis;
    public int needed = 2;
    public float fallspeed = 1.0f;
    


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_YAxis = new Vector3(0, 3, 0);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Companian.anzahl >= needed)
        {
            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX!;
            Debug.Log(other.gameObject.name);
            m_Rigidbody.velocity = m_YAxis;
            m_Rigidbody.AddForce(new Vector3(0, -1.0f, 0) * m_Rigidbody.mass * fallspeed);

        }

    }
}

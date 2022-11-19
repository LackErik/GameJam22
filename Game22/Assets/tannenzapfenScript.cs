using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tannenzapfenScript : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    Vector3 m_YAxis;
    public GameObject frosch;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_YAxis = new Vector3(0, 3, 0);
        frosch = GameObject.FindWithTag("Frosch");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_Rigidbody.constraints = RigidbodyConstraints2D.None;
            //Debug.Log(other.gameObject.name);
            m_Rigidbody.velocity = m_YAxis;
            frosch.transform.Translate(24, -29, 0);

        }

    }
}

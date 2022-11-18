using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    float xAchse = 0f;
    float zAchse = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xAchse = Input.GetAxis("Horizontal");
        zAchse = Input.GetAxis("Vertical");
        var move = new Vector3(xAchse, zAchse);
        transform.Translate(move*speed * Time.deltaTime);
        
    }
}

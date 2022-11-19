using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hiveScoreScript : MonoBehaviour
{
    private TextMeshProUGUI hiveValueText;
    
    // Start is called before the first frame update
    private void Awake() {
        hiveValueText = GetComponent<TextMeshProUGUI>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hiveValueText.text = Companian.anzahl.ToString()+"x";
    }
}

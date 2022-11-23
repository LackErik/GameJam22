using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipIntroScene : MonoBehaviour
{
    Animation anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();   
    }

    // Update is called once per frame
    void Update()
    {
      if(!anim.isPlaying)
        {
            SceneManager.LoadScene(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void Update()
    {
        
    }

    public void Restart()
    {
      
      FadeManager.Instance.LoadScene("Game", 1.0f);
        
    }
}
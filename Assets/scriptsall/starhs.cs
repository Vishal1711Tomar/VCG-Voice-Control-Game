using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starhs : MonoBehaviour
{
    public Text total;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        total.text = GameManager.totalscores.ToString();
    }
   
}

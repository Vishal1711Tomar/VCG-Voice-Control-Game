using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Starting : MonoBehaviour
{
    public GameObject TC;
    public GameObject Startss;
    public GameObject controlss;
    public Text check;
    public  bool term = false;
    public Toggle Tnctoggle;
    private int x = 0,y=0;
    
    // Start is called before the first frame update
    void Start()
    {
        // y = PlayerPrefs.GetInt("tnc",0);
      //  if(y==0)
      //  {
       //     Tnctoggle.isOn = false;
      //  }
     //   else
     //   {
      //      Tnctoggle.isOn  = true;
      //  }
    }

    // Update is called once per frame
    void Update()
    {
        term = Tnctoggle.isOn;
        x = (term) ? 1 : 0;
      //  PlayerPrefs.SetInt("tnc", x);
        if(term)
        {
            check.text = "";
        }

    }
    
    public void Starts()
    {
       if(term)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void TCS()
    {
        Startss.SetActive(false);
        TC.SetActive(true);

    }
    public void Menu()
    {
        TC.SetActive(false);
        Startss.SetActive(true);

    }
    public void MenubackControls()

    {
        controlss.SetActive(false);
        Startss.SetActive(true);

    }
   
    public void Controls()
    {
        Startss.SetActive(false);
        controlss.SetActive(true);

    }
    public void quit()
    {
        Application.Quit();
    }
    public void tccheck()
    {
        TC.SetActive(false);
        Startss.SetActive(true);
       
        term = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public  static float Scores = 0f;
    public static float totalscores = 0f;
    public Text score;
    public Text Totalscores;
    public GameObject LCTrue;
    public GameObject PausemenuUI;
    public GameObject MainScreen;
    public bool gameHasEnded = false;

   
    public GameObject Gameends;
    public GameObject Wins;

    // Start is called before the first frame update
    void Start()
    {
      //  totalscores = PlayerPrefs.GetFloat("totalscores", 0f); ;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Scores.ToString();
        Totalscores.text = totalscores.ToString();
       
    }
    public void  nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CompleteLevel()
    {
        LCTrue.SetActive(true);
       
        if (SceneManager.GetActiveScene().name != "End")
        {

            StartCoroutine(Menudelay());
        }
        else
        {
            MainScreen.SetActive(false);
            SceneManager.LoadScene("End");
        }
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            MainScreen.SetActive(true);
            Gameends.SetActive(true);
        }
    }
    IEnumerator Menudelay()
    {
        totalscores = totalscores + Scores;
      //  PlayerPrefs.SetFloat("totalscores", totalscores);
        yield return new WaitForSeconds(3);
        Time.timeScale = 0f;
        LCTrue.SetActive(false);
        MainScreen.SetActive(false);
        Wins.SetActive(true);
    }
    void Restart()
    {
        gameHasEnded = false;
        Gameends.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PausemenuUI.SetActive(false);
        MainScreen.SetActive(true);
        Scores = 0f;
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausemenuUI.SetActive(true);
            Time.timeScale = 0f;

            MainScreen.SetActive(false);
        }

    }
    public void Pausem()
    {
        MainScreen.SetActive(false);
        PausemenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void quitbutton()
    {
        Application.Quit();
    }
    public void restartbutton()
    {
        gameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        
        Scores = 0f;
    }
    public void nextbutton()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MainScreen.SetActive(true);
       
        Scores = 0f;
        Time.timeScale = 1f;
    }
    public void Resume()
    {

        Time.timeScale = 1f;
        PausemenuUI.SetActive(false);
        MainScreen.SetActive(true);
    }
}

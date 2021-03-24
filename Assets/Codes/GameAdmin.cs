using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour
{
    GameObject circle;
    GameObject mainCircle;
    public Animator animator;
    public Text CircleLevel;
    public Text One;
    public Text Two;
    public Text Three;
    public int TotalArrow;
    bool control = true;

    void Start()
    {
        PlayerPrefs.SetInt("save", int.Parse(SceneManager.GetActiveScene().name));
        PlayerPrefs.GetInt("save");
        circle = GameObject.FindGameObjectWithTag("circle");
        mainCircle = GameObject.FindGameObjectWithTag("maincircle");
        CircleLevel.text = SceneManager.GetActiveScene().name;

        if (TotalArrow < 2)
        {
            One.text = TotalArrow + "";
        }
        else if (TotalArrow < 3)
        {
            One.text = TotalArrow + "";
            Two.text = (TotalArrow-1) + "";
        }
        else
        {
            One.text = TotalArrow + "";
            Two.text = (TotalArrow - 1) + "";
            Three.text = (TotalArrow - 2) + "";
        }
    }

    public void insivibleText() // For Little Circle Text
    {
        TotalArrow--;

        if (TotalArrow < 2)
        {
            One.text = TotalArrow + "";
            Two.text = "";
        }
        else if (TotalArrow < 3)
        {
            One.text = TotalArrow + "";
            Two.text = (TotalArrow - 1) + "";
            Three.text = "";
        }
        else
        {
            One.text = TotalArrow + "";
            Two.text = (TotalArrow - 1) + "";
            Three.text = (TotalArrow - 2) + "";
        }
        if (TotalArrow == 0)
        {
            StartCoroutine(newLevel());
        }
    }
    IEnumerator newLevel()
    {
        circle.GetComponent<Spin>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        yield return new WaitForSeconds(0.5f);

        if(control)
        {
            animator.SetTrigger("NewLevel");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);

        }
    }

    public void GameOver()
    {
        StartCoroutine(Calling());
    }

    IEnumerator Calling()
    {
        circle.GetComponent<Spin>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        animator.SetTrigger("GameOver");
        control = false;

        yield return new WaitForSeconds(2);
       
        SceneManager.LoadScene("MainMenu");
        
    }
}

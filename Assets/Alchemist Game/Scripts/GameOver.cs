using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameManager GM;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
        Destroy(GM.gameObject);
    }
    public void Exit()
    {
        SceneManager.LoadScene("MenuScene");
        Destroy(GM.gameObject);
    }
}

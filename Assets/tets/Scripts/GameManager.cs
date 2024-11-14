using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager GM;
    public static GameManager instance;
    public int totalKeys, needKeys;
    public Text keyText, healthText;
    public GameObject doorPanel;
    public float Timer, cdTimer;
    public bool playerDeath;
    public GameObject enterButton;

    public int Health = 3;
    public bool keysСollected;
    private playerController floorSlime;
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        keysСollected = false;
        doorPanel.SetActive(false);
        playerDeath = false;
        totalKeys = 0;
        enterButton.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Show UI keys
        keyText.text = totalKeys.ToString() + " / " + needKeys.ToString();
        healthText.text = " x " + Health.ToString();

        if (totalKeys == needKeys)
        {
            keysСollected = true;
            doorPanel.SetActive(true);
            if (doorPanel == true)
            {
                Timer -= Time.deltaTime;
                if (Timer <= cdTimer)
                {
                    doorPanel.SetActive(false);
                }
            }
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //DamagePlayer
    public void DamagePlayer(int damage)
    {
        Health -= damage;
        if (Health == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
            playerDeath = true;
            keysСollected = false;
            Destroy(gameObject);
            Destroy(gameObject);
        }
    }
    public void KeyTaked(int key)
    {
        totalKeys += key;
    }

    //Go to the next scene
    public void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        keysСollected = false;
        totalKeys = 0;
        Destroy(gameObject);
    }

    //Go to the menu
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        keysСollected = false;
        totalKeys = 0;
    }

    //Restarting the scene
    public void RestartGame()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("SampleScene");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        keysСollected = false;
        totalKeys = 0;
        Destroy(gameObject);
    }
}

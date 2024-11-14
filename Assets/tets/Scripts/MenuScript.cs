using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject panelSetting;
    bool pnlSetting = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void btnSetting()
    {
        if (pnlSetting)
        {
            panelSetting.SetActive(false);
            pnlSetting = false;
        }
        else
        {
            panelSetting.SetActive(true);
            pnlSetting = true;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void PrivacyPolicy()
    {
        Application.OpenURL("...");
    }
    public void btnRating()
    {
        Application.OpenURL("...");
    }
    public void Exit()
    {
        Application.Quit();
    }
}

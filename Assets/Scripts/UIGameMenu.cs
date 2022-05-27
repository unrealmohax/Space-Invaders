using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject PanelVictory;
    [SerializeField] private GameObject PanelDefeat;
    [SerializeField] private GameObject overLay;
    [SerializeField] private Image[] Stars;
    [SerializeField] private Sprite StarActive;
    [SerializeField] private TextMeshProUGUI ScoreWin;
    [SerializeField] private TextMeshProUGUI ScoreDefeat;
    [SerializeField] private GameObject menuPause;

    private void Start()
    {
        Events.Victory.AddListener(OnPanelVictory);
        Events.Defeat.AddListener(OnPanelDefeat);
    }

    private void OnPanelVictory(int Score) 
    {
        ScoreWin.text = "Score: " + Score.ToString();
        overLay.SetActive(true);
        PanelVictory.SetActive(true);
    }

    private void OnPanelDefeat(int Score)
    {
        ScoreDefeat.text = "Score: " + Score.ToString();
        overLay.SetActive(true);
        PanelDefeat.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        overLay.SetActive(false);
        menuPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Paused()
    {
        Time.timeScale = 0;
        menuPause.SetActive(true);
        overLay.SetActive(true);
    }

}

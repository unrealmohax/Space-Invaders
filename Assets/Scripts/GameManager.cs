using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    internal static GameManager Instance;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPlayer;
    [SerializeField] private AudioSource sfx;

    [SerializeField] private int maxLives = 3;
    private int lives;
    
    [SerializeField] private GameObject panelDefeat;
    [SerializeField] private GameObject panelVictory;
    
    [SerializeField] private Text scoreLabel;
    private int score;

    [SerializeField] private SoundsHandler music;

    private void Awake()
    {
        Time.timeScale = 1f;
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        SpawnPlayer();
        lives = maxLives;
        score = 0;
    }

    internal void UpdateScore(int value)
    {
        score += value;
        scoreLabel.text = $"Score: {score}";
    }

    internal void TriggerGameOver(bool failure = true)
    {
        if (failure)
            Events.Defeat?.Invoke(score);
        else
            Events.Victory?.Invoke(score);

        Time.timeScale = 0f;
        music.StopPlaying();
    }

    internal void UpdateLives()
    {
        lives = Mathf.Clamp(lives - 1, 0, maxLives);
        UIHearth.Instance.HeartDisplay(lives);

        if (lives <= 0)
        {
            TriggerGameOver();
        }
        else 
        {
            SpawnPlayer();
        }
        
    }

    internal void PlaySfx(AudioClip clip) => sfx.PlayOneShot(clip);

    private void SpawnPlayer() 
    {
        GameObject Player = Instantiate(player, spawnPlayer.position, Quaternion.identity);
        PlayerShooting playerShooting = Player.GetComponent<PlayerShooting>();
        ButtonAttack.Instance.NewPlayer(playerShooting);
        
    }
}
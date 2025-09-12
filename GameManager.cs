using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Timer")]
    public float gameDuration = 120f; // 2 menit
    public float timeRemaining;
    private bool isGameOver = false;

    [Header("UI")]
    public TMP_Text timerText;
    public GameObject gameOverPanel;
    public TMP_Text hasilKoinText;

    private bool isPaused = false;

    // --- Koin tracking
    private int koinAwal;
    private int koinAkhir;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        timeRemaining = gameDuration;
        gameOverPanel.SetActive(false);

        // simpan jumlah koin saat mulai
        koinAwal = PlayerPrefs.GetInt("Koin", 0);
    }

    void Update()
    {
        if (isGameOver) return;

        // Pause/Resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // Kurangi waktu kalau tidak pause
        if (!isPaused)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                EndGame();
            }
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText != null)
        {
            int menit = Mathf.FloorToInt(timeRemaining / 60);
            int detik = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", menit, detik);
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        gameOverPanel.SetActive(true);

        // ambil koin akhir
        koinAkhir = PlayerPrefs.GetInt("Koin", 0);

        // hitung selisih
        int koinDidapat = koinAkhir - koinAwal;
        if (koinDidapat < 0) koinDidapat = 0; // jaga-jaga kalau bug

        hasilKoinText.text = "Koin didapat: " + koinDidapat;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

}

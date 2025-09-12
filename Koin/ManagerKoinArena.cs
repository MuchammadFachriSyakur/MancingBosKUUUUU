using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerKoinArena : MonoBehaviour
{
    public static ManagerKoinArena instance;
    public int totalKoin = 0;
    public TMP_Text coinText; // drag UI Text ke sini lewat inspector

    void Awake()
    {
        // Singleton biar gampang dipanggil dari script lain
        if (instance == null) instance = this;

        // Load koin dari PlayerPrefs saat game mulai
        totalKoin = PlayerPrefs.GetInt("Koin", 0);
        UpdateUI();
    }

    public void TambahKoin(int jumlah)
    {
        totalKoin += jumlah;

        // Simpan ke PlayerPrefs
        PlayerPrefs.SetInt("Koin", totalKoin);
        PlayerPrefs.Save();

        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Koin: " + totalKoin.ToString();
        }
    }

}

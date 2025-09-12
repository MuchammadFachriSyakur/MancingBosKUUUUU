using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnIkan : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int faseSaatIni = dapetinFase();
        Debug.Log("Sekarang Fase ke:" + faseSaatIni);
    }

    public int dapetinFase()
    {
        // Total Durasi yang sudah di tentukan di Game Manager
        float totalDurasi = gameManager.gameDuration;

        // Waktu yang tersisa
        float waktuSisa = gameManager.timeRemaining;

        // Fase Durasi
        float faseDurasi = totalDurasi / 4f;

        if (waktuSisa > faseDurasi * 3) return 1;
        else if (waktuSisa > faseDurasi * 2) return 2;
        else if (waktuSisa > faseDurasi * 1) return 3;
        else return 4;
    }
}
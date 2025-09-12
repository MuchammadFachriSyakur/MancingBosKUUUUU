using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koin : MonoBehaviour
{
    public GameObject panelMain;
    public GameObject panelBeli;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Area1") == 1)
        {
            panelMain.SetActive(true);
            panelBeli.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Tambah Koin")]
    void ButtonTambah()
    {
        PlayerPrefs.SetInt("Koin", 100);
    }

    public void BeliArea()
    {
        if (PlayerPrefs.GetInt("Koin") >= 45)
        {
            Debug.Log("Area Di Beli");
            PlayerPrefs.SetInt("Area1", 1);
        }
    }
}
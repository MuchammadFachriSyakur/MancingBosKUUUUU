using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengontrol : MonoBehaviour
{
    public Transform kail;         // Object kail
    public Transform posisiAwal;   // Posisi kail awal
    public Transform posisiAkhir;  // Posisi kail akhir
    public float kecepatan = 5f;
    public float kecepatanKapal = 4f;

    private LineRenderer garisKail;

    private bool turun = false;
    private bool naik = false;

    void Start()
    {
        garisKail = GetComponent<LineRenderer>();
        garisKail.positionCount = 2;
    }

    void Update()
    {
        float inputKananKiri = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * inputKananKiri * kecepatanKapal * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E) && !turun && !naik)
        {
            turun = true;
        }

        if (turun)
        {
            kail.position = Vector2.MoveTowards(
                kail.position,
                posisiAkhir.position,
                kecepatan * Time.deltaTime
            );

            if (Vector2.Distance(kail.position, posisiAkhir.position) < 0.05f)
            {
                turun = false;
                naik = true;
            }
        }
        else if (naik)
        {
            kail.position = Vector2.MoveTowards(
                kail.position,
                posisiAwal.position,
                kecepatan * Time.deltaTime
            );

            if (Vector2.Distance(kail.position, posisiAwal.position) < 0.05f)
            {
                naik = false;
            }
        }

        // Garis
        garisKail.SetPosition(0, posisiAwal.position);
        garisKail.SetPosition(1, kail.position);
    }
}
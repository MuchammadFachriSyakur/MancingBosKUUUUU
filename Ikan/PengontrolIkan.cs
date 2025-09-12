using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PengontrolIkan : MonoBehaviour
{
    public List<DistanceJoint2D> ikanNempel = new List<DistanceJoint2D>();
    private ManagerKoinArena managerKoin;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // cari ManagerKoinArena sekali aja di scene
        managerKoin = FindObjectOfType<ManagerKoinArena>();

        if (managerKoin == null)
        {
            Debug.LogError("❌ ManagerKoinArena tidak ditemukan di scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver() || gameManager.IsPaused())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q) && ikanNempel.Count > 0)
        {
            // cek semua ikan
            for (int i = ikanNempel.Count - 1; i >= 0; i--)
            {
                DistanceJoint2D joint = ikanNempel[i];

                if (joint != null)
                {
                    var ikan = joint.GetComponent<Ikan>();
                    if (ikan != null && ikan.sudahMengapung)
                    {
                        // 🎯 Tambah koin
                        if (managerKoin != null)
                        {
                            managerKoin.TambahKoin(ikan.nilaiIkan);
                        }

                        // Lepas joint + hancurin ikan
                        Destroy(joint);
                        Destroy(joint.gameObject);

                        ikanNempel.RemoveAt(i);
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ikan"))
        {
            Rigidbody2D rbIkan = col.GetComponent<Rigidbody2D>();
            if (rbIkan != null)
            {
                var joint = col.gameObject.AddComponent<DistanceJoint2D>();
                joint.connectedBody = GetComponent<Rigidbody2D>(); // kail harus punya Rigidbody2D
                joint.autoConfigureDistance = false;
                joint.distance = 0.5f; // jarak ikan ke kail

                joint.breakForce = 80f;
                joint.breakTorque = 30f;

                ikanNempel.Add(joint);
            }
        }
    }

    void OnJoinBreak2d(Joint2D joint)
    {
        if (joint is DistanceJoint2D dj)
        {
            if (ikanNempel.Contains(dj))
            {
                ikanNempel.Remove(dj);
                Debug.Log("Ikan lepas dari kail");
            }
        }
    }
}
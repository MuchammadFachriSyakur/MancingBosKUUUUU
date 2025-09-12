using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermukaanAir : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ikan"))
        {
            var ikan = col.GetComponent<Ikan>();
            if (ikan != null)
            {
                ikan.sudahMengapung = true;
                Debug.Log("Ikan sudah sampai permukaan, siap dipick!");
            }
        }
    }
}

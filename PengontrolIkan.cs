using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PengontrolIkan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            }
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikan : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform targetPoin;
    public float kecepatanGerak = 2f;
    public int nilaiIkan = 3;
    public bool gantiArah = false;
    private SpriteRenderer sr;
    private Collider2D col;
    public bool sudahMengapung = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // sr.flipX = true;
        col = GetComponent<Collider2D>();

        targetPoin = pointA;

        if ((targetPoin.position.x > transform.position.x && transform.localScale.x < 0) ||
        (targetPoin.position.x < transform.position.x && transform.localScale.x > 0))
        {
            Balik();
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPoin.position,
            kecepatanGerak * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, targetPoin.position) < 0.1f)
        {
            targetPoin = (targetPoin == pointA) ? pointB : pointA;

            if (targetPoin.position.x > transform.position.x)
            {
                Balik();
            }
            else
            {
                Balik();
            }
        }
    }

    void Balik()
    {
        gantiArah = !gantiArah;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        if (col != null)
        {
            Vector2 offset = col.offset;
            offset.x *= -1;
            col.offset = offset;
        }
    }
}
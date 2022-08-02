using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roleta : MonoBehaviour {

    private float cronometro;
    private bool rodar;

    void Start()
    {
        rodar = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rodar == false)
        {
            cronometro = Random.Range(4, 15);
            rodar = true;
        }
        if (rodar == true)
        {
            cronometro -= Time.deltaTime;
            transform.Rotate(0, 0, cronometro);
        }
        if (cronometro <= 0)
        {
            cronometro = 0;
            rodar = false;
        }
    }
}
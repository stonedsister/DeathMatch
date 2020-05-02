using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    public GameObject player;
    public Color blue;
    public Color green;
    public Color blend;
    void Start()
    {
        player = this.gameObject;
        // player.GetComponent<Renderer>().material.color = Color.black;
        blue = Color.blue;
        green = Color.green;
    }

    void Update()
    {
        player.GetComponent<Renderer>().material.color = Color.Lerp(blue, green, 0.25f);
    }
}

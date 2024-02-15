using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip jumpClip;
    public int puntos;
    private int puntosTotales;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MarioScript>())
        {
            puntosTotales = GameManager.instance.GetPoints();
            puntosTotales = puntos + puntosTotales;
            GameManager.instance.SetPoints(puntosTotales);
           
            Destroy(gameObject);
            AudioManager.instance.PlayAudio(jumpClip, "jumpSound");
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

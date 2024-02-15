using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cabeza : MonoBehaviour
{
    public int puntos=1;
    private int puntosTotales;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MarioScript>())
        {
            puntosTotales = GameManager.instance.GetPoints();
            puntosTotales = puntos + puntosTotales;
            GameManager.instance.SetPoints(puntosTotales);
            Destroy(transform.parent.gameObject);

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathzone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)//Lo que hace es que destruye caulquiero objeto que tenga asignado el gameObject

    {
       if(collision.GetComponent<MarioScript>())
        {
            GameManager.instance.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
}



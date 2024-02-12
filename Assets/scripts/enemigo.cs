using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemigo : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 dir;
    private SpriteRenderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), 1f * Time.deltaTime);

        _rend.flipX = false;
        dir = Vector2.right;
        _rend.flipX = false;
        dir = new Vector2(-1, 0);

    } 
        

        private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.GetComponent<MarioScript>())//lo que se choca con el enemgio es el personaje

            GameManager.instance.LoadScene("SampleScene");

        }



    }

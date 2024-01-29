using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;//hace que sea accesible a toodo,no se relacionan los gameobject del juego
    private float time;            // Start is called before the first frame update
    private int points;
    private void Awake()
    {
        if(!instance)//sim se instancia no tiene info
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//se destruye el game onject aunque nsolo haya uno
        }
        else//si tiene info si se instancia
        {
            Destroy(gameObject);
        }



    }







    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
   public float GetTime()
    {
        return time;
    }

    public int GetPoitns() 
    
    {
        return points;
    }

    public  void SetPoints(int value)
    {
        points = value;
    }








}

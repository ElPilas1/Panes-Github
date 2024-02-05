using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameManagerVariables { TIME,POINTS};//EL TIPO ENUMERADO VALE PARA FACILITAR LA LECTURA DEL CODIGO.
    private float time;
    private int points;

    private void Awake()
    {
        // SINGLETON
        if (!instance) // si instance no tiene informacion
        {
            instance = this; // instance se asigna a este objeto
            DontDestroyOnLoad(gameObject); // se indica que este obj no se destruya con la carga de escenas
        }
        else // si instance tiene info
        {
            Destroy(gameObject); // se destruye el gameObject, para que no haya dos o mas gms en el juego
        }
    }

    // Start is called before the first frame update
    void Start()
    {
         GameManager.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    // getter
    public float GetTime()
    {
        return time;
    }

    // getter
    public int GetPoints()
    {
        return points;
    }

    // setter
    public void SetPoints(int value)
    {
        points = value;
    }

    public void LoadScene(string sceneName)
    {
        AudioManager.instance.ClearAudios();
        SceneManager.LoadScene(sceneName);
         
    }
    public void ExitGame()
    {
        Debug.Log("Exit!!");
        Application.Quit();
    }






}

using System.Collections;
using TMPro;
using UnityEngine;

public class updatetext : MonoBehaviour
{
    public GameManager.GameManagerVariables variables;
    private TMP_Text TextComponent;
    // Start is called before the first frame update
     private void Start()
    {
        TextComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {  
        switch(variables)
        {
            case GameManager.GameManagerVariables.TIME:
                TextComponent.text = "Time" + GameManager.instance.GetTime();
                break;
                case GameManager.GameManagerVariables.POINTS:
                TextComponent.text = "Time" + GameManager.instance.GetPoints();
                break;
        }
    }
}//evenclick se crea auto,matica con el canvas y hablita que se decte los eventos de los usuarios sobre los eventes del interfaz,no se puede tocar

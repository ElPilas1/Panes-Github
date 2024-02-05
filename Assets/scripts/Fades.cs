using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fades : MonoBehaviour
{
    private SpriteRenderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());

    }

    IEnumerator  FadeOut() 
    { 
        Color color= _rend.color;//es para guardar el color actual del objeto
      for(float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color color = _rend.color;
        for (float alpha = 0f; alpha >= 1; alpha += 0.01f)
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(FadeOut());
    }

}






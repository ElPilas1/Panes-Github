using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    private List<GameObject> audioObjects;
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        audioObjects = new List<GameObject>();


    }
    public AudioSource PlayAudio(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f)
    {
        GameObject audioObject = new GameObject(gameObjectName);//para darle el nombre e indicarlo a escena
        audioObject.transform.SetParent(transform);
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>();    //le añado el componente al audiosurce
        audioSourceComponent.clip = audioClip;
        audioSourceComponent.volume = volume;
        audioSourceComponent.loop = isLoop;
        audioObjects.Add(audioObject);
        audioSourceComponent.Play();
       
        if (!isLoop)
        {
            StartCoroutine(WaitAudioEnd(audioSourceComponent));//si el audio no esta en loop espera a que se acabe para destruir
        }
        return audioSourceComponent;
    }

    IEnumerator WaitAudioEnd(AudioSource src)//continua IEnumerator que no pasa la ejecucion del progama
    {
        while(src && src.isPlaying)
        {
         yield return null;//corta la ejecucion del mmetodo y la devuelve el control a unity
        }
        Destroy(src.gameObject);
    }
    public void ClearAudios()
    {

        foreach (GameObject audioObject in audioObjects)
        {
            Destroy(audioObject);
        }
        audioObjects.Clear();


    }






}








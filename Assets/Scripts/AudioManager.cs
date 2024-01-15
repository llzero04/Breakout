using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Instantiating the Audio Sources
        for(int itr = 0; itr < sounds.Length; itr++)
        {
            sounds[itr].audioSource = gameObject.AddComponent<AudioSource>();
            sounds[itr].audioSource.clip = sounds[itr].clip;
            sounds[itr].audioSource.loop = sounds[itr].loop;
            sounds[itr].audioSource.volume = sounds[itr].volume;
            sounds[itr].audioSource.pitch = sounds[itr].pitch;
        }
    }

    public void playAudio(string name)
    {
        for(int itr = 0;itr < sounds.Length;itr++)
        {
            if (sounds[itr].soundName.Equals(name))
            {
                sounds[itr].audioSource.Play();
            }
        }
    }

    public void stopAudio(string name)
    {
        for(int itr = 0; itr < sounds.Length ; itr++)
        {
            if (sounds[itr].soundName.Equals(name))
            {
                sounds[itr].audioSource.Stop();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

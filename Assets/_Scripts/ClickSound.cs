using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[RequireComponent(typeof(Button))]

/*public class ClickSound : MonoBehaviour

{
    public AudioClip sound;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Start()
    {
        sound = Resources.Load<AudioClip>("_Audio/leaf.mp3");
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = true;
        button.onClick.AddListener(() => PlaySound());
    }

    // Update is called once per frame
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
}*/
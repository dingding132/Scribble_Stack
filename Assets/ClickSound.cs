using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ClickSound : MonoBehaviour

{
    public AudioClip sound;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
	public void PlaySound()
    {
		sound = Resources.Load<AudioClip>("_Audio/" + (GameObject.Find("_Manager").GetComponent<MainController>().SecretWord));
		gameObject.AddComponent<AudioSource>();
		source.clip = sound;
		source.playOnAwake = true;
		source.PlayOneShot(sound);
    }
}
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public dzwiek[] dzwieki;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(dzwiek s in dzwieki)
        {
            s.zrudlo = gameObject.AddComponent<AudioSource>();
            s.zrudlo.clip = s.clip;
            s.zrudlo.volume = s.glosnosc;
            s.zrudlo.pitch = s.pitch;
            s.zrudlo.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("podklad");
    }

    public void Play(string nazwa)
    {
        dzwiek s = Array.Find(dzwieki, dzwiek => dzwiek.nazwa == nazwa);
        if (s == null) return;
        s.zrudlo.Play();
    }
}

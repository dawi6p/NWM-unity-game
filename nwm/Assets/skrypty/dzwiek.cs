using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class dzwiek 
{
    public string nazwa;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float glosnosc;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource zrudlo;
}

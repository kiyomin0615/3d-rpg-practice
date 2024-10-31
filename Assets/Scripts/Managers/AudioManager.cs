using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    const int AudioTypeCount = 2;
    AudioSource[] sources = new AudioSource[AudioTypeCount];

    public void Init()
    {
        GameObject audioRoot = GameObject.Find("@AudioRoot");
        if (audioRoot == null)
        {
            audioRoot = new GameObject() { name = "@AudioRoot" };
            Object.DontDestroyOnLoad(audioRoot);

            string[] audioTypeNames = System.Enum.GetNames(typeof(Definition.AudioType));
            for (int i = 0; i < audioTypeNames.Length; i++)
            {
                GameObject audio = new GameObject() { name = audioTypeNames[i] };
                sources[i] = audio.AddComponent<AudioSource>();
                audio.transform.SetParent(audioRoot.transform, false);
            }

            sources[(int)Definition.AudioType.BGM].loop = true;
        }
    }

    public void Play(Definition.AudioType type, string path, float pitch = 1.0f)
    {
        if (path.Contains("Audios/") == false)
            path = $"Audios/{path}";

        if (type == Definition.AudioType.BGM)
        {
            AudioClip clip = Manager.Resource.Load<AudioClip>(path);
            if (clip == null)
            {
                Debug.Log($"Audio Clip Missing. {path}");
                return;
            }

            // TODO : Play BGM

        }
        else
        {
            AudioClip clip = Manager.Resource.Load<AudioClip>(path);
            if (clip == null)
            {
                Debug.Log($"Audio Clip Missing. {path}");
                return;
            }

            AudioSource source = sources[(int)Definition.AudioType.SFX];

            source.pitch = pitch;
            source.PlayOneShot(clip);
        }
    }
}

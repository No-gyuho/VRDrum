using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // 일정 시간 뒤 자동 재생
        Invoke(nameof(PlayMusic), 1f); // 1초 후 재생 (노트 스폰 타이밍 맞춤)
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

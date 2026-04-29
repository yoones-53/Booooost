using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 넘어가도 안 사라짐
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // 중복 생성 방지
        }
    }
}
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // 싱글톤 객체 생성

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
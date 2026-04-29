using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Movement")]
    public float thrustForce = 4f; // 추진 속도치
    public float rotateSpeed = 120f; // 회전 속도치
    public float maxSpeed = 9f; // 최고 속도 조정치

    [Header("Sounds")]
    public AudioSource engineSound; // 엔진 사운드
    public AudioSource explodeSound; // 폭발 사운드

    [Header("Sprites")]
    public Sprite idleSprite; // 대기 상태 스프라이트
    public Sprite thrustSprite; // 추진 상태 스프라이트
    public Sprite explodeSprite;  // 폭발 상태 스프라이트

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGameOver = false; // 게임 오버시 true
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (sr != null && idleSprite != null) // 대기 스프라이트
        {
            sr.sprite = idleSprite;
        }
    }

    void Update()
    {
        if (isGameOver) // 게임 오버시 아래 기능 작동 X
        {
            return;
        }

        HandleThrust(); // 로켓 추진 기능
        HandleRotation(); // 로켓 회전 기능
    }

    void HandleThrust() // 로켓 추진
    {
        bool isThrusting = Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0); // 좌클릭 또는 스페이스바

        if (isThrusting) // 추진 중일때
        {
            rb.AddForce(transform.up * thrustForce * Time.deltaTime); // 가속 공식
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed); // 최고 속도 조정

            sr.sprite = thrustSprite; // 추진 스프라이트

            if (!engineSound.isPlaying) // 엔진 소리
            {
                engineSound.Play();
            }
        }
        else // 추진 중이 아닐때
        {
            if (sr != null && idleSprite != null) // idle sprite
            {
                sr.sprite = idleSprite; 
            }
            if (engineSound.isPlaying) // 엔진 소리 끄기
            {
                engineSound.Stop();
            }
        }
    }

    void HandleRotation() // 로켓 회전
    {
        float rotateInput = 0f; // 회전 입력 받기

        if (Input.GetKey(KeyCode.A)) // A누르면 좌로 회전
        {
            rotateInput = 1f;
        }
        else if (Input.GetKey(KeyCode.D)) // D누르면 우로 회전
        {
            rotateInput = -1f;
        }

        transform.Rotate(0f, 0f, rotateInput * rotateSpeed * Time.deltaTime); // 회전 공식
    }
    public void Explode() // 로켓 폭발
    {
        isGameOver = true; // 폭발시 게임오버

        if (sr != null && explodeSprite != null) // 폭발 스프라이트
        {
            sr.sprite = explodeSprite;
        }
        explodeSound.Play(); // 폭발 소리
        
        rb.simulated = false; // 폭발시 로켓 위치 고정
    }
}

using UnityEngine;

public class FadeEnemy : MonoBehaviour
{
    public Transform player; // 플레이어
    public float fadeDistance = 13f; // 감지 범위
    public float fadeSpeed = 5f; // 투명화 속도

    private SpriteRenderer spriteRenderer;
    private float currentAlpha = 1f; // 초기 투명화값

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (player == null) // 플레이어 태그로 플레이어 찾기
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            player = found.transform;
        }
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position); // 플레이어와 거리 계산

        float targetAlpha = 1f; // 초기 투명화값

        if (distance <= fadeDistance) // 플레이어가 가까워지면
        {
            float t = distance / fadeDistance; // 거리 비율 계산
            targetAlpha = Mathf.Lerp(-1f, 1f, t); // 가까울수록 투명
        }

         // 부드럽게 변경 하기 위해서 지연 불투명
        currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * fadeSpeed);

        Color color = spriteRenderer.color;
        color.a = currentAlpha; // 알파 가져오기
        spriteRenderer.color = color; // 알파값 변경
    }
}
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;

    private float groundHorizontalLength; // 배경 X축 길이
    public Transform player; // 플레이어 오브젝트

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();

        groundHorizontalLength = groundCollider.bounds.size.x; // 배경 사이즈
    }

    void Update()
    {
        float distance = player.position.x - transform.position.x; // 현재 배경에서의 플레이어 위치

        if (distance > groundHorizontalLength) // 위치가 절반 이상일때 (배경 오른쪽)
        {
            RepositionBackground(1); // 다른 배경이 우로 이동
        }
        else if (distance < -groundHorizontalLength) // 위치가 절반 이하일때 (배경 왼쪽)
        {
            RepositionBackground(-1); // 다른 배경이 좌으로 이동
        }
    }

    void RepositionBackground(int dir) // 배경 반복
    {
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f * dir, 0); // 배경 이동 공식
        transform.position = (Vector2) transform.position + groundOffSet; // 배경 이동
    }
}
using UnityEngine;

public class EnemyMoveHorizontal : MonoBehaviour
{
    public float moveDistance = 2f;   // 시작점 기준 좌우 이동 거리
    public float moveSpeed = 2f;      // 이동 속도

    private Vector2 startPos; // 시작 위치

    void Start()
    {
        startPos = transform.position; // 현재 위치를 시작 위치로 저장
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * moveSpeed) * moveDistance; // 이동 범위
        transform.position = new Vector2(startPos.x + x, startPos.y); // y위치 고정
    }
}
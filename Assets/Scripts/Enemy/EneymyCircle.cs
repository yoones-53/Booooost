using UnityEngine;

public class EnemyCircle : MonoBehaviour
{
    public float radius = 2f;       // 원 크기
    public float moveSpeed = 2f;    // 회전 속도

    private Vector2 centerPos; // 기준점점

    void Start()
    {
        centerPos = transform.position; // 기준점을 위치로 저장
    }

    void Update()
    {
        float x = Mathf.Cos(Time.time * moveSpeed) * radius; // X축 이동
        float y = Mathf.Sin(Time.time * moveSpeed) * radius; // Y축 이동

        transform.position = new Vector2(centerPos.x + x, centerPos.y + y); // 기준점에서 원형 이동
    }
}
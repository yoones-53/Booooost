using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 6f; // 탄속
    private Vector2 moveDirection; // 이동 방향

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // 각도
        transform.rotation = Quaternion.Euler(0, 0, angle); // 이동 방향으로 총알 회전
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime); // 총알 이동 공식
    }
}
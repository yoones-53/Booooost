using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6f;
    private Vector2 moveDirection;

    public void SetDirection(Vector2 moveDirection)
    {
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg; // 각도
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * bulletSpeed * Time.deltaTime);
    }
}
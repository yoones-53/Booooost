using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6f;
    public float destroyTimer = 1f;
    private Vector2 moveDirection;

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
    void Update()
    {
        transform.position += (Vector3)(moveDirection * bulletSpeed * Time.deltaTime);
    }
}
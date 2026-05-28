using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    public Transform mainCamera;

    public float scrollSpeed = 0.5f;

    private Vector3 lastCameraPosition;

    void Start()
    {
        lastCameraPosition = mainCamera.position;
    }

    void Update()
    {
        Vector3 deltaMovement = mainCamera.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * scrollSpeed, deltaMovement.y * scrollSpeed, 0f);
        lastCameraPosition = mainCamera.position;
    }
}

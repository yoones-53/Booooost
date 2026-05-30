using UnityEngine;

public class PlatformUIManager : MonoBehaviour
{
    [SerializeField] GameObject mobileControlUI;

    void Start()
    {
        bool isMobileWeb =
            Application.platform == RuntimePlatform.WebGLPlayer &&
            Input.touchSupported;

        bool isMobileApp =
            Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer;

        mobileControlUI.SetActive(isMobileWeb || isMobileApp);
    }
}
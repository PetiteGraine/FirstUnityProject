using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    void Update()
    {
        transform.LookAt(transform.position + playerCamera.transform.forward);
    }
}

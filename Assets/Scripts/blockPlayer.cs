using UnityEngine;

public class blockPlayer : MonoBehaviour
{
    public GameObject TopMount;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = TopMount.transform.position + offset;
    }
}

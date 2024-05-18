using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject spear;
    public float moveSpeed = 400f;
    private float HorizontalMovement;
    private float VerticalMovement;
    public float shootSpeed = 300f;
    public bool facingLeft = false;
    [SerializeField] float shootAngle = 90f;
    private inputScript pinScript;

    // public Animator playerAnimator;
    public Transform firePoint;
    private PlayerMovement movement;
    void Start()
    {
        pinScript = GameObject.Find("Pin input").GetComponent<inputScript>();
        movement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");

        // playerAnimator.SetFloat("Horizontal", HorizontalMovement);
        // playerAnimator.SetFloat("Vertical", VerticalMovement);

    }
    void LateUpdate()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        pinScript.inputIsActive = false;
        movement.enabled = false;

        if (pinScript.inputIsActive == true) movement.enabled = false; 
        else movement.enabled = true;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        Move(Vector2.up, HorizontalMovement);
        Move(Vector2.left, VerticalMovement);

        if (Input.GetMouseButtonDown(0)) ShootSpear(firePoint, angle);
    }
    void ShootSpear(Transform firePoint, float angle)
    {
        GameObject spearPrefab = Instantiate(spear);
        spearPrefab.transform.position = firePoint.position;
        spearPrefab.transform.rotation = Quaternion.AngleAxis(angle - shootAngle, Vector3.forward);

        spearPrefab.GetComponent<Rigidbody2D>().velocity = firePoint.right * shootSpeed;
    }
    void Move(Vector2 moveDirection, float movementType)
    {
        transform.Translate(moveDirection * movementType * moveSpeed *  Time.deltaTime);
    }

}

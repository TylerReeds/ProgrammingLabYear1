using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDataPersistance
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationalSpeed = 75f;
    [SerializeField] private float jumpVelocity = 5f;

    [Header("Checks")]
    [SerializeField] private float distanceToGround = 1.25f;
    [SerializeField] private LayerMask groundLayer;

    private float vInput;
    private float hInput;
    private Rigidbody rb;

    public Vector2 turn;
    public float sensitivity = 0.5f;

    CharacterStats Stats;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        TurnPlayer();
        Jump();
    }

    private void MovePlayer()
    {
        vInput = Input.GetAxis("Vertical") * movementSpeed;
        hInput = Input.GetAxis("Horizontal") * movementSpeed;

        transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        transform.Translate(Vector3.right * hInput * Time.deltaTime);

    }

    private void Jump()
    {
        bool isPlayerGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToGround, groundLayer);

        if (isPlayerGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
    }
    public void TurnPlayer()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = transform.position;
    }

    public void LoadData(GameData data)
    {
        transform.position = data.playerPosition;
    }
}

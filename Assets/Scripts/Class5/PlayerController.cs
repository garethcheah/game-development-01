using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float appliedForce = 10f;
    public List<GameObject> gameObjects = new List<GameObject>();
    public bool isReleased = false;

    private GameObject currentBall;

    [SerializeField]
    private string aimPropertyName = "Aiming";

    [SerializeField]
    private float maxHorizontal = 0.5f;

    [SerializeField]
    private float minHorizontal = -0.5f;

    // Alternatively, we can set the animator by using GetComponentInChildren<Animator>();
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody rbBall;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isReleased)
        {
            StartAim();
            HorizontalAim();
            ReleaseBall();
        }
    }

    private void StartAim()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            int randomIndex = Random.Range(0, gameObjects.Count);

            // Instantiate new ball
            currentBall = Instantiate(gameObjects[randomIndex], transform.position, Quaternion.identity);

            // Adding reference to parent transform so that the ball follows horizontal aim
            currentBall.transform.parent = transform;

            animator.SetBool(aimPropertyName, true);
        }
    }

    private void HorizontalAim()
    {
        // Gets input from axis
        float input = Input.GetAxis("Horizontal");

        //Invert input as the left/right arrow keys are going in the opposite direction
        input = -input;

        // Calculates movement
        Vector3 movement = new Vector3(0f, 0f, input * speed * Time.deltaTime);

        // Applies movement
        transform.Translate(movement);

        // Clamp position (only moves the width of the lane)
        Vector3 clampPosition = transform.position;
        clampPosition.z = Mathf.Clamp(clampPosition.z, minHorizontal, maxHorizontal);
        transform.position = clampPosition;
    }

    private void ReleaseBall()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            animator.SetBool(aimPropertyName, false);
            rbBall = currentBall.GetComponent<Rigidbody>();
            rbBall.AddForce(animator.gameObject.transform.forward.normalized * appliedForce, ForceMode.Impulse);
            isReleased = true;
        }
    }
}

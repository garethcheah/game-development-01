using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float appliedForce = 10f;
    public List<GameObject> bowlingBalls = new List<GameObject>();
    public bool isReleased = false;

    private GameObject _currentBall;

    [SerializeField] private string _aimPropertyName = "Aiming";
    [SerializeField] private float _maxHorizontal = 0.5f;
    [SerializeField] private float _minHorizontal = -0.5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rbBall;

    // Start is called before the first frame update
    void Start()
    {
        StartAim();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReleased)
        {
            HorizontalAim();
            ReleaseBall();
        }
    }

    public void StartAim()
    {
        int randomIndex = Random.Range(0, bowlingBalls.Count);

        // Instantiate new ball
        _currentBall = Instantiate(bowlingBalls[randomIndex], transform.position, Quaternion.identity);

        // Adding reference to parent transform so that the ball follows horizontal aim
        _currentBall.transform.parent = transform;

        _animator.SetBool(_aimPropertyName, true);
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
        clampPosition.z = Mathf.Clamp(clampPosition.z, _minHorizontal, _maxHorizontal);
        transform.position = clampPosition;
    }

    private void ReleaseBall()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _animator.SetBool(_aimPropertyName, false);
            _rbBall = _currentBall.GetComponent<Rigidbody>();
            _rbBall.AddForce(_animator.gameObject.transform.forward.normalized * appliedForce, ForceMode.Impulse);
            isReleased = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowlingAssingment
{
    public class BowlingBall : MonoBehaviour
    {
        [SerializeField]
        private float appliedForce = 10f;
        private Rigidbody rigidbody;

        // Awake is called before Start
        private void Awake()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddForce();
            }
        }

        // FixedUpdate is called every fixed framerate frame
        private void FixedUpdate()
        {
            
        }

        private void AddForce()
        {
            rigidbody.AddForce(Vector3.right.normalized * appliedForce, ForceMode.Impulse);
        }
    }
}

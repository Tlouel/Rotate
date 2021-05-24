using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    Vector3 forward, right;

    bool jump = false;

    float jumpH = 0.3f;
    float jumpS = 0.5f;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !jump)
        {
           StartCoroutine(Jump());
           
        }
        else
        {
            Move();
        }

        if(rb.position.y < -8 )
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Map1");
            
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMov = right * speed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMov = forward * speed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMov + upMov);

        transform.forward = heading;
        transform.position += rightMov;
        transform.position += upMov;

    }

    IEnumerator Jump()
    {
        float originalH = transform.position.y;
        float maxH = originalH + jumpH;

        rb.useGravity = false;

        jump = true;
        yield return null;

        //rb.AddForce(Vector3.up * jumpH, ForceMode.Impulse);

        while(transform.position.y < maxH)
        {
            transform.position += transform.up * Time.deltaTime * jumpS;
            yield return null;
        }

        //rb.useGravity = true;

        while(transform.position.y > originalH)
        {

          transform.position -= transform.up * Time.deltaTime * jumpS;  
          yield return null;
        }

        rb.useGravity = true;
        jump = false;

        yield return null;
    }
}

using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    public GameObject projectilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Keep it in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(
                -xRange,
                transform.position.y,
                transform.position.z);
        }
        if (transform.position.x > xRange) 
        {
            transform.position = new Vector3(
                xRange,
                transform.position.y,
                transform.position.z);
        }

        // Launch a projectile from the player with spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}

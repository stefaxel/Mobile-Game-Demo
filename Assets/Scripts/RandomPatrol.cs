using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float speed;

    Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPos();
        }
    }

    Vector2 GetRandomPos()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Planets")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

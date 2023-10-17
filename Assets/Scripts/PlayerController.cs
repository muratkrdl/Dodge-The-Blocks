using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float slowness = 10f;
    [SerializeField] float restartGameDelay = 2f;
    [SerializeField] float xClampPos = 9;

    bool isCollide = false;

    void FixedUpdate()
    {
        if(isCollide)
            return;
        Move();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 newPos = transform.position;
        newPos.x += moveInput * moveSpeed * Time.fixedDeltaTime;

        newPos.x = Mathf.Clamp(newPos.x, -xClampPos, xClampPos);

        transform.position = newPos;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            isCollide = true;
            StartCoroutine(RestartGame());
        }    
    }

    IEnumerator RestartGame()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime /= slowness;

        yield return new WaitForSeconds(restartGameDelay / slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime *= slowness;

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

}

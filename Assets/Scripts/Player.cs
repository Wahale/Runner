using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditorInternal;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Animator animator;
    private Rigidbody rb;
    public bool start;
    public Text run;
    public Text lives;
    public Text deth;
    public int g = 2;
    public GameObject Coins;

    public Text score;
    public int scorePoint;
    private float[] positions = { -4.841f, -3.903f, -3.054f };


    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (g == 2 || g == 0)
        {
            lives.text = g + "жизней";
        }
        else if (g == 1)
        {
            lives.text = g + "жизнь";
        }


        if (start)
        {
            animator.SetTrigger("Start");

            float hor = Input.GetAxisRaw("Horizontal");

            //Вызов корутины
            StartCoroutine(Move(hor));

            //Прыжок
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                animator.SetTrigger("Jump");
            }

            
        }

        if(g == 0)
        {
            start = false;
            image.SetActive(true);
            animator.SetTrigger("Deth");
            deth.enabled = true;
        }
    }

    /// <summary>
    /// Корутина движения
    /// </summary>
    /// <param name="hor"></param>
    /// <returns></returns>
    IEnumerator Move(float hor)
    {
        Vector3 dir = new Vector3(hor, 0, 0);
        transform.Translate(dir.normalized * Time.deltaTime * speed);
        yield return null; 
    }

    /// <summary>
    /// Включение анимации при падении
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("floorTwo"))
        {
            animator.SetTrigger("Fall");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score"))
        {
            scorePoint++;
            score.text = scorePoint.ToString();
            Destroy(other.gameObject);
        }
    }

    public GameObject image;
    public bool youCan;

    public void OpenMenu()
    {
        image.SetActive(true);
        start = false;
        youCan = true;
    }

    public void StartGame()
    {
        start = true;
        if (start)
            image.SetActive(false);
    }

    public void RestartGame()
    {
        if (youCan)
            SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        if (youCan)
        {
            start = true;
            image.SetActive(false);
        }
    }
}

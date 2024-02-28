using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLogic : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 0.01f;
    public float jumpforce = 5;
    public float moveSpeed = 10;
    private bool hasJumped = false;
    public GameObject textInputFieldHolder;
    public Animator animator;
    public QuestionAreaLogic questionAreaLogic;
    public SubmitAnswerLogic submitAnswerLogic;
    public TMPro.TextMeshProUGUI questionText;
    public TMPro.TextMeshProUGUI instructionText;
    public bool hasFired = false;

    private string instruction = "";



    // If the player has already jumped, then they cannot jump again until they land
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null)
        {
            Debug.Log("No collision object for player jump");
        }
        hasJumped = false;
        if (collision.gameObject.CompareTag("Killer"))
        {
            animator.SetTrigger("is_dead");
            Debug.Log("Player has collided with killer");
            player.bodyType = RigidbodyType2D.Static;
            // Destroy(gameObject);

        }

    }
    void Start()
    {
        questionAreaLogic = GameObject.FindGameObjectWithTag("QuestionArea").GetComponent<QuestionAreaLogic>();
        submitAnswerLogic = GameObject.FindGameObjectWithTag("AnswerTracker").GetComponent<SubmitAnswerLogic>();
        questionText = GameObject.FindGameObjectWithTag("Question").GetComponent<TMPro.TextMeshProUGUI>();
        instructionText = GameObject.FindGameObjectWithTag("InGameInstruction").GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("is_running", true);
        }
        else
        {
            animator.SetBool("is_running", false);
        }


        {
            if (Input.GetKey(KeyCode.UpArrow) && !hasJumped)
            {
                Debug.Log("Player Jumped should be False, is: " + hasJumped);
                player.velocity = Vector3.up * jumpforce;
                hasJumped = true;
                Debug.Log("Player Jumped should be True, is: " + hasJumped);

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                player.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, player.velocity.y);
                player.transform.localScale = new Vector3(-1, 1, 1);
                Debug.Log("player moving left, x component of vector should be negative, is: " + player.transform.localScale);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, player.velocity.y);
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("player moving left, x component of vector should be positive, is: " + player.transform.localScale);

            }
            if (!questionAreaLogic.isInZone)
            {
                if (textInputFieldHolder.activeInHierarchy)
                {
                    Debug.Log("textInputFieldHolder is True, should be False, Set to False");
                }
                textInputFieldHolder.SetActive(false);
                questionText.text = "";
                instruction = "";
                instructionText.text = "";
            }
            if (questionAreaLogic.isInZone)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    textInputFieldHolder.SetActive(true);
                    Debug.Log("textInputFieldHolder should be " + Input.GetKeyDown(KeyCode.E) + ", is: " + textInputFieldHolder.activeInHierarchy);
                }
                questionText.text = submitAnswerLogic.question;
                instruction = "Press 'E' to answer.";
                instructionText.text = instruction;
            }

        }
    }

}
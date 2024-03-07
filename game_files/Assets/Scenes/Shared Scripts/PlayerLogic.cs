using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public GameOverUI GameOverUI;

    [Header("Player Settings")]
    public Rigidbody2D player;
    [Range(0.01f, 0.1f)] public float speed = 0.01f;
    [Range(1, 50)] public float jumpForce = 5;
    [Range(1, 10)] public float moveSpeed = 10;

    [Header("UI Elements")]
    public GameObject textInputFieldHolder;
    public GameObject fence;
    [HideInInspector] public Animator animator;
    [HideInInspector] public QuestionAreaLogic questionAreaLogic;
    [HideInInspector] public SubmitAnswerLogic submitAnswerLogic;
    [HideInInspector] public TMPro.TextMeshProUGUI questionText;
    [HideInInspector] public TMPro.TextMeshProUGUI instructionText;
    [HideInInspector] public bool hasFired = false;
    [HideInInspector] private bool hasJumped = false;

    AudioScript audio;
    private string instruction = "";
    private QuestionManager questionObject;
    QuestionManager.Question questionClass;
    bool questionAsk = false;
    bool checkText = true;



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
            HandlePlayerDeath();
        }
    }

    void Start()
    {
        InitializeComponents();
    }

    void Update()
    {
        HandleRunningAnimation();

        if (Input.GetKey(KeyCode.UpArrow) && !hasJumped)
        {
            HandleJump();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            HandleHorizontalMovement(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            HandleHorizontalMovement(1);
        }

        HandleQuestionArea();
    }

    void InitializeComponents()
    {
        questionAreaLogic = GameObject.FindGameObjectWithTag("QuestionArea").GetComponent<QuestionAreaLogic>();
        submitAnswerLogic = GameObject.FindGameObjectWithTag("AnswerTracker").GetComponent<SubmitAnswerLogic>();
        questionText = GameObject.FindGameObjectWithTag("Question").GetComponent<TMPro.TextMeshProUGUI>();
        instructionText = GameObject.FindGameObjectWithTag("InGameInstruction").GetComponent<TMPro.TextMeshProUGUI>();
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioScript>();
    }

    public void HandlePlayerDeath()
    {
        animator.SetTrigger("is_dead");
        audio.PlaySFX(audio.fireSound);
        Debug.Log("Player has collided with killer");
        player.bodyType = RigidbodyType2D.Static;
        audio.GameOver();
        Destroy(audio.gameObject, 1.5f);
        gameOver();
    }

    public void gameOver()
    {
        // Time.timeScale = 0f;
        GameOverUI.setup();
    }

    void HandleRunningAnimation()
    {
        animator.SetBool("is_running", Input.GetAxis("Horizontal") != 0);
    }

    public void HandleJump()
    {
        Debug.Log("Player Jumped should be False, is: " + hasJumped);
        player.velocity = Vector3.up * jumpForce;
        hasJumped = true;
        Debug.Log("Player Jumped should be True, is: " + hasJumped);
    }

    public void HandleHorizontalMovement(int direction)
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, player.velocity.y);
        player.transform.localScale = new Vector3(direction, 1, 1);
        Debug.Log($"Player moving {(direction == -1 ? "left" : "right")}, x component of vector should be {direction}, is: {player.transform.localScale}");
    }

    void HandleQuestionArea()
    {
        if (!questionAreaLogic.isInZone)
        {
            questionAsk = false;
            checkText = false;
            DisableTextInput();
        }
        else
        {
            EnableTextInput();
        }
    }

    void ResetUIElements()
    {
        instructionText.text = "";
        questionText.text = "";
    }

    void DisableTextInput()
    {
        if (textInputFieldHolder.activeInHierarchy)
        {
            Debug.Log("textInputFieldHolder is True, should be False, Set to False");
        }
        textInputFieldHolder.SetActive(false);
        ResetUIElements();
    }

    void EnableTextInput()
    {
        questionObject = GameObject.Find("QuestionArea").GetComponent<QuestionManager>();
        questionObject.LoadQuestions();
        if (questionAsk == false)
        {
            questionClass = (questionObject.GetRandomQuestion(1));
            questionText.text = questionClass.question;
            var questionID = questionClass.id;
            questionAsk = true;
        }
        instruction = "Press 'E' to answer.";
        instructionText.text = instruction;

        if (Input.GetKeyDown(KeyCode.E))
        {

            textInputFieldHolder.SetActive(true);
            textInputFieldHolder.GetComponentInChildren<InputField>().ActivateInputField();
            textInputFieldHolder.GetComponentInChildren<InputField>().Select();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var text = textInputFieldHolder.GetComponentInChildren<InputField>().text;
            Debug.Log($"text: {text}, answer: {questionClass.correctAnswer},");
            if (text == questionClass.correctAnswer)
            {
                Debug.Log("Inputed correct answer.");
                DisableTextInput();
                audio.PlaySFX(audio.correctSound);
                fence.SetActive(false);
                checkText = false;
            }
        }
        // Debug.Log($"textInputFieldHolder should be {Input.GetKeyDown(KeyCode.E)}, is: {textInputFieldHolder.activeInHierarchy}");
    }


}

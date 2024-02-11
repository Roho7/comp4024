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
    public QuestionAreaLogic questionAreaLogic;
    public Text questionText;
    public Text instructionText;

    private string instruction = "";

    // If the player has already jumped, then they cannot jump again until they land
    void OnCollisionEnter2D(Collision2D collision)
    {

        hasJumped = false;

    }
    void Start()
    {
        questionAreaLogic = GameObject.FindGameObjectWithTag("QuestionArea").GetComponent<QuestionAreaLogic>();
        questionText = GameObject.FindGameObjectWithTag("Question").GetComponent<Text>();
        instructionText = GameObject.FindGameObjectWithTag("InGameInstruction").GetComponent<Text>();
    }

    void Update()
    {

        {
            if (Input.GetKey(KeyCode.UpArrow) && !hasJumped)
            {
                player.velocity = Vector3.up * jumpforce;
                hasJumped = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, player.velocity.y);
                player.transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, player.velocity.y);

                player.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (!questionAreaLogic.isInZone)
            {
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
                }
                questionText.text = "2+2=?";
                instruction = "Press 'E' to answer the question.";
                instructionText.text = instruction;
            }
        }
    }
}
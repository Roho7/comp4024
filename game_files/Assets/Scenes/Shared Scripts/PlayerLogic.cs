using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLogic : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 0.01f;
    public float jumpforce = 5;
    private bool hasJumped = false;
    public GameObject textInputFieldHolder;
    public QuestionAreaLogic questionAreaLogic;
    public Text questionText;
    public Text instructionText;

    private string instruction = "";

    // Start is called before the first frame update

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

    // Update is called once per frame

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
                player.transform.position += new Vector3(-speed, 0, 0);
                player.transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player.transform.position += new Vector3(speed, 0, 0);
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
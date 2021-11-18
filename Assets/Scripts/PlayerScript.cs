using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour {


    public TextMeshProUGUI timetext;
    public TextMeshProUGUI pointtext;
    public TextMeshProUGUI ruletext;
    private float secCount;

    public float speed = 7;
    public GameObject end;
    public GameObject block;

    private Rigidbody rb;
    private int points;

    private float movementX;
    private float movementY;

   public void UpdateTimerUI(){
       if(timetext.enabled == true){
           SetPointText();
        secCount += Time.deltaTime;
        timetext.text = secCount.ToString();
       }
    }

   
    void Update(){
        UpdateTimerUI();
        if(points >= 5){
            block.SetActive (false);
        }
    }

    
    void Start() {
        timetext.enabled = false;
        pointtext.enabled = false;
        rb = GetComponent<Rigidbody>();
    }

     void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag ("End")){
            timetext.enabled = false;
            SceneManager.LoadScene(2);
        }

        if(other.gameObject.CompareTag ("EndTwo")){
            timetext.enabled = false;
            SceneManager.LoadScene(1);
        }

        if(other.gameObject.CompareTag ("Start")){
            timetext.enabled = true;
            ruletext.enabled = false;
        }

        if(other.gameObject.CompareTag ("Point")){
            points++;
            SetPointText();
            other.gameObject.SetActive (false);
        }

        if(other.gameObject.CompareTag ("Block")){
            other.gameObject.SetActive (false);
        }

        }

        void SetPointText(){
            pointtext.enabled = true;
            pointtext.text = "Points: " + points.ToString() + "/5";
            
        }
    }

    
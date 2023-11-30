using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    int frontSpeed = 0;
    int sideSpeed = 0;
    [SerializeField] Text text;
    [SerializeField] Text complete_text;
    bool got_quest = false;

    private void restart()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
       rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(new Vector3(this.transform.position.x + frontSpeed * Time.deltaTime, this.transform.position.y, 
            this.transform.position.z + sideSpeed * Time.deltaTime));
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow)) { sideSpeed = 5; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { sideSpeed = -5; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { frontSpeed = 5; }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { frontSpeed = -5; }

        if (Input.GetKeyUp(KeyCode.UpArrow)) { sideSpeed = 0; }
        if (Input.GetKeyUp(KeyCode.DownArrow)) { sideSpeed = 0; }
        if (Input.GetKeyUp(KeyCode.RightArrow)) { frontSpeed = 0; }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) { frontSpeed = 0; }
    }

    private void end(string status)
    {
        if (got_quest)
        {
            text.text = "";
            complete_text.text = "Задание " + status;
            Invoke("restart", 2f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "quest")
        {
            text.text = "Войди красный квадрат";
            got_quest = true;
        }
        else if (other.gameObject.tag == "red")
        {
            end("выполнено");
        }
        else if (other.gameObject.tag == "green")
        {
            end("провалено");
        }
        else if (other.gameObject.tag == "blue")
        {
            end("провалено");
        }
    }
}

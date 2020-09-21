using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float force;
    public Text textTime;
    public Button botonRestart;

    private float timeValue;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        timeValue = 30;
        botonRestart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameOver)
        {
            Move();
            TimeCounter();
        }


    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 vector = new Vector3(horizontal, 0.5f, vertical);

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(vector * force * Time.deltaTime);
    }

    private void TimeCounter()
    {
        timeValue -= Time.deltaTime;
        if (timeValue <= 0f)
        {
            timeValue = 0.0f;
            gameOver = true;
            botonRestart.gameObject.SetActive(true);
        }
        textTime.text = "Tiempo: " + timeValue.ToString("F2");
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Finish")
        {
            if (Application.loadedLevelName == "Main")
            {
                Application.LoadLevel("Scene1");
            }
            else
            {
                Application.LoadLevel("Main");
            }
        }
    }

    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

}

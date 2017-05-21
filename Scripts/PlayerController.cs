using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text Żetony;
    public Text Punkty;
    Rigidbody2D rbody;
    Animator anim;

    private Rigidbody2D rb2d;
    private int countpunkty;
    private int countżetony;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        countpunkty = 0;
        countżetony = 0;

        SetŻetonyText();
        SetPunktyText();

        var newX = PlayerPrefs.GetFloat("PlayerX");
        var newY = PlayerPrefs.GetFloat("PlayerY");
        var newZ = PlayerPrefs.GetFloat("PlayerZ");
        transform.position = new Vector3(newX, newY, newZ);

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        Vector2 movement_axis_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(movement_axis_vector != Vector2.zero)
        {
            anim.SetBool("is_walking", true);
            anim.SetFloat("input_x", movement_axis_vector.x);
            anim.SetFloat("input_y", movement_axis_vector.y);

        }
        else
        {
            anim.SetBool("is_walking", false);
        }

        rbody.MovePosition(rbody.position + movement_axis_vector * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movemenet = new Vector2(moveHorizontal, moveVertical);
        //rb2d.AddForce(movemenet * speed);
    }


    void SetŻetonyText()
    {
        Żetony.text = "" + PlayerPrefs.GetInt("zetony").ToString();

    }

    void SetPunktyText()
    {
        Punkty.text = "" + PlayerPrefs.GetInt("punkty").ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Marker1"))
        {
            PlayerPrefs.SetFloat("PlayerX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", transform.position.y-0.2f);
            PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
            Application.LoadLevel("Building1");
        }
        if (other.gameObject.CompareTag("Marker2"))
        {
            PlayerPrefs.SetFloat("PlayerX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", transform.position.y - 0.2f);
            PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
            Application.LoadLevel("Cafe1");
        }
    }
    
}
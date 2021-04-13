using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class nave : MonoBehaviour
{
    [SerializeField]
    float maxRelativeVelocity = 2f;

    [SerializeField]
    float maxRotation = 10f;
    
    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 15f;



    //[SerializeField]

    //float fuelforce = 100f;

    //[SerializeField]

    //float fueltorque = 100f;
    
   
    TextMeshProUGUI FuelTXT;
    
    [SerializeField]
    TextMeshProUGUI FuelscoreTXT;

    [SerializeField]
    float FuelScore = 100;

     




    void Update() //para diminuir a velocidade fazer uma força oposta
    {
        Debug.Log(FuelScore);



        if (FuelScore >= 0)
        {





            if (Input.GetKey(KeyCode.UpArrow))
            {


                GetComponent<Rigidbody2D>().AddForce(transform.up * thrustForce * Time.deltaTime);
                //fuel -= fuelforce * Time.deltaTime;
                FuelScore = FuelScore - 10 * Time.deltaTime;
                FuelScore = Mathf.Round(FuelScore * 100f) / 100f;
                FuelscoreTXT.text = FuelScore.ToString();

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
                //fuel -= fueltorque * Time.deltaTime;
                FuelScore = FuelScore - 5 * Time.deltaTime;
                FuelScore = Mathf.Round(FuelScore * 100f) / 100f;
                FuelscoreTXT.text = FuelScore.ToString();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
                //fuel -=fueltorque *Time.deltaTime;
                FuelScore = FuelScore - 5 * Time.deltaTime;
                FuelScore = Mathf.Round(FuelScore * 100f) / 100f;
                FuelscoreTXT.text = FuelScore.ToString();

            }
        }





    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Plataforma")
        {

            Debug.Log("Aterrei...");                                           //quaternion
           
         if(collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > maxRotation)
            {

                Debug.Log("Mas explodi!");
            }


        }
        else
        {
          Debug.Log("Explodi");

        }
       

    }
    
}

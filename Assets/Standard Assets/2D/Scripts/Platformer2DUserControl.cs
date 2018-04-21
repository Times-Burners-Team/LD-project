using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {

        public  Vector3 HeroPosition;

        public GameObject Text;
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

         public void OnTriggerStay2D(Collider2D other)
        {
           int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
           
           switch (other.gameObject.tag)
           {
               case "ToMine":
                    Text.SetActive(true);
                    if(Input.GetKey(KeyCode.E))
                    {
                        SceneManager.LoadScene(2);
                        Debug.Log("ToMine");
                    }
               break;

               case "ToTown":
                    Text.SetActive(true);
                    if(Input.GetKey(KeyCode.E))
                    {
                        SceneManager.LoadScene(1);
                        Debug.Log("ToTown");
                    }
               break; 

               case "ToShelter":
                Text.SetActive(true);
                    if(Input.GetKey(KeyCode.E))
                    {
                        SceneManager.LoadScene(0);
                        Debug.Log("ToShelter");

                    }
                      
               break;
           }
        }
        public void OnTriggerExit2D(Collider2D other)
        {
           switch (other.gameObject.tag)
           {
               case "ToMine":
                    Text.SetActive(false);
               break;

               case "ToTown":
                    Text.SetActive(false);
               break; 

               case "ToShelter":
                    Text.SetActive(false);
               break;
           }
        }
    }
}

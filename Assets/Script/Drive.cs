using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
//using Mirror;

public class Drive : MonoBehaviour
{
    public Joystick joystick;
    public ButtonPressed button;

    public Button buttonPower;

    private bool entered;

    public GameManagerScript gc;


    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        gc = FindObjectOfType<GameManagerScript>();

        buttonPower.onClick.AddListener(() => gc.accendiAstronave());
    }

    // Update is called once per frame
    void Update()
    {
        /* if (button.pressed && !entered)
        {
            entered = true;
            gc.accendiAstronave();
        }

        if (!button.pressed)
        {
            entered = false;
        } */



        gc.movimento(joystick.Horizontal, joystick.Vertical);
    }

}

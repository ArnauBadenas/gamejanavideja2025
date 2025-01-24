using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private InputSystem_Actions actions;

    public ButtonInputHandler attack, crouch, jump, sprint, submit, cancel,click, rightClick,middleClick;
    public Vector2 move { private set; get; }
    public Vector2 look { private set; get; }
    public Vector2 navigate { private set; get; }
    public Vector2 point { private set; get; }
    public Vector2 scrollWheel { private set; get; }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //else if (instance != this) Destroy(this);
    }

    private void OnDestroy()
    {
        if (instance == this) instance = null; 
    }


    private void OnEnable()
    {
        if (actions == null)
        {
            actions = new InputSystem_Actions();
            actions.Player.Move.performed += x => move = x.ReadValue<Vector2>();
            actions.Player.Look.performed += x => look = x.ReadValue<Vector2>();
            actions.UI.Navigate.performed += x => navigate = x.ReadValue<Vector2>();
            actions.UI.Point.performed += x => point = x.ReadValue<Vector2>();
            actions.UI.ScrollWheel.performed += x => scrollWheel = x.ReadValue<Vector2>();

        }

        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void Start()
    {
        //submit = new ButtonInputHandler(actions.UI.Submit);
        attack = new ButtonInputHandler(actions.Player.Attack);
        crouch = new ButtonInputHandler(actions.Player.Crouch);
        jump = new ButtonInputHandler(actions.Player.Jump);
        sprint = new ButtonInputHandler(actions.Player.Sprint);
        submit = new ButtonInputHandler(actions.UI.Submit);
        cancel = new ButtonInputHandler(actions.UI.Cancel);
        rightClick = new ButtonInputHandler(actions.UI.RightClick);
        middleClick = new ButtonInputHandler(actions.UI.MiddleClick);
        click = new ButtonInputHandler(actions.UI.Click);
        
    }
}

public class ButtonInputHandler
{
    private InputAction action;
    private bool tapUsed;
    private bool releaseUsed;

    public ButtonInputHandler(InputAction action)
    {
        this.action = action;
    }

    public bool HOLD
    {
        get
        {
            return input();
        }
    }

    public bool TAP
    {
        get
        {
            bool usedLastFrame = tapUsed;
            tapUsed = input();
            return usedLastFrame ? false : tapUsed;
        }
    }

    public bool RELEASE
    {
        get
        {
            bool usedLastFrame = releaseUsed;
            releaseUsed = input();
            return usedLastFrame ? !releaseUsed : false;
        }
    }

    private bool input()
    {
        return action.phase == InputActionPhase.Performed;
    }
}

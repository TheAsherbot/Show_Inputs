using System;
using System.Collections.Generic;
using TheAshBot;

using Unity.Burst.CompilerServices;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{


    public enum VisualType
    {
        NONE = -1,
        XBox360,
        XBox1,
    }


    private static readonly List<VisualType> STANDERD_CONTROLLER_TYPES_LIST = new List<VisualType> { VisualType.XBox360, VisualType.XBox1 };


    public event Action<bool> OnLightWhenPressedChange;


    [SerializeField] private bool lightWhenPressed = true;


    public UserInput userInput;


    public VisualType visualType = VisualType.XBox360;
    [SerializeField] private _BaseControllerInputManager genericController;
    [SerializeField] private Material xbox360Matterial;
    [SerializeField] private Material xbox1Matterial;


    private _BaseControllerInputManager controllerInputManager;



    #region Events

    private ActionType actionTypeZL;
    private ActionType actionTypeL;
    private ActionType actionTypeR;
    private ActionType actionTypeZR;

    private ActionType actionTypeButtonNorth;
    private ActionType actionTypeButtonSouth;
    private ActionType actionTypeButtonEast;
    private ActionType actionTypeuttonWest;

    private Vector2 lastDPad;
    private Vector2 lastLeftStick;
    private Vector2 lastRightStick;

    private ActionType actionTypeStart;
    private ActionType actionTypeSelect;
    private ActionType actionTypeHome;


    public Action OnOptions;
    private bool shift;
    private bool escape;


    #endregion



    private void Awake()
    {
        userInput = new UserInput();

        controllerInputManager = genericController;

        if (STANDERD_CONTROLLER_TYPES_LIST.Contains(visualType))
        {
            userInput.StanderdController.Enable();
        }
        SetUpControllerEvents();

        userInput.Options.Enable();
        userInput.Options.Shift.started += (obj) => { shift = true; };
        userInput.Options.Shift.canceled += (obj) => { shift = false; };
        userInput.Options.Escape.started += (obj) => { escape = true; };
        userInput.Options.Escape.canceled += (obj) => { escape = false; };
    }

    private void Start()
    {
        OnLightWhenPressedChange?.Invoke(lightWhenPressed);
    }

    private void Update()
    {
        if (shift && escape)
        {
            escape = false;
            OnOptions?.Invoke();
        }

        if (STANDERD_CONTROLLER_TYPES_LIST.Contains(visualType))
        {
            HandleControllerInput();
        }
    }

    #region Controller

    private void HandleControllerInput()
    {
        if (actionTypeZL != ActionType.NONE)
        {
            controllerInputManager.onZL?.Invoke(actionTypeZL);
        }
        if (actionTypeL != ActionType.NONE)
        {
            controllerInputManager.onL?.Invoke(actionTypeL);
        }
        if (actionTypeR != ActionType.NONE)
        {
            controllerInputManager.onR?.Invoke(actionTypeR);
        }
        if (actionTypeZR != ActionType.NONE)
        {
            controllerInputManager.onZR?.Invoke(actionTypeZR);
        }

        if (actionTypeButtonNorth != ActionType.NONE)
        {
            controllerInputManager.onButtonNorth?.Invoke(actionTypeButtonNorth);
        }
        if (actionTypeButtonSouth != ActionType.NONE)
        {
            controllerInputManager.onButtonSouth?.Invoke(actionTypeButtonSouth);
        }
        if (actionTypeButtonEast != ActionType.NONE)
        {
            controllerInputManager.onButtonEast?.Invoke(actionTypeButtonEast);
        }
        if (actionTypeuttonWest != ActionType.NONE)
        {
            controllerInputManager.onButtonWest?.Invoke(actionTypeuttonWest);
        }

        Vector2 dPad = userInput.StanderdController.DPad.ReadValue<Vector2>();
        Vector2 leftStick = userInput.StanderdController.LeftStick.ReadValue<Vector2>();
        Vector2 rightStick = userInput.StanderdController.RightStick.ReadValue<Vector2>();

        if (dPad != lastDPad || dPad != Vector2.zero)
        {
            ActionType actionType;

            if (dPad == Vector2.zero)
            {
                // Stoped
                actionType = ActionType.Canceled;
            }
            else if (lastDPad == Vector2.zero)
            {
                // Just Started
                actionType = ActionType.Started;
            }
            else
            {
                // Continued
                actionType = ActionType.Performed;
            }

            controllerInputManager.onDPad?.Invoke(actionType, dPad);

            lastDPad = dPad;
        }
        if (leftStick != lastLeftStick || leftStick != Vector2.zero)
        {
            ActionType actionType;

            if (leftStick == Vector2.zero)
            {
                // Stoped
                actionType = ActionType.Canceled;
            }
            else if (lastLeftStick == Vector2.zero)
            {
                // Just Started
                actionType = ActionType.Started;
            }
            else
            {
                // Continued
                actionType = ActionType.Performed;
            }

            controllerInputManager.onLeftStick?.Invoke(actionType, leftStick);

            lastLeftStick = leftStick;
        }
        if (rightStick != lastRightStick || rightStick != Vector2.zero)
        {
            ActionType actionType;

            if (rightStick == Vector2.zero)
            {
                // Stoped
                actionType = ActionType.Canceled;
            }
            else if (lastRightStick == Vector2.zero)
            {
                // Just Started
                actionType = ActionType.Started;
            }
            else
            {
                // Continued
                actionType = ActionType.Performed;
            }

            controllerInputManager.onRightStick?.Invoke(actionType, rightStick);

            lastRightStick = rightStick;
        }

        if (actionTypeSelect != ActionType.NONE)
        {
            controllerInputManager.onSelect?.Invoke(actionTypeSelect);
        }
        if (actionTypeStart != ActionType.NONE)
        {
            controllerInputManager.onStart?.Invoke(actionTypeStart);
        }
        if (actionTypeHome != ActionType.NONE)
        {
            controllerInputManager.onHome?.Invoke(actionTypeHome);
        }

        AdvanceControllerActionTypes();
    }

    private void AdvanceControllerActionTypes()
    {
        // Coroutine coroutine = new WaitForEndOfFrame();
        switch (actionTypeZL)
        {
            case ActionType.Started:
                actionTypeZL = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeZL = ActionType.NONE;
                break;
        }
        switch (actionTypeL)
        {
            case ActionType.Started:
                actionTypeL = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeL = ActionType.NONE;
                break;
        }
        switch (actionTypeR)
        {
            case ActionType.Started:
                actionTypeR = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeR = ActionType.NONE;
                break;
        }
        switch (actionTypeZR)
        {
            case ActionType.Started:
                actionTypeZR = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeZR = ActionType.NONE;
                break;
        }

        switch (actionTypeButtonNorth)
        {
            case ActionType.Started:
                actionTypeButtonNorth = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeButtonNorth = ActionType.NONE;
                break;
        }
        switch (actionTypeButtonSouth)
        {
            case ActionType.Started:
                actionTypeButtonSouth = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeButtonSouth = ActionType.NONE;
                break;
        }
        switch (actionTypeButtonEast)
        {
            case ActionType.Started:
                actionTypeButtonEast = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeButtonEast = ActionType.NONE;
                break;
        }
        switch (actionTypeuttonWest)
        {
            case ActionType.Started:
                actionTypeuttonWest = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeuttonWest = ActionType.NONE;
                break;
        }


        switch (actionTypeSelect)
        {
            case ActionType.Started:
                actionTypeSelect = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeSelect = ActionType.NONE;
                break;
        }
        switch (actionTypeStart)
        {
            case ActionType.Started:
                actionTypeStart = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeStart = ActionType.NONE;
                break;
        }
        switch (actionTypeHome)
        {
            case ActionType.Started:
                actionTypeHome = ActionType.Performed;
                break;
            case ActionType.Canceled:
                actionTypeHome = ActionType.NONE;
                break;
        }

    }

    private void SetUpControllerEvents()
    {
        userInput.StanderdController.ZL.performed += ZL_performed;
        userInput.StanderdController.ZL.canceled += ZL_canceled;
        userInput.StanderdController.L.performed += L_performed;
        userInput.StanderdController.L.canceled += L_canceled;
        userInput.StanderdController.R.performed += R_performed;
        userInput.StanderdController.R.canceled += R_canceled;
        userInput.StanderdController.ZR.performed += ZR_performed;
        userInput.StanderdController.ZR.canceled += ZR_canceled;

        userInput.StanderdController.ButtonNorth.performed += ButtonNorth_performed;
        userInput.StanderdController.ButtonNorth.canceled += ButtonNorth_canceled;
        userInput.StanderdController.ButtonSouth.performed += ButtonSouth_performed;
        userInput.StanderdController.ButtonSouth.canceled += ButtonSouth_canceled;
        userInput.StanderdController.ButtonEast.performed += ButtonEast_performed;
        userInput.StanderdController.ButtonEast.canceled += ButtonEast_canceled;
        userInput.StanderdController.ButtonWest.performed += ButtonWest_performed;
        userInput.StanderdController.ButtonWest.canceled += ButtonWest_canceled;

        userInput.StanderdController.Select.performed += Select_performed;
        userInput.StanderdController.Select.canceled += Select_canceled;
        userInput.StanderdController.Start.performed += Start_performed;
        userInput.StanderdController.Start.canceled += Start_canceled;
        userInput.StanderdController.Home.performed += Home_performed;
        userInput.StanderdController.Home.canceled += Home_canceled;
    }

    #region Controller Events

    private void ZL_performed(InputAction.CallbackContext obj)
    {
        actionTypeZL = ActionType.Started;
    }
    private void ZL_canceled(InputAction.CallbackContext obj)
    {
        actionTypeZL = ActionType.Canceled;
    }

    private void L_performed(InputAction.CallbackContext obj)
    {
        actionTypeL = ActionType.Started;
    }
    private void L_canceled(InputAction.CallbackContext obj)
    {
        actionTypeL = ActionType.Canceled;
    }

    private void R_performed(InputAction.CallbackContext obj)
    {
        actionTypeR = ActionType.Started;
    }
    private void R_canceled(InputAction.CallbackContext obj)
    {
        actionTypeR = ActionType.Canceled;
    }

    private void ZR_performed(InputAction.CallbackContext obj)
    {
        actionTypeZR = ActionType.Started;
    }
    private void ZR_canceled(InputAction.CallbackContext obj)
    {
        actionTypeZR = ActionType.Canceled;
    }


    private void ButtonNorth_performed(InputAction.CallbackContext obj)
    {
        actionTypeButtonNorth = ActionType.Started;
    }
    private void ButtonNorth_canceled(InputAction.CallbackContext obj)
    {
        actionTypeButtonNorth = ActionType.Canceled;
    }

    private void ButtonSouth_performed(InputAction.CallbackContext obj)
    {
        actionTypeButtonSouth = ActionType.Started;
    }
    private void ButtonSouth_canceled(InputAction.CallbackContext obj)
    {
        actionTypeButtonSouth = ActionType.Canceled;
    }

    private void ButtonEast_performed(InputAction.CallbackContext obj)
    {
        actionTypeButtonEast = ActionType.Started;
    }
    private void ButtonEast_canceled(InputAction.CallbackContext obj)
    {
        actionTypeButtonEast = ActionType.Canceled;
    }

    private void ButtonWest_performed(InputAction.CallbackContext obj)
    {
        actionTypeuttonWest = ActionType.Started;
    }
    private void ButtonWest_canceled(InputAction.CallbackContext obj)
    {
        actionTypeuttonWest = ActionType.Canceled;
    }

    private void Start_performed(InputAction.CallbackContext obj)
    {
        actionTypeStart = ActionType.Started;
    }
    private void Start_canceled(InputAction.CallbackContext obj)
    {
        actionTypeStart = ActionType.Canceled;
    }

    private void Select_performed(InputAction.CallbackContext obj)
    {
        actionTypeSelect = ActionType.Started;
    }
    private void Select_canceled(InputAction.CallbackContext obj)
    {
        actionTypeSelect = ActionType.Canceled;
    }

    private void Home_performed(InputAction.CallbackContext obj)
    {
        actionTypeHome = ActionType.Started;
    }
    private void Home_canceled(InputAction.CallbackContext obj)
    {
        actionTypeHome = ActionType.Canceled;
    }

    #endregion

    #endregion


    public void SetLightWhenPressed(bool lightWhenPressed)
    {
        this.lightWhenPressed = lightWhenPressed;
        OnLightWhenPressedChange?.Invoke(lightWhenPressed);
    }

    public void SetVisualType(VisualType inputType)
    {
        this.visualType = inputType;
        switch (inputType)
        {
            case VisualType.XBox360:
                genericController.GetComponent<MeshRenderer>().material = xbox360Matterial;
                break;
            case VisualType.XBox1:
                genericController.GetComponent<MeshRenderer>().material = xbox1Matterial;
                break;
        }
    }


}

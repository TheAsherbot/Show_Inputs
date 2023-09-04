using System.Collections.Generic;

using Unity.Mathematics;

using UnityEngine;
using UnityEngine.InputSystem;


namespace UnityEngine.InputSystem
{
    public enum ActionType
    {
        NONE,
        Started,
        Performed,
        Canceled,
    }

    public delegate void OnInput(ActionType actionType);
    public delegate void OnInput<in T>(ActionType actionType, T input);
}



public class _BaseControllerInputManager : MonoBehaviour
{



    public struct Sprite
    {
        public Sprite(int width, int height)
        {
            this.width = width;
            this.height = height;
        }


        private int width;
        private int height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftButtomRightTop">x = left; y = bottom; z = right; w = top;</param>
        /// <returns>an array of 4 uv</returns>
        public Vector2[] GetUV(int4 leftButtomRightTop)
        {
            Vector2[] uv = new Vector2[4];

            uv[0] = new Vector2((float)leftButtomRightTop.x / width, (float)leftButtomRightTop.y / height);
            uv[1] = new Vector2((float)leftButtomRightTop.x / width, (float)leftButtomRightTop.w / height);
            uv[2] = new Vector2((float)leftButtomRightTop.z / width, (float)leftButtomRightTop.w / height);
            uv[3] = new Vector2((float)leftButtomRightTop.z / width, (float)leftButtomRightTop.y / height);

            return uv;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }
        public void SetHeight(int height)
        {
            this.height = height;
        }

    }


    #region CONST

    private const float MIN_STICK_DEAD_ZONE = 0.1f;



    #region UV Start Index

    private const int BODY_UV_START_INDEX = 0;
    private const int ZL_UV_START_INDEX = 4;
    private const int L_UV_START_INDEX = 8;
    private const int R_UV_START_INDEX = 12;
    private const int ZR_UV_START_INDEX = 16;
    private const int BUTTON_NORTH_UV_START_INDEX = 20;
    private const int BUTTON_SOUTH_UV_START_INDEX = 24;
    private const int BUTTON_EAST_UV_START_INDEX = 28;
    private const int BUTTON_WEST_UV_START_INDEX = 32;
    private const int DPAD_UV_START_INDEX = 36;
    private const int DPAD_NORTH_UV_START_INDEX = 40;
    private const int DPAD_SOUTH_UV_START_INDEX = 44;
    private const int DPAD_EAST_UV_START_INDEX = 48;
    private const int DPAD_WEST_UV_START_INDEX = 52;
    private const int LEFT_STICK_UV_START_INDEX = 56;
    private const int RIGHT_STICK_UV_START_INDEX = 60;
    private const int HOME_UV_START_INDEX = 64;
    private const int SELECT_UV_START_INDEX = 68;
    private const int START_UV_START_INDEX = 72;

    #endregion

    #region UV Positions

    private static readonly int4 HOME_UV_POSITION = new int4(0, 640, 64, 704);
    private static readonly int4 SELECT_UV_POSITION = new int4(64, 640, 128, 704);
    private static readonly int4 START_UV_POSITION = new int4(128, 640, 192, 704);

    private static readonly int4 BODY_UV_POSITION = new int4(0, 512, 64, 576);

    private static readonly int4 ZL_UV_POSITION_DARK = new int4(0, 448, 64, 512);
    private static readonly int4 L_UV_POSITION_DARK = new int4(64, 448, 128, 512);
    private static readonly int4 R_UV_POSITION_DARK = new int4(128, 448, 192, 512);
    private static readonly int4 ZR_UV_POSITION_DARK = new int4(192, 448, 256, 512);

    private static readonly int4 BUTTON_NORTH_UV_POSITION_DARK = new int4(0, 320, 64, 384);
    private static readonly int4 BUTTON_SOUTH_UV_POSITION_DARK = new int4(64, 320, 128, 384);
    private static readonly int4 BUTTON_EAST_UV_POSITION_DARK = new int4(128, 320, 192, 384);
    private static readonly int4 BUTTON_WEST_UV_POSITION_DARK = new int4(192, 320, 256, 384);

    private static readonly int4 DPAD_UV_POSITION_DARK = new int4(0, 192, 64, 256);
    private static readonly int4 DPAD_NORTH_UV_POSITION_DARK = new int4(64, 192, 128, 256);
    private static readonly int4 DPAD_SOUTH_UV_POSITION_DARK = new int4(128, 192, 192, 256);
    private static readonly int4 DPAD_EAST_UV_POSITION_DARK = new int4(192, 192, 256, 256);
    private static readonly int4 DPAD_WEST_UV_POSITION_DARK = new int4(256, 192, 320, 256);

    private static readonly int4 LEFT_STICK_UV_POSITION_DARK = new int4(0, 64, 64, 128);
    private static readonly int4 RIGHT_STICK_UV_POSITION_DARK = new int4(64, 64, 128, 128);

    protected static readonly int4 LIGHT_UV_OFFSET = new int4(0, -64, 0, -64);

    #endregion


    #endregion

    #region Veriables

    #region Events
    
    public OnInput onZL;
    public OnInput onL;
    public OnInput onR;
    public OnInput onZR;

    public OnInput onButtonNorth;
    public OnInput onButtonSouth;
    public OnInput onButtonEast;
    public OnInput onButtonWest;

    public OnInput<Vector2> onDPad;
    public OnInput<Vector2> onLeftStick;
    public OnInput<Vector2> onRightStick;

    public OnInput onHome;
    public OnInput onSelect;
    public OnInput onStart;

    #endregion

    protected int[] triangles;
    protected Vector2[] uvs;
    protected Vector3[] vertices;
    protected int numberOfMeshes = 19;
    protected bool updateMesh = false;

    private Mesh mesh;
    private MeshFilter meshFilter;

    
    protected Sprite sprite = new Sprite(320, 704);


    [SerializeField] protected InputManager inputManager;
    protected bool lightWhenPressed;

    #endregion

    protected virtual void Awake()
    {
        inputManager.OnLightWhenPressedChange += InputManager_OnLightWhenPressedChange;

        #region Events

        onZL += OnZL;
        onL += OnL;
        onR += OnR;
        onZR += OnZR;

        onButtonNorth += OnButtonNorth;
        onButtonSouth += OnButtonSouth;
        onButtonEast += OnButtonEast;
        onButtonWest += OnButtonWest;

        onDPad += OnDPad;
        onLeftStick += OnLeftStick;
        onRightStick += OnRightStick;

        onHome += OnHome;
        onSelect += OnSelect;
        onStart += OnStart;

        #endregion
    }

    private void Start()
    {
        InitMesh();
    }

    protected virtual void InitMesh()
    {
        vertices = new Vector3[numberOfMeshes * 4];
        uvs = new Vector2[numberOfMeshes * 4];
        triangles = new int[numberOfMeshes * 6];
        meshFilter = GetComponent<MeshFilter>();

        
        for (int i = 0; i < numberOfMeshes; i++)
        {
            MakeVertices(i * 4);
        }
        for (int i = 0; i < numberOfMeshes; i++)
        {
            MakeTriangles(i * 6, i * 4);
        }
        MakeUVs();

        mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        meshFilter.mesh = mesh;
    }

    protected void MakeVertices(int start)
    {
        vertices[start++] = new Vector3(-32, -32f);
        vertices[start++] = new Vector3(-32f, 32f);
        vertices[start++] = new Vector3(32f, 32f);
        vertices[start++] = new Vector3(32f, -32f);
    }
    protected virtual void MakeUVs()
    {
        int4 offset = lightWhenPressed ? int4.zero : LIGHT_UV_OFFSET;

        AssineUV(BODY_UV_START_INDEX, BODY_UV_POSITION);

        AssineUV(ZL_UV_START_INDEX, ZL_UV_POSITION_DARK + offset);

        AssineUV(L_UV_START_INDEX, L_UV_POSITION_DARK + offset);

        AssineUV(R_UV_START_INDEX, R_UV_POSITION_DARK + offset);

        AssineUV(ZR_UV_START_INDEX, ZR_UV_POSITION_DARK + offset);

        AssineUV(BUTTON_NORTH_UV_START_INDEX, BUTTON_NORTH_UV_POSITION_DARK + offset);
        
        AssineUV(BUTTON_SOUTH_UV_START_INDEX, BUTTON_SOUTH_UV_POSITION_DARK + offset);

        AssineUV(BUTTON_EAST_UV_START_INDEX, BUTTON_EAST_UV_POSITION_DARK + offset);

        AssineUV(BUTTON_WEST_UV_START_INDEX, BUTTON_WEST_UV_POSITION_DARK + offset);

        AssineUV(DPAD_UV_START_INDEX, DPAD_UV_POSITION_DARK + offset);

        AssineUV(DPAD_NORTH_UV_START_INDEX, DPAD_NORTH_UV_POSITION_DARK + offset);

        AssineUV(DPAD_SOUTH_UV_START_INDEX, DPAD_SOUTH_UV_POSITION_DARK + offset);

        AssineUV(DPAD_EAST_UV_START_INDEX, DPAD_EAST_UV_POSITION_DARK + offset);

        AssineUV(DPAD_WEST_UV_START_INDEX, DPAD_WEST_UV_POSITION_DARK + offset);

        AssineUV(LEFT_STICK_UV_START_INDEX, LEFT_STICK_UV_POSITION_DARK + offset);

        AssineUV(RIGHT_STICK_UV_START_INDEX, RIGHT_STICK_UV_POSITION_DARK + offset);

        AssineUV(HOME_UV_START_INDEX, HOME_UV_POSITION + offset);

        AssineUV(SELECT_UV_START_INDEX, SELECT_UV_POSITION + offset);

        AssineUV(START_UV_START_INDEX, START_UV_POSITION + offset);

        void AssineUV(int startIndex, int4 uvPosition)
        {
            Vector2[] tempUV = sprite.GetUV(uvPosition);
            uvs[startIndex++] = tempUV[0];
            uvs[startIndex++] = tempUV[1];
            uvs[startIndex++] = tempUV[2];
            uvs[startIndex++] = tempUV[3];
        }
    }
    protected void MakeTriangles(int startTraingles, int startVertices)
    {
        triangles[startTraingles++] = startVertices;
        triangles[startTraingles++] = startVertices + 1;
        triangles[startTraingles++] = startVertices + 2;

        triangles[startTraingles++] = startVertices;
        triangles[startTraingles++] = startVertices + 2;
        triangles[startTraingles++] = startVertices + 3;
    }

    private void Update()
    {
        if (updateMesh)
        {
            mesh.vertices = vertices;
            mesh.uv = uvs;
            mesh.triangles = triangles;

            updateMesh = false;
        }
    }

    #region Events (Subscriptions)

    private void OnZL(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(ZL_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            uvs[ZL_UV_START_INDEX] = tempUV[0];
            uvs[ZL_UV_START_INDEX + 1] = tempUV[1];
            uvs[ZL_UV_START_INDEX + 2] = tempUV[2];
            uvs[ZL_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(ZL_UV_POSITION_DARK);
            uvs[ZL_UV_START_INDEX] = tempUV[0];
            uvs[ZL_UV_START_INDEX + 1] = tempUV[1];
            uvs[ZL_UV_START_INDEX + 2] = tempUV[2];
            uvs[ZL_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }
    private void OnL(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(L_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            uvs[L_UV_START_INDEX] = tempUV[0];
            uvs[L_UV_START_INDEX + 1] = tempUV[1];
            uvs[L_UV_START_INDEX + 2] = tempUV[2];
            uvs[L_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(L_UV_POSITION_DARK);
            uvs[L_UV_START_INDEX] = tempUV[0];
            uvs[L_UV_START_INDEX + 1] = tempUV[1];
            uvs[L_UV_START_INDEX + 2] = tempUV[2];
            uvs[L_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }
    private void OnR(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(R_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            uvs[R_UV_START_INDEX] = tempUV[0];
            uvs[R_UV_START_INDEX + 1] = tempUV[1];
            uvs[R_UV_START_INDEX + 2] = tempUV[2];
            uvs[R_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(R_UV_POSITION_DARK);
            uvs[R_UV_START_INDEX] = tempUV[0];
            uvs[R_UV_START_INDEX + 1] = tempUV[1];
            uvs[R_UV_START_INDEX + 2] = tempUV[2];
            uvs[R_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }
    private void OnZR(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(ZR_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            uvs[ZR_UV_START_INDEX] = tempUV[0];
            uvs[ZR_UV_START_INDEX + 1] = tempUV[1];
            uvs[ZR_UV_START_INDEX + 2] = tempUV[2];
            uvs[ZR_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(ZR_UV_POSITION_DARK);
            uvs[ZR_UV_START_INDEX] = tempUV[0];
            uvs[ZR_UV_START_INDEX + 1] = tempUV[1];
            uvs[ZR_UV_START_INDEX + 2] = tempUV[2];
            uvs[ZR_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }

    private void OnButtonNorth(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(BUTTON_NORTH_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            uvs[BUTTON_NORTH_UV_START_INDEX] = tempUV[0];
            uvs[BUTTON_NORTH_UV_START_INDEX + 1] = tempUV[1];
            uvs[BUTTON_NORTH_UV_START_INDEX + 2] = tempUV[2];
            uvs[BUTTON_NORTH_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(BUTTON_NORTH_UV_POSITION_DARK);
            uvs[BUTTON_NORTH_UV_START_INDEX] = tempUV[0];
            uvs[BUTTON_NORTH_UV_START_INDEX + 1] = tempUV[1];
            uvs[BUTTON_NORTH_UV_START_INDEX + 2] = tempUV[2];
            uvs[BUTTON_NORTH_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }
    private void OnButtonSouth(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(BUTTON_SOUTH_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            uvs[BUTTON_SOUTH_UV_START_INDEX] = tempUV[0];
            uvs[BUTTON_SOUTH_UV_START_INDEX + 1] = tempUV[1];
            uvs[BUTTON_SOUTH_UV_START_INDEX + 2] = tempUV[2];
            uvs[BUTTON_SOUTH_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(BUTTON_SOUTH_UV_POSITION_DARK);
            uvs[BUTTON_SOUTH_UV_START_INDEX] = tempUV[0];
            uvs[BUTTON_SOUTH_UV_START_INDEX + 1] = tempUV[1];
            uvs[BUTTON_SOUTH_UV_START_INDEX + 2] = tempUV[2];
            uvs[BUTTON_SOUTH_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }
    private void OnButtonEast(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(BUTTON_EAST_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            uvs[BUTTON_EAST_UV_START_INDEX] = tempUV[0];
            uvs[BUTTON_EAST_UV_START_INDEX + 1] = tempUV[1];
            uvs[BUTTON_EAST_UV_START_INDEX + 2] = tempUV[2];
            uvs[BUTTON_EAST_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(BUTTON_EAST_UV_POSITION_DARK);
            uvs[BUTTON_EAST_UV_START_INDEX] = tempUV[0];
            uvs[BUTTON_EAST_UV_START_INDEX + 1] = tempUV[1];
            uvs[BUTTON_EAST_UV_START_INDEX + 2] = tempUV[2];
            uvs[BUTTON_EAST_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }
    private void OnButtonWest(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(BUTTON_WEST_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            uvs[BUTTON_WEST_UV_START_INDEX] = tempUV[0];
            uvs[BUTTON_WEST_UV_START_INDEX + 1] = tempUV[1];
            uvs[BUTTON_WEST_UV_START_INDEX + 2] = tempUV[2];
            uvs[BUTTON_WEST_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(BUTTON_WEST_UV_POSITION_DARK);
            uvs[BUTTON_WEST_UV_START_INDEX] = tempUV[0];
            uvs[BUTTON_WEST_UV_START_INDEX + 1] = tempUV[1];
            uvs[BUTTON_WEST_UV_START_INDEX + 2] = tempUV[2];
            uvs[BUTTON_WEST_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }

    private void OnDPad(ActionType actionType, Vector2 input)
    {
        if (actionType == ActionType.Canceled)
        {
            ResetUV(DPAD_NORTH_UV_START_INDEX);
            ResetUV(DPAD_SOUTH_UV_START_INDEX);
            ResetUV(DPAD_EAST_UV_START_INDEX);
            ResetUV(DPAD_WEST_UV_START_INDEX);
        }
        else if (lightWhenPressed)
        {
            if (input.x < -MIN_STICK_DEAD_ZONE)
            {
                SetUV(DPAD_WEST_UV_START_INDEX, DPAD_WEST_UV_POSITION_DARK + LIGHT_UV_OFFSET);
                ResetUV(DPAD_EAST_UV_START_INDEX);
            }
            else if (input.x > MIN_STICK_DEAD_ZONE)
            {
                ResetUV(DPAD_WEST_UV_START_INDEX);
                SetUV(DPAD_EAST_UV_START_INDEX, DPAD_EAST_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            }
            else
            {
                ResetUV(DPAD_EAST_UV_START_INDEX);
                ResetUV(DPAD_WEST_UV_START_INDEX);
            }

            if (input.y < -MIN_STICK_DEAD_ZONE)
            {
                ResetUV(DPAD_NORTH_UV_START_INDEX);
                SetUV(DPAD_SOUTH_UV_START_INDEX, DPAD_SOUTH_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            }
            else if (input.y > MIN_STICK_DEAD_ZONE)
            {
                SetUV(DPAD_NORTH_UV_START_INDEX, DPAD_NORTH_UV_POSITION_DARK + LIGHT_UV_OFFSET);
                ResetUV(DPAD_SOUTH_UV_START_INDEX);
            }
            else
            {
                ResetUV(DPAD_NORTH_UV_START_INDEX);
                ResetUV(DPAD_SOUTH_UV_START_INDEX);
            }
        }
        else
        {
            if (input.x < -MIN_STICK_DEAD_ZONE)
            {
                SetUV(DPAD_WEST_UV_START_INDEX, DPAD_WEST_UV_POSITION_DARK);
                ResetUV(DPAD_EAST_UV_START_INDEX);
            }
            else if (input.x > MIN_STICK_DEAD_ZONE)
            {
                ResetUV(DPAD_WEST_UV_START_INDEX);
                SetUV(DPAD_EAST_UV_START_INDEX, DPAD_EAST_UV_POSITION_DARK);
            }
            else
            {
                ResetUV(DPAD_EAST_UV_START_INDEX);
                ResetUV(DPAD_WEST_UV_START_INDEX);
            }

            if (input.y < -MIN_STICK_DEAD_ZONE)
            {
                ResetUV(DPAD_NORTH_UV_START_INDEX);
                SetUV(DPAD_SOUTH_UV_START_INDEX, DPAD_SOUTH_UV_POSITION_DARK);
            }
            else if (input.y > MIN_STICK_DEAD_ZONE)
            {
                SetUV(DPAD_NORTH_UV_START_INDEX, DPAD_NORTH_UV_POSITION_DARK);
                ResetUV(DPAD_SOUTH_UV_START_INDEX);
            }
            else
            {
                ResetUV(DPAD_NORTH_UV_START_INDEX);
                ResetUV(DPAD_SOUTH_UV_START_INDEX);
            }
        }

        updateMesh = true;

        void ResetUV(int start)
        {
            uvs[start++] = Vector2.zero;
            uvs[start++] = Vector2.zero;
            uvs[start++] = Vector2.zero;
            uvs[start++] = Vector2.zero;
        }
        void SetUV(int start, int4 leftButtomRightTop)
        {
            Vector2[] tempUV = sprite.GetUV(leftButtomRightTop);
            uvs[start++] = tempUV[0];
            uvs[start++] = tempUV[1];
            uvs[start++] = tempUV[2];
            uvs[start++] = tempUV[3];
        }

    }
    private void OnLeftStick(ActionType actionType, Vector2 input)
    {
        if (input.magnitude > MIN_STICK_DEAD_ZONE && actionType != ActionType.Canceled)
        {
            Vector2 stickMovement = Vector2Int.RoundToInt(input * 2);
            MoveCenter(stickMovement);
            if (lightWhenPressed)
            {
                SetUV(LEFT_STICK_UV_START_INDEX, LEFT_STICK_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            }
            else
            {
                SetUV(LEFT_STICK_UV_START_INDEX, LEFT_STICK_UV_POSITION_DARK);
            }
        }
        else
        {
            ResetStick();
        }

        updateMesh = true;

        void ResetStick()
        {
            int4 offset = lightWhenPressed ? int4.zero : LIGHT_UV_OFFSET;
            SetUV(LEFT_STICK_UV_START_INDEX, LEFT_STICK_UV_POSITION_DARK + offset);

            MoveCenter(Vector2.zero);
        }
        void SetUV(int start, int4 leftButtomRightTop)
        {
            Vector2[] tempUV = sprite.GetUV(leftButtomRightTop);
            uvs[start++] = tempUV[0];
            uvs[start++] = tempUV[1];
            uvs[start++] = tempUV[2];
            uvs[start++] = tempUV[3];
        }
        void MoveCenter(Vector2 centerPosition)
        {
            vertices[LEFT_STICK_UV_START_INDEX] = new Vector2(-32, -32) + centerPosition;
            vertices[LEFT_STICK_UV_START_INDEX + 1] = new Vector2(-32, 32) + centerPosition;
            vertices[LEFT_STICK_UV_START_INDEX + 2] = new Vector2(32, 32) + centerPosition;
            vertices[LEFT_STICK_UV_START_INDEX + 3] = new Vector2(32, -32) + centerPosition;
        }
    }
    private void OnRightStick(ActionType actionType, Vector2 input)
    {
        if (input.magnitude > MIN_STICK_DEAD_ZONE && actionType != ActionType.Canceled)
        {
            Vector2 stickMovement = Vector2Int.RoundToInt(input * 2);
            MoveCenter(stickMovement);
            if (lightWhenPressed)
            {
                SetUV(RIGHT_STICK_UV_START_INDEX, RIGHT_STICK_UV_POSITION_DARK + LIGHT_UV_OFFSET);
            }
            else
            {
                SetUV(RIGHT_STICK_UV_START_INDEX, RIGHT_STICK_UV_POSITION_DARK);
            }
        }
        else
        {
            ResetStick();
        }

        updateMesh = true;

        void ResetStick()
        {
            int4 offset = lightWhenPressed ? int4.zero : LIGHT_UV_OFFSET;
            SetUV(RIGHT_STICK_UV_START_INDEX, RIGHT_STICK_UV_POSITION_DARK + offset);

            MoveCenter(Vector2.zero);
        }
        void SetUV(int start, int4 leftButtomRightTop)
        {
            Vector2[] tempUV = sprite.GetUV(leftButtomRightTop);
            uvs[start++] = tempUV[0];
            uvs[start++] = tempUV[1];
            uvs[start++] = tempUV[2];
            uvs[start++] = tempUV[3];
        }
        void MoveCenter(Vector2 centerPosition)
        {
            vertices[RIGHT_STICK_UV_START_INDEX] = new Vector2(-32, -32) + centerPosition;
            vertices[RIGHT_STICK_UV_START_INDEX + 1] = new Vector2(-32, 32) + centerPosition;
            vertices[RIGHT_STICK_UV_START_INDEX + 2] = new Vector2(32, 32) + centerPosition;
            vertices[RIGHT_STICK_UV_START_INDEX + 3] = new Vector2(32, -32) + centerPosition;
        }
    }

    private void OnHome(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(HOME_UV_POSITION + LIGHT_UV_OFFSET);
            uvs[HOME_UV_START_INDEX] = tempUV[0];
            uvs[HOME_UV_START_INDEX + 1] = tempUV[1];
            uvs[HOME_UV_START_INDEX + 2] = tempUV[2];
            uvs[HOME_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(HOME_UV_POSITION);
            uvs[HOME_UV_START_INDEX] = tempUV[0];
            uvs[HOME_UV_START_INDEX + 1] = tempUV[1];
            uvs[HOME_UV_START_INDEX + 2] = tempUV[2];
            uvs[HOME_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }
    private void OnSelect(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(SELECT_UV_POSITION + LIGHT_UV_OFFSET);
            uvs[SELECT_UV_START_INDEX] = tempUV[0];
            uvs[SELECT_UV_START_INDEX + 1] = tempUV[1];
            uvs[SELECT_UV_START_INDEX + 2] = tempUV[2];
            uvs[SELECT_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(SELECT_UV_POSITION);
            uvs[SELECT_UV_START_INDEX] = tempUV[0];
            uvs[SELECT_UV_START_INDEX + 1] = tempUV[1];
            uvs[SELECT_UV_START_INDEX + 2] = tempUV[2];
            uvs[SELECT_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }
    private void OnStart(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(START_UV_POSITION + LIGHT_UV_OFFSET);
            uvs[START_UV_START_INDEX] = tempUV[0];
            uvs[START_UV_START_INDEX + 1] = tempUV[1];
            uvs[START_UV_START_INDEX + 2] = tempUV[2];
            uvs[START_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(START_UV_POSITION);
            uvs[START_UV_START_INDEX] = tempUV[0];
            uvs[START_UV_START_INDEX + 1] = tempUV[1];
            uvs[START_UV_START_INDEX + 2] = tempUV[2];
            uvs[START_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }


    private void InputManager_OnLightWhenPressedChange(bool lightWhenPressed)
    {
        this.lightWhenPressed = lightWhenPressed;
        if (uvs != null)
        {
            MakeUVs();
        }
        updateMesh = true;
    }

    #endregion


}

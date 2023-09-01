using Unity.Mathematics;

using UnityEngine;
using UnityEngine.InputSystem;

public class XBox360InputManager : _BaseControllerInputManager
{


    private const int XBOX_UV_START_INDEX = 64;
    private const int BACK_UV_START_INDEX = 68;
    private const int START_UV_START_INDEX = 72;


    private static readonly int4 XBOX_UV_POSITION = new int4(0, 640, 64, 704);
    private static readonly int4 BACK_UV_POSITION = new int4(64, 640, 128, 704);
    private static readonly int4 START_UV_POSITION = new int4(128, 640, 192, 704);


    public OnInput onXBox;
    public OnInput onBack;
    public OnInput onStart;


    protected override void Awake()
    {
        base.Awake();

        numberOfMeshes += 3;

        onXBox += OnXBox;
        onBack += OnBack;
        onStart += OnStart;

        sprite.SetHeight(704);
    }

    protected override void MakeUVs()
    {
        base.MakeUVs();

        int4 offset = lightWhenPressed ? int4.zero : LIGHT_UV_OFFSET;

        AssineUV(XBOX_UV_START_INDEX, XBOX_UV_POSITION + offset);

        AssineUV(BACK_UV_START_INDEX, BACK_UV_POSITION + offset);

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

    private void OnXBox(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(XBOX_UV_POSITION + LIGHT_UV_OFFSET);
            uvs[XBOX_UV_START_INDEX] = tempUV[0];
            uvs[XBOX_UV_START_INDEX + 1] = tempUV[1];
            uvs[XBOX_UV_START_INDEX + 2] = tempUV[2];
            uvs[XBOX_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(XBOX_UV_POSITION);
            uvs[XBOX_UV_START_INDEX] = tempUV[0];
            uvs[XBOX_UV_START_INDEX + 1] = tempUV[1];
            uvs[XBOX_UV_START_INDEX + 2] = tempUV[2];
            uvs[XBOX_UV_START_INDEX + 3] = tempUV[3];
        }

        if (actionType == ActionType.Started || actionType == ActionType.Canceled)
        {
            updateMesh = true;
        }
    }
    private void OnBack(ActionType actionType)
    {
        if ((lightWhenPressed && actionType == ActionType.Started) || (!lightWhenPressed && actionType == ActionType.Canceled))
        {
            Vector2[] tempUV = sprite.GetUV(BACK_UV_POSITION + LIGHT_UV_OFFSET);
            uvs[BACK_UV_START_INDEX] = tempUV[0];
            uvs[BACK_UV_START_INDEX + 1] = tempUV[1];
            uvs[BACK_UV_START_INDEX + 2] = tempUV[2];
            uvs[BACK_UV_START_INDEX + 3] = tempUV[3];
        }
        else if ((lightWhenPressed && actionType == ActionType.Canceled) || (!lightWhenPressed && actionType == ActionType.Started))
        {
            Vector2[] tempUV = sprite.GetUV(BACK_UV_POSITION);
            uvs[BACK_UV_START_INDEX] = tempUV[0];
            uvs[BACK_UV_START_INDEX + 1] = tempUV[1];
            uvs[BACK_UV_START_INDEX + 2] = tempUV[2];
            uvs[BACK_UV_START_INDEX + 3] = tempUV[3];
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
   
}

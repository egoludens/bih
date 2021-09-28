using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController : MonoBehaviour {

    private const float TileSize = 1f;

    public static MainSceneController Instance { get; private set; }
    public Game CurrentGame { get; set; }

    public GameObject FloorTileTemplate;
    public GameObject ObjectTemplate;
    public GameObject ActorTemplate;

    #region MonoBehaviour
    private void Start()
    {
        Instance = this;

        if (CurrentGame == null)
            SetCurrentGame(GameFactory.GenerateTestGame());
    }

    private void Update()
    {
        if (CurrentGame != null)
        {
            CurrentGame.PassTime(Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        SetCurrentGame(null);
    }
    #endregion

    public void SetCurrentGame(Game game)
    {
        if (CurrentGame != null)
        {
            CurrentGame.CurrentLevel.ActorSpawned -= CurrentLevel_ActorSpawned;
        }

        CurrentGame = game;
        if (CurrentGame != null)
        {
            BuildScene();
            CurrentGame.CurrentLevel.ActorSpawned += CurrentLevel_ActorSpawned;
        }
    }

    private void CurrentLevel_ActorSpawned(object sender, ActorSpawnedEventArgs e)
    {
        InstantiateActor(e.Actor);
    }

    private void BuildScene()
    {
        BuildFloor();
        BuildObjects();
        BuildActors();
    }

    private void BuildFloor()
    {
        var parentTransform = FloorTileTemplate.transform.parent;
        foreach (Transform child in parentTransform)
            if (child.gameObject != FloorTileTemplate)
                Destroy(child.gameObject);

        if (FloorTileTemplate.activeSelf)
            FloorTileTemplate.SetActive(false);

        var level = CurrentGame.CurrentLevel;
        for (var x = 0; x < level.Width; x++)
            for (var y = 0; y < level.Height; y++)
            {
                var tile = level.GetTile(x, y);
                GameObject levelTile = Instantiate(FloorTileTemplate, parentTransform, false);
                levelTile.transform.name = string.Format("Floor Tile (x: {0}, y: {1})", x, y);
                levelTile.transform.localScale = Vector3.one;
                levelTile.transform.localPosition = CalculateLevelTilePosition(x, y, level.Width, level.Height, FloorTileTemplate.transform.position.z);
                levelTile.GetComponent<TileController>().SetTile(tile);
                levelTile.SetActive(true);
            }
    }

    private Vector3 CalculateLevelTilePosition(int x, int y, int mapWidth, int mapHeight, float zPos)
    {
        Vector3 tilePos = new Vector3
        {
            x = (System.Convert.ToSingle(x) - System.Convert.ToSingle(mapWidth) / 2f) * TileSize,
            y = (System.Convert.ToSingle(mapHeight) / 2f - System.Convert.ToSingle(y)) * TileSize,
            z = zPos
        };
        return tilePos;
    }

    private void BuildObjects()
    {
        var parentTransform = ObjectTemplate.transform.parent;
        foreach (Transform child in parentTransform)
            if (child.gameObject != ObjectTemplate)
                Destroy(child.gameObject);

        if (ObjectTemplate.activeSelf)
            ObjectTemplate.SetActive(false);


        var level = CurrentGame.CurrentLevel;
        foreach(var obj in level.Objects)
        {
            float zPos = obj.Placement == ObjectPlacementEnum.Floor ? FloorTileTemplate.transform.position.z - 0.01f
                : obj.Placement == ObjectPlacementEnum.Standing ? ObjectTemplate.transform.position.z
                : 0f;

            GameObject levelObject = Instantiate(ObjectTemplate, parentTransform, false);
            levelObject.transform.name = string.Format("Object (x: {0}, y: {1})", obj.Position.X, obj.Position.Y);
            levelObject.transform.localScale = Vector3.one;
            levelObject.transform.localPosition = CalculateLevelTilePosition(obj.Position.X, obj.Position.Y, level.Width, level.Height, zPos);
            levelObject.GetComponent<LevelObjectController>().SetLevelObject(obj);
            levelObject.SetActive(true);
        }
    }

    private void BuildActors()
    {
        var parentTransform = ActorTemplate.transform.parent;
        foreach (Transform child in parentTransform)
            if (child.gameObject != ActorTemplate)
                Destroy(child.gameObject);

        if (ActorTemplate.activeSelf)
            ActorTemplate.SetActive(false);


        var level = CurrentGame.CurrentLevel;
        foreach (var actor in level.Actors)
            InstantiateActor(actor);
    }

    private void InstantiateActor(BaseLevelActor actor)
    {
        var parentTransform = ActorTemplate.transform.parent;
        GameObject levelObject = Instantiate(ActorTemplate, parentTransform, false);
        levelObject.transform.name = string.Format("Actor (x: {0}, y: {1})", actor.Position.X, actor.Position.Y);
        levelObject.transform.localScale = Vector3.one;
        levelObject.transform.localPosition = CalculateLevelTilePosition(actor.Position.X, actor.Position.Y, CurrentGame.CurrentLevel.Width, CurrentGame.CurrentLevel.Height, ActorTemplate.transform.position.z);
        levelObject.GetComponent<LevelActorController>().SetLevelActor(actor);
        levelObject.SetActive(true);
    }

}

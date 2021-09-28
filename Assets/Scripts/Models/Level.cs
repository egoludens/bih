using System;
using System.Collections;
using System.Collections.Generic;

public class Level {

    public int Width { get; set; }
    public int Height { get; set; }
    public List<List<LevelTile>> Tiles { get; set; }
    public List<BaseLevelObject> Objects { get; set; }
    public List<Form> Forms { get; set; }
    public List<DeskInstruction> Instructions { get; set; }
    public List<BaseLevelActor> Actors { get; set; }

    public event EventHandler<ActorSpawnedEventArgs> ActorSpawned;

    public Level() {
        Objects = new List<BaseLevelObject>();
        Forms = new List<Form>();
        Instructions = new List<DeskInstruction>();
        Actors = new List<BaseLevelActor>();
    }

    public Level(int width, int height): this()
    {
        Width = width;
        Height = height;

        Tiles = new List<List<LevelTile>>();
        for(var x = 0; x < Width; x++)
        {
            Tiles.Add(new List<LevelTile>());
            for (var y = 0; y < Height; y++)
                Tiles[x].Add(new LevelTile());
        }
    }

    public void AddObject(BaseLevelObject levelObject)
    {
        Objects.Add(levelObject);
        if (levelObject is PortalLevelObject)
            ((PortalLevelObject)levelObject).CustomerSpawned += Level_CustomerSpawned;
    }

    private void Level_CustomerSpawned(object sender, PortalLevelObject.CustomerSpawnedEventArgs e)
    {
        var newActor = e.Actor;
        Actors.Add(newActor);
        if (ActorSpawned != null)
            ActorSpawned.Invoke(this, new ActorSpawnedEventArgs(newActor));
    }

    public void AddForm(Form form)
    {
        Forms.Add(form);
    }

    public void AddInstruction(DeskInstruction deskInstruction)
    {
        Instructions.Add(deskInstruction);
    }

    public void AddActor(BaseLevelActor levelActor)
    {
        Actors.Add(levelActor);
    }

    public LevelTile GetTile(int x, int y)
    {
        return Tiles[x][y];
    }

    public void PassTime(float timePassedInSeconds)
    {
        foreach (var actor in Actors)
            actor.PassTime(timePassedInSeconds, this);

        foreach (var levelObject in Objects)
            levelObject.PassTime(timePassedInSeconds);
    }

    public DeskLevelObject FindDeskForTheForm(Form form)
    {
        foreach (var deskObject in Objects.FindAll(x => x is DeskLevelObject))
        {
            var desk = (DeskLevelObject)deskObject;
            foreach(var instruction in desk.Instructions)
            {
                if (instruction.Form == form)
                {
                    return desk;
                }
            }
        }
        return null;
    }

}

public class ActorSpawnedEventArgs : EventArgs
{
    public BaseLevelActor Actor { get; private set; }

    public ActorSpawnedEventArgs(BaseLevelActor actor)
    {
        Actor = actor;
    }
}

using System.Collections;
using System.Collections.Generic;

public class Game {

    public Level CurrentLevel { get; set; }

    public void PassTime(float timePassedInSeconds)
    {
        CurrentLevel.PassTime(timePassedInSeconds);
    }

}

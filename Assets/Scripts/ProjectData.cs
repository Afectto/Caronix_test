﻿using System.Collections.Generic;

public struct EnemyData : IEnemyData
{
    public Name Name { get; set; }
    public string PathImg { get; set; }

    public EnemyData(string firstName, string secondName, string pathImg)
    {
        Name = new Name(firstName, secondName);
        this.PathImg = pathImg;
    }

    public void UpdateData(string firstName, string secondName, string pathImg)
    {
        Name = new Name(firstName, secondName);
        PathImg = pathImg;
    }
}    

[System.Serializable]
public struct PlayerData
{
    public string Name;
    public int CoinCount;

    public PlayerData(string name, int coinCount)
    {
        Name = name;
        CoinCount = coinCount;
    }
}

[System.Serializable]
public struct Name
{
    public string first;
    public string last;

    public Name(string first, string last)
    {
        this.first = first;
        this.last = last;
    }
}

[System.Serializable]
public struct Picture
{
    public string large;
}

[System.Serializable]
public struct Result
{
    public Name name;
    public Picture picture;
}

[System.Serializable]
public struct RootObject
{
    public List<Result> results;
}

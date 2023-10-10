public struct EnemyData : IEnemyData
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string PathImg { get; set; }

    public EnemyData(string firstName, string secondName, string pathImg)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.PathImg = pathImg;
    }

    public void UpdateData(string firstName, string secondName, string pathImg)
    {
        FirstName = firstName;
        SecondName = secondName;
        PathImg = pathImg;
    }
}
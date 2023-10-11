using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSystem : MonoBehaviour
{
	public static SaveLoadSystem Instance;
	public PlayerData PlayerData;
	private  string _filePath;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this; 
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject); 
		}
		
		PlayerData = new PlayerData();
		
		if (Initialize())
		{
			SceneController.Instance.LoadNextScene("FindEnemy");
		}
		
	}

	private bool Initialize()
	{
		_filePath = Application.persistentDataPath + "/SaveGame.save";

		if (!File.Exists(_filePath))
			return false;
		
		return LoadGame();
	}

	public void SaveGame()
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(_filePath, FileMode.Create);

		SaveData data = new SaveData();
		data.SavePlayerData(PlayerData.Name, PlayerData.CoinCount);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public bool LoadGame()
	{
		if (!File.Exists(_filePath))
			return false;

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(_filePath, FileMode.Open);

		SaveData data = formatter.Deserialize(stream) as SaveData;
		stream.Close();

		if (data == null) return false;
		
		bool loadSuccess = true;
		
		loadSuccess &= LoadPlayer(data.playerData);

		return loadSuccess;
	}

	bool LoadPlayer(PlayerData playerData)
	{
		if (playerData.Name == null) return false;
		
		PlayerData = playerData;
		return true;
	}
	
	private void OnApplicationQuit()
	{
		SaveGame();
	}
}
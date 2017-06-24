using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class MainController : MonoBehaviour {

	public Text testDisplay;
	public Text textScore;
	public List<Text> buttonTexts = new List<Text>();
	public string SecretWord;
	public enum choiceOutcome{NONE, RIGHT, WRONG};
	public choiceOutcome control;

	private WordLists words;
	private int score;
	private enum Difficulty {BEGINNER, ADVANCED};

	// Use this for initialization
	void Start () {
		//Initialize word list for the duration of the game
		words = WordLists.Load(Path.Combine(Application.dataPath, "_Persistence/WordBank.xml"));
		//Initialize score
		score = 0;
		textScore.text = "Score: " + score.ToString ();
		//First Secret word is from easy list
		resetWords(Difficulty.BEGINNER);
		//Start Timer
	}
	
	// Update is called once per frame
	void Update () {
		if (control == choiceOutcome.RIGHT) {
			//reset words to advanced set of secret words
			resetWords (Difficulty.ADVANCED);
			score += 10;
			textScore.text = "Score: " + score.ToString ();
		}
		else if(control == choiceOutcome.WRONG){
			//reset words to advanced set of secret words
			resetWords (Difficulty.ADVANCED);
		}
		control = choiceOutcome.NONE;

		//If Timer ends, end game

		//Reload scene
	}

	string NewSecretWord(Difficulty DIFF){
		string word;
		//return and remove random word from the list (difficult or beginner list)
		if (DIFF == Difficulty.BEGINNER) {
			int randomInt = Random.Range (0, words.BeginnerWords.Count);
			word = words.BeginnerWords [randomInt];
			words.BeginnerWords.RemoveAt (randomInt);
			return word;
		} else{
			int randomInt = Random.Range (0, words.AdvancedWords.Count);
			word = words.AdvancedWords [randomInt];
			words.AdvancedWords.RemoveAt (randomInt);
			return word;
		}
	}
	void resetWords(Difficulty DIFF){
		if (DIFF == Difficulty.BEGINNER) {
			SecretWord = NewSecretWord (Difficulty.BEGINNER);
			AudioOutputWord (SecretWord);
			DisplayWordChoices (Difficulty.BEGINNER);
		} 
		else {
			SecretWord = NewSecretWord (Difficulty.ADVANCED);
			AudioOutputWord (SecretWord);
			DisplayWordChoices(Difficulty.ADVANCED);
		}
	}
	void AudioOutputWord(string word){
		//secret word will be output in audio soon
		testDisplay.text = word;
	}
	void DisplayWordChoices(Difficulty DIFF){
		//one random button of the 6 is the special word
		int specialPosition = Random.Range (0, 5);
		//List to store randomly generate index ensure no duplicate
		List<int> randomList = new List<int>();

		//generate random word for each button
		for (int i = 0; i < 6; i++) {
			
			//insert the secretWord
			if (i == specialPosition) {
				buttonTexts [i].text = SecretWord;
			}

			else if (DIFF == Difficulty.BEGINNER) {
				int randomInt = Random.Range (0, words.BeginnerWords.Count);
				while (randomList.Contains (randomInt)) {
					randomInt = Random.Range (0, words.BeginnerWords.Count);
				}
				buttonTexts [i].text = words.BeginnerWords[randomInt];
				randomList.Add (randomInt);
			}
			else if (DIFF == Difficulty.ADVANCED) {
				int randomInt = Random.Range (0, words.AdvancedWords.Count);
				while (randomList.Contains (randomInt)) {
					randomInt = Random.Range (0, words.AdvancedWords.Count);
				}
				buttonTexts [i].text = words.AdvancedWords[randomInt];
				randomList.Add (randomInt);
			}
		}
	}
		
}

//Word lists XML data structure
[XmlRoot("WordList")]
public class WordLists
{

	[XmlArray("BeginnerWords"),XmlArrayItem("word")]
	public List<string> BeginnerWords = new List<string>();
	[XmlArray("AdvancedWords"),XmlArrayItem("word")]
	public List<string> AdvancedWords = new List<string>();

	public static WordLists Load(string path)
	{
		var serializer = new XmlSerializer (typeof(WordLists));
		using (var stream = new FileStream (path, FileMode.Open)) 
		{
			return serializer.Deserialize (stream) as WordLists;
		}
	}


}
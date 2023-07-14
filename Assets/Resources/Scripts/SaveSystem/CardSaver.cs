using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CardSaver : ISaver
{
    private CardUI cardUI;
    private CardHub cardHub;

    public CardSaver(CardHub cardHub, CardUI cardUI)
    {
        this.cardHub = cardHub;
        this.cardUI = cardUI;
    }
    
    public void Save()
    {
        CardData data = new CardData();

        foreach (var timeCard in cardUI.GetCards())
        {
            data.timeCards.Add(timeCard.cardId, timeCard.dayDuration);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Cards.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath 
                        + "/Cards.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                File.Open(Application.persistentDataPath 
                          + "/Cards.dat", FileMode.Open);
            CardData data = (CardData)bf.Deserialize(file);
            file.Close();

            foreach (var cardWithDuration in data.timeCards)
            {
                Debug.Log(cardWithDuration.Key);
                cardUI.AddCardWithDifferentDuration(cardHub.timeCards.First(x => x.cardId == cardWithDuration.Key), cardWithDuration.Value);
            }
            
        }
        else
            Debug.LogError("There is no save data!");
    }
}

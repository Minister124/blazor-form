using Forms.Data.Models;
using Forms.Data.Utils;
using Newtonsoft.Json;

namespace Forms;

public class HobbySeed
{
    public static void SaveHobbiesToJson(List<Hobby> hobby){
        string filePath = Utils.HobbiesFilePath();
        string jsonData = JsonConvert.SerializeObject(hobby, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
    }

    public static void InjectSampleHobbiesData()
    {
        List<Hobby> sampleHobbies = new List<Hobby>
        {
            new Hobby { Name = "Reading" },
            new Hobby { Name = "Cooking" },
            new Hobby { Name = "Gardening" },
            new Hobby { Name = "Coding" },
            new Hobby { Name = "Dancing"},
            new Hobby { Name = "Singing"},
            new Hobby { Name = "Travelling"},
        };
        SaveHobbiesToJson(sampleHobbies);
    }

    public static List<Hobby> RetrieveHobbiesData(){
         string filePath = Utils.HobbiesFilePath();
         try{
            string existingJsonData = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(existingJsonData))
            {
                return new List<Hobby>();
            }
            return JsonConvert.DeserializeObject<List<Hobby>>(existingJsonData);
         }
         catch(Exception ex){
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return new List<Hobby>();
         }
    }
}

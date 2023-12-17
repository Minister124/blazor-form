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

    public static List<Hobby> RetrieveFormData(IJSRuntime iJSRuntime){
        
    }
}

using Forms.Data.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace Forms.Data.Services;

public class FormData
{
    public async Task SaveFormDataInJson(Form form, IJSRuntime jsRuntime)
    {
        string filePath = Utils.Utils.ApplicationFilePath();
        try
        {
            List<Form> formList;
            string existingJsonData = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(existingJsonData))
            {
                formList = new List<Form>();
            }
            else
            {
                formList = JsonConvert.DeserializeObject<List<Form>>(existingJsonData);
            }
            formList.Add(form);
            string formJsonData = JsonConvert.SerializeObject(formList, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, formJsonData);
        }
        catch(Exception ex)
        {
            await jsRuntime.InvokeAsync<object>("alert", new object[] { $"Error saving form data: {ex.Message}" });
        }
    }

    public static List<Form> RetrieveFormData(IJSRuntime jsRuntime)
    {
        string filePath = Utils.Utils.ApplicationFilePath();
        try
        {
            string existingJsonData = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(existingJsonData))
            {
                return new List<Form>();
            }
            return JsonConvert.DeserializeObject<List<Form>>(existingJsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            jsRuntime.InvokeAsync<object>("alert", $"Error reading JSON file: {ex.Message}");
            return new List<Form>();
        }
    }
}

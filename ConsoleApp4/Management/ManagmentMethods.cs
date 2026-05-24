using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class ManagmentMethods
{
    public static void SaveToFile(List<Student> students, string path)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(students, options);
        File.WriteAllText(path, json);
    }

    public static List<Student>? LoadFromFile(string path)
    {
        if (!File.Exists(path))
            return null;

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<Student>>(json);
    }
}
using System.IO;
using System.Text.Json;

public void SaveToFile(string path)
{
    var json = JsonSerializer.Serialize(students);
    File.WriteAllText(path, json);
}

public void LoadFromFile(string path)
{
    if (File.Exists(path))
    {
        var json = File.ReadAllText(path);
        students = JsonSerializer.Deserialize<List<Student>>(json);
    }
}
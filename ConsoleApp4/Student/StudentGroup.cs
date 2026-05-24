using System;
using System.Collections.Generic;
using System.Linq;

public class StudentGroup
{
    private List<Student> students = new List<Student>();

    public string GroupName { get; set; }
    public string Specialty { get; set; }
    public int Course { get; set; }

    public int GroupSize => students.Count;

    public double AverageGroupGrade =>
        students.Count == 0 ? 0 : students.Average(s => s.AverageGrade);

    public void AddStudent(Student s)
    {
        students.Add(s);
    }

    public void RemoveStudent(string recordBookNumber)
    {
        students.RemoveAll(s => s.RecordBookNumber == recordBookNumber);
    }

    public Student FindStudent(string name)
    {
        return students.FirstOrDefault(s => s.FullName.Contains(name));
    }

    public List<Student> GetExcellentStudents()
    {
        return students.Where(s => s.IsExcellent()).ToList();
    }

    public List<Student> GetFailingStudents()
    {
        return students.Where(s => s.IsFailing()).ToList();
    }

    public void ShowAll()
    {
        foreach (var s in students)
        {
            Console.WriteLine($"{s.FullName} - {s.AverageGrade}");
        }
    }
}
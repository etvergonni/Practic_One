using System;
using System.Text.RegularExpressions;

public enum StudentStatus
{
    Active,
    AcademicLeave,
    Expelled,
    Graduated
}

public class Student
{
    private string _fullName;
    private string _recordBookNumber;
    private double _averageGrade;
    private string _email;

    public required string FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                throw new ArgumentException("ПІБ має містити мінімум 5 символів");
            _fullName = value;
        }
    }

    public DateTime DateOfBirth { get; init; }

    public int Age => CalculateAge();

    public required string RecordBookNumber
    {
        get => _recordBookNumber;
        init
        {
            if (!Regex.IsMatch(value, @"^\d{8}$"))
                throw new ArgumentException("Номер заліковки має бути 8 цифр");
            _recordBookNumber = value;
        }
    }

    public double AverageGrade
    {
        get => _averageGrade;
        private set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Оцінка має бути 0-100");
            _averageGrade = Math.Round(value, 2);
        }
    }

    public StudentStatus Status { get; set; }

    public DateTime EnrollmentDate { get; init; }

    public string PersonalEmail
    {
        get => _email;
        set
        {
            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Невірний email");
            _email = value;
        }
    }

    public string Notes { get; set; }

    public void UpdateAverageGrade(double newGrade)
    {
        AverageGrade = newGrade;
    }

    public bool IsExcellent() => AverageGrade >= 90;

    public bool IsFailing() => AverageGrade < 60;

    public int CalculateAge()
    {
        var today = DateTime.Today;
        int age = today.Year - DateOfBirth.Year;
        if (DateOfBirth > today.AddYears(-age)) age--;
        return age;
    }

    public int GetYearsToGraduation()
    {
        return Math.Max(0, 4 - (DateTime.Now.Year - EnrollmentDate.Year));
    }

    public void ShowDetailedInfo()
    {
        Console.WriteLine($"ПІБ: {FullName}");
        Console.WriteLine($"Вік: {Age}");
        Console.WriteLine($"Бал: {AverageGrade}");
        Console.WriteLine($"Статус: {Status}");
    }
}

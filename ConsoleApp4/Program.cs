StudentGroup group = new StudentGroup();

while (true)
{
    Console.WriteLine("1 Додати");
    Console.WriteLine("2 Показати");
    Console.WriteLine("0 Вихід");

    var choice = Console.ReadLine();

    if (choice == "1")
    {
        var s = new Student
        {
            FullName = "Test Student",
            RecordBookNumber = "12345678",
            DateOfBirth = new DateTime(2005, 1, 1),
            EnrollmentDate = DateTime.Now,
            Status = StudentStatus.Active,
            PersonalEmail = "test@gmail.com"
        };

        s.UpdateAverageGrade(95);
        group.AddStudent(s);
    }
    else if (choice == "2")
    {
        group.ShowAll();
    }
    else if (choice == "0")
    {
        break;
    }
}
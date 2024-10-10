namespace Assignment03;


// IPersonService interface: defines common methods for Person
public interface IPersonService
{
    int CalculateAge();
    decimal CalculateSalary();
    void AddAddress(string address);
    string GetName();
    Department GetDepartment();
}

// IStudentService interface: inherits from IPersonService and defines student-specific methods
public interface IStudentService : IPersonService
{
    decimal CalculateGPA();
    void AddCourse(Course course, char grade);
}

// IInstructorService interface: inherits from IPersonService and defines instructor-specific methods
public interface IInstructorService : IPersonService
{
    int CalculateYearsOfExperience();
}

// ICourseService interface: defines methods related to courses
public interface ICourseService
{
    string GetCourseName();
    void EnrollStudent(Student student);
    List<Student> GetEnrolledStudents();
}

// IDepartmentService interface: defines methods related to departments
public interface IDepartmentService
{
    string GetDepartmentName();
    void SetHeadOfDepartment(Instructor instructor);
    void AddCourse(Course course);
    List<Course> GetCourses();
    Instructor GetHeadOfDepartment();
    decimal GetBudget();
}

// Abstract class: defines the basic properties and methods of all persons
public abstract class Person
{
    private string name;
    private DateTime birthDate;
    private List<string> addresses = new List<string>();
    private Department department;

    // Constructor
    public Person(string name, DateTime birthDate, Department department)
    {
        this.name = name;
        this.birthDate = birthDate;
        this.department = department;
    }

    // Calculate age
    public int CalculateAge()
    {
        return DateTime.Now.Year - birthDate.Year;
    }

    // Virtual method: salary calculation, can be overridden by subclasses
    public virtual decimal CalculateSalary()
    {
        return 0;
    }

    // Add an address
    public void AddAddress(string address)
    {
        addresses.Add(address);
    }

    // Get all addresses
    public List<string> GetAddresses()
    {
        return addresses;
    }

    // Get name
    public string GetName()
    {
        return name;
    }

    // Get the department the person belongs to
    public Department GetDepartment()
    {
        return department;
    }
}


// Student class: inherits from Person and implements IStudentService
public class Student : Person, IStudentService
{
    private Dictionary<Course, char> courses = new Dictionary<Course, char>();

    public Student(string name, DateTime birthDate, Department department) : base(name, birthDate, department) { }

    // Add a course and its grade
    public void AddCourse(Course course, char grade)
    {
        courses[course] = grade;
    }

    // Calculate GPA, where A=4, B=3, C=2, D=1, F=0
    public decimal CalculateGPA()
    {
        decimal totalPoints = 0;
        foreach (var grade in courses.Values)
        {
            totalPoints += GradeToPoint(grade);
        }
        return courses.Count > 0 ? totalPoints / courses.Count : 0;
    }

    private decimal GradeToPoint(char grade)
    {
        return grade switch
        {
            'A' => 4,
            'B' => 3,
            'C' => 2,
            'D' => 1,
            'F' => 0,
            _ => 0
        };
    }

    // Override salary calculation (students don't have a salary)
    public override decimal CalculateSalary()
    {
        return 0;
    }
}


// Instructor class: inherits from Person and implements IInstructorService
public class Instructor : Person, IInstructorService
{
    private DateTime joinDate;
    private decimal baseSalary;

    public Instructor(string name, DateTime birthDate, decimal baseSalary, DateTime joinDate, Department department)
         : base(name, birthDate, department)
    {
        this.baseSalary = baseSalary;
        this.joinDate = joinDate;
    }

    // Calculate years of experience
    public int CalculateYearsOfExperience()
    {
        return DateTime.Now.Year - joinDate.Year;
    }

    // Calculate salary based on base salary and years of experience
    public override decimal CalculateSalary()
    {
        return baseSalary + (CalculateYearsOfExperience() * 1000);
    }
}


// Course class
public class Course : ICourseService
{
    public string CourseName { get; private set; }
    public List<Student> EnrolledStudents { get; private set; }

    public Course(string courseName)
    {
        CourseName = courseName;
        EnrolledStudents = new List<Student>();
    }

    public string GetCourseName()
    {
        return CourseName;
    }

    public void EnrollStudent(Student student)
    {
        EnrolledStudents.Add(student);
    }

    public List<Student> GetEnrolledStudents()
    {
        return EnrolledStudents;
    }
}


// Department class
public class Department
{
    public string DepartmentName { get; private set; }
    public Instructor HeadOfDepartment { get; private set; }
    public List<Course> Courses { get; private set; }
    public decimal Budget { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Department(string departmentName, Instructor headOfDepartment, decimal budget, DateTime startDate, DateTime endDate)
    {
        DepartmentName = departmentName;
        HeadOfDepartment = headOfDepartment;
        Budget = budget;
        StartDate = startDate;
        EndDate = endDate;
        Courses = new List<Course>();
    }

    public string GetDepartmentName()
    {
        return DepartmentName;
    }

    public void SetHeadOfDepartment(Instructor instructor)
    {
        HeadOfDepartment = instructor;
    }

    public Instructor GetHeadOfDepartment()
    {
        return HeadOfDepartment;
    }

    public void AddCourse(Course course)
    {
        Courses.Add(course);
    }

    public List<Course> GetCourses()
    {
        return Courses;
    }

    public decimal GetBudget()
    {
        return Budget;
    }
}
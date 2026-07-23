namespace PEMS.Domain.Entities;

public class Employee
{
    public int EmployeeId { get; set; }

    // کد پرسنلی
    public string PersonnelCode { get; set; } = string.Empty;

    // نام
    public string FirstName { get; set; } = string.Empty;

    // نام خانوادگی
    public string LastName { get; set; } = string.Empty;

    // سمت سازمانی
    public string? Position { get; set; }

    // ایمیل
    public string? Email { get; set; }

    // شماره تماس
    public string? Phone { get; set; }

    // ارتباط با Department
    public int DepartmentId { get; set; }

    public Department? Department { get; set; }

    // ارتباط با Discipline
    public int DisciplineId { get; set; }

    public Discipline? Discipline { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
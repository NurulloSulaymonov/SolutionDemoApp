namespace Infrastructure.Services;

public class DepartmentService
{
    private List<string> departments = new List<string>()
    {
        "IT",
        "HR",
        "Finance"
    };

public DepartmentService()
    {
        
    }

    public List<string> GetDepartments()
    {
        return departments;
    }
}
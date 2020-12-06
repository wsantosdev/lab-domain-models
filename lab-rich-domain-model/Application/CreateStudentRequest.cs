namespace lab_rich_domain_model.Application
{
    public record CreateStudentRequest(string Name, string Surname, byte Age, byte Grade);
}
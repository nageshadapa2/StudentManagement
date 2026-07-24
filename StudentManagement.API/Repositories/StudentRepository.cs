namespace StudentManagement.API.Repositories
{
    public class StudentRepository: IStudentRepository
    {
      
        public string GetWelcomeMessage()
        {
            return "welcome repository";

        }
    }
}

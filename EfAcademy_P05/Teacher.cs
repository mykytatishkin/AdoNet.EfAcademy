namespace EfAcademy_P05
{
    public class Teacher: Person
    {
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public List<Student> Students { get; set; }
    }

}